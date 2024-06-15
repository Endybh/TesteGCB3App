using FluentValidation.Results;
using NotificationContext = TesteB3App.Core.Notification;

namespace TesteB3App.Test.Notification
{
    [TestClass]
    public class NotificationContextTests
    {
        [TestMethod]
        public void AddNotification_StringAndMessage_AddsNotification()
        {
            // Arrange
            var context = new NotificationContext.NotificationContext();
            var key = "TestKey";
            var message = "TestMessage";

            // Act
            context.AddNotification(key, message);

            // Assert
            Assert.AreEqual(1, context.Notifications.Count);
            var notification = context.Notifications.First();
            Assert.AreEqual(key, notification.Key);
            Assert.AreEqual(message, notification.Message);
        }

        [TestMethod]
        public void AddNotification_Notification_AddsNotification()
        {
            // Arrange
            var context = new NotificationContext.NotificationContext();
            var notification = new NotificationContext.Notification("TestKey", "TestMessage");

            // Act
            context.AddNotification(notification);

            // Assert
            Assert.AreEqual(1, context.Notifications.Count);
            Assert.AreEqual(notification, context.Notifications.First());
        }

        [TestMethod]
        public void AddNotifications_IReadOnlyCollection_AddsNotifications()
        {
            // Arrange
            var context = new NotificationContext.NotificationContext();
            var notifications = new List<NotificationContext.Notification>
            {
                new NotificationContext.Notification("TestKey1", "TestMessage1"),
                new NotificationContext.Notification("TestKey2", "TestMessage2")
            };

            // Act
            context.AddNotifications((IReadOnlyCollection<NotificationContext.Notification>)notifications);

            // Assert
            Assert.AreEqual(2, context.Notifications.Count);
            CollectionAssert.AreEqual(notifications, context.Notifications.ToList());
        }

        [TestMethod]
        public void AddNotifications_IList_AddsNotifications()
        {
            // Arrange
            var context = new NotificationContext.NotificationContext();
            var notifications = new List<NotificationContext.Notification>
            {
                new NotificationContext.Notification("TestKey1", "TestMessage1"),
                new NotificationContext.Notification("TestKey2", "TestMessage2")
            };

            // Act
            context.AddNotifications((IList<NotificationContext.Notification>)notifications);

            // Assert
            Assert.AreEqual(2, context.Notifications.Count);
            CollectionAssert.AreEqual(notifications, context.Notifications.ToList());
        }

        [TestMethod]
        public void AddNotifications_ICollection_AddsNotifications()
        {
            // Arrange
            var context = new NotificationContext.NotificationContext();
            var notifications = new List<NotificationContext.Notification>
            {
                new NotificationContext.Notification("TestKey1", "TestMessage1"),
                new NotificationContext.Notification("TestKey2", "TestMessage2")
            };

            // Act
            context.AddNotifications((ICollection<NotificationContext.Notification>)notifications);

            // Assert
            Assert.AreEqual(2, context.Notifications.Count);
            CollectionAssert.AreEqual(notifications, context.Notifications.ToList());
        }

        [TestMethod]
        public void AddNotifications_ValidationResult_AddsNotifications()
        {
            // Arrange
            var context = new NotificationContext.NotificationContext();
            var validationResult = new ValidationResult(new List<ValidationFailure>
            {
                new ValidationFailure("TestKey1", "TestMessage1") { ErrorCode = "Error1" },
                new ValidationFailure("TestKey2", "TestMessage2") { ErrorCode = "Error2" }
            });

            // Act
            context.AddNotifications(validationResult);

            // Assert
            Assert.AreEqual(2, context.Notifications.Count);
            Assert.AreEqual("Error1", context.Notifications.First().Key);
            Assert.AreEqual("TestMessage1", context.Notifications.First().Message);
            Assert.AreEqual("Error2", context.Notifications.Last().Key);
            Assert.AreEqual("TestMessage2", context.Notifications.Last().Message);
        }

        [TestMethod]
        public void HasNotifications_ReturnsTrue_WhenThereAreNotifications()
        {
            // Arrange
            var context = new NotificationContext.NotificationContext();
            context.AddNotification("TestKey", "TestMessage");

            // Act
            var hasNotifications = context.HasNotifications;

            // Assert
            Assert.IsTrue(hasNotifications);
        }

        [TestMethod]
        public void HasNotifications_ReturnsFalse_WhenThereAreNoNotifications()
        {
            // Arrange
            var context = new NotificationContext.NotificationContext();

            // Act
            var hasNotifications = context.HasNotifications;

            // Assert
            Assert.IsFalse(hasNotifications);
        }
    }
}
