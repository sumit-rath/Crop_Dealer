import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  displayMsg:string='';
  isAccountLogin:boolean=false;
constructor(private authservice:AuthenticationService,private router:Router){}
LoginForm=new FormGroup({
  emailid:new FormControl("",[Validators.required,Validators.email]),
  passkey:new FormControl("",[Validators.required]),
  role:new FormControl("",[Validators.required])
})
 get EmailId():FormControl
  {
    return this.LoginForm.get("emailid") as FormControl;
  }
  get PassKey():FormControl
  {
    return this.LoginForm.get("passkey") as FormControl;
  }
  get Role():FormControl
  {
    return this.LoginForm.get("role") as FormControl;
  }
  Auth(){
    if(this.authservice.isAdminLoggedIn()==true||this.authservice.isFarmerLoggedIn()==true||this.authservice.isDealerLoggedIn()==true){
      alert("Already Logged In");
    }
    else
    {
    if(this.LoginForm.value.role=="farmer")
    {
      this.authservice.Farmerlogin([
        this.LoginForm.value.emailid,
        this.LoginForm.value.passkey
      ]).subscribe((res:any)=>
        {
          if(res)
          {
            const result=JSON.parse(res);
            this.authservice.setFarmerToken(result.token);
            alert("Login Successful");
            this.router.navigateByUrl('farmerpage');
          }
        },
        (error) => {
          if (error.status === 401) {
           alert("Login failed");
          }
        });
    }
    if(this.LoginForm.value.role=="dealer")
    {
      this.authservice.Dealerlogin([
        this.LoginForm.value.emailid,
        this.LoginForm.value.passkey
      ]).subscribe((res:any)=>
      {
        if(res)
        {
          const result=JSON.parse(res);
          this.authservice.setDealerToken(result.token);
          alert("Login Successful");
          this.router.navigateByUrl('dealerpage');
        }
      },
      (error) => {
        if (error.status === 401) {
         alert("Login failed");
        }
      });
    }
    if(this.LoginForm.value.role=="admin")
    {
      this.authservice.Adminlogin([
        this.LoginForm.value.emailid,
        this.LoginForm.value.passkey
      ]).subscribe((res:any)=>
      {
        if(res)
        {
          const result=JSON.parse(res);
          this.authservice.setAdminToken(result.token);
          alert("Login Successful");
          this.router.navigateByUrl('adminpage');
        }
      },
      (error) => {
        if (error.status === 401) {
         alert("Login failed");
        }
      });
    }}
  }
}
