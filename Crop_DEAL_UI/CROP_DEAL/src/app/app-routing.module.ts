import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrationComponent } from './components/registration/registration.component';
import { HomeComponent } from './components/home/home.component';
import { PagenotfoundComponent } from './components/pagenotfound/pagenotfound.component';
import { AddbankComponent } from './components/addbank/addbank.component';
import { LoginComponent } from './components/login/login.component';
import { AddCropComponent } from './components/add-crop/add-crop.component';
import { authAdminGuard, authFarmerGuard,authDealerGuard } from './authgaurds/auth.guard';
import { FamerpageComponent } from './components/famerpage/famerpage.component';
import { ViewCropComponent } from './components/view-crop/view-crop.component';
import { EditbankComponent } from './components/editbank/editbank.component';
import { InvoiceComponent } from './components/invoice/invoice.component';
import { EditprofileComponent } from './components/editprofile/editprofile.component';
import { DealerpageComponent } from './components/dealerpage/dealerpage.component';
import { SubscribedComponent } from './components/subscribed/subscribed.component';
import { AdminpageComponent } from './components/adminpage/adminpage.component';
import { ViewfarmerComponent } from './components/viewfarmer/viewfarmer.component';
import { ViewdealerComponent } from './components/viewdealer/viewdealer.component';

const routes: Routes = [
  {
    path:'registration',
    component:RegistrationComponent
  },
  {
    path:'home',
    component:HomeComponent
  },
  {
    path:'',
    redirectTo:'home',
    pathMatch:'full'
  },
  {
    path:'addbank',
    component:AddbankComponent
  },
  {
    path:'login',
    component:LoginComponent
  },
  {
    path:'addCrop',
    component:AddCropComponent,
    canActivate:[authFarmerGuard]
  },
  {
    path:'addCropAdmin',
    component:AddCropComponent,
    canActivate:[authAdminGuard]
  },
  {
    path:'farmerpage',
    component:FamerpageComponent,
    canActivate:[authFarmerGuard]
  },
  {
    path:'dealerpage',
    component:DealerpageComponent,
    canActivate:[authDealerGuard]
  },
  {
    path:'viewCrop',
    component:ViewCropComponent,
    canActivate:[authFarmerGuard]
  },
  {
    path:'viewCropDealer',
    component:ViewCropComponent,
    canActivate:[authDealerGuard]
  },
  {
    path:'viewCropAdmin',
    component:ViewCropComponent,
    canActivate:[authAdminGuard]
  },
  {
    path:'editbankdetail',
    component:EditbankComponent,
    canActivate:[authFarmerGuard]
  },
  {
    path:'viewInvoiceFarmer',
    component:InvoiceComponent,
    canActivate:[authFarmerGuard]
  },
  {
    path:'viewInvoiceDealer',
    component:InvoiceComponent,
    canActivate:[authDealerGuard]
  },
  {
    path:'viewInvoiceAdmin',
    component:InvoiceComponent,
    canActivate:[authAdminGuard]
  },
  {
    path:'editProfileFarmer',
    component:EditprofileComponent,
    canActivate:[authFarmerGuard]
  },
  {
    path:'editProfileDealer',
    component:EditprofileComponent,
    canActivate:[authDealerGuard]
  },
  {
    path:'unsubscribe',
    component:SubscribedComponent,
    canActivate:[authDealerGuard]
  },
  {
    path:'adminpage',
    component:AdminpageComponent,
    canActivate:[authAdminGuard]
  },
  {
    path:'viewfarmeradmin',
    component:ViewfarmerComponent,
    canActivate:[authAdminGuard]
  },
  {
    path:'viewdealeradmin',
    component:ViewdealerComponent,
    canActivate:[authAdminGuard]
  },
  {
    path:'**',
    component:PagenotfoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
