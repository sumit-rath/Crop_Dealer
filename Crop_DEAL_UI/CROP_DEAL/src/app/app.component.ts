import { Component } from '@angular/core';
import { AuthenticationService } from './services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'CROP_DEAL';
  constructor(private authservice:AuthenticationService,private router:Router){}

  Farmerclaim():boolean
  {
    if(this.authservice.isFarmerLoggedIn())
    {
      return true;
    }
    else
    {
      return false;
    }
  }
  Dealerclaim():boolean
  {
    if(this.authservice.isDealerLoggedIn())
    {
      return true;
    }
    else
    {
      return false;
    }
  }
  Adminclaim():boolean
  {
    if(this.authservice.isAdminLoggedIn())
    {
      return true;
    }
    else
    {
      return false;
    }
  }
  logout()
  {
    if(this.authservice.isFarmerLoggedIn())
    {
      this.authservice.removeFarmerToken();
    }
    else if(this.authservice.isDealerLoggedIn())
    {
      this.authservice.removeDealerToken();
    }
    else
    {
      this.authservice.removeAdminToken();
    }
  }
}
