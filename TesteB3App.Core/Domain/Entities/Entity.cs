﻿using FluentValidation;
using FluentValidation.Results;

namespace TesteB3App.Core.Domain.Entities
{
    public class Entity
    {
        public bool Valid { get; private set; }
        public bool Invalid => !Valid;
        public ValidationResult? ValidationResult { get; private set; }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
    }
}
