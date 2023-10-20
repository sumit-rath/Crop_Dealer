import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RegistrationComponent } from './components/registration/registration.component';
import { HomeComponent } from './components/home/home.component';
import { PagenotfoundComponent } from './components/pagenotfound/pagenotfound.component';
import { AddbankComponent } from './components/addbank/addbank.component';
import { LoginComponent } from './components/login/login.component';
import { AddCropComponent } from './components/add-crop/add-crop.component';
import { FamerpageComponent } from './components/famerpage/famerpage.component';
import { ViewCropComponent } from './components/view-crop/view-crop.component';
import { EditbankComponent } from './components/editbank/editbank.component';
import { InvoiceComponent } from './components/invoice/invoice.component';
import { AuthenticationService } from './services/authentication.service';
import { FarmerService } from './services/farmer.service';
import { AdminService } from './services/admin.service';
import { CropService } from './services/crop.service';
import { DealerService } from './services/dealer.service';
import { EditprofileComponent } from './components/editprofile/editprofile.component';
import { DealerpageComponent } from './components/dealerpage/dealerpage.component';
import { SubscribedComponent } from './components/subscribed/subscribed.component';


@NgModule({
  declarations: [
    AppComponent,
    RegistrationComponent,
    HomeComponent,
    PagenotfoundComponent,
    AddbankComponent,
    LoginComponent,
    AddCropComponent,
    FamerpageComponent,
    ViewCropComponent,
    EditbankComponent,
    InvoiceComponent,
    EditprofileComponent,
    DealerpageComponent,
    SubscribedComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [AuthenticationService,FarmerService,AdminService,CropService,DealerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
