import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CdbSimulatorComponent } from './Components/CdbSimulator/CdbSimulatorComponent';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    CdbSimulatorComponent    
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent, CdbSimulatorComponent]
})
export class AppModule { }
