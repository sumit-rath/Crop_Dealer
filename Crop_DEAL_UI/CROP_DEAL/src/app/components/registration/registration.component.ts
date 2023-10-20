import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DealerService } from 'src/app/services/dealer.service';
import { FarmerService } from 'src/app/services/farmer.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {

  constructor(private farmerservice:FarmerService,private dealerservice:DealerService ,private router:Router)
  {

  }
  registerForm=new FormGroup({
    username:new FormControl("",[Validators.required]),
    email:new FormControl("",[Validators.required,Validators.email]),
    phoneNo:new FormControl("",[Validators.required,Validators.minLength(10),Validators.maxLength(10),Validators.pattern("[0-9]*")]),
    password:new FormControl("",[Validators.required,Validators.minLength(6),Validators.maxLength(16)]),
    role:new FormControl("Select Role",[Validators.required])
  });
  

  get Name():FormControl
  {
    return this.registerForm.get("username") as FormControl;
  }
  get Email():FormControl
  {
    return this.registerForm.get("email") as FormControl;
  }
  get PhoneNo():FormControl
  {
    return this.registerForm.get("phoneNo") as FormControl;
  }
  get Password():FormControl
  {
    return this.registerForm.get("password") as FormControl;
  }
  get Role():FormControl
  {
    return this.registerForm.get("role") as FormControl;
  }
  registerSubmit()
  {
    console.log(this.registerForm.value);
    if(this.registerForm.value.role=="farmer")
    {
      this.farmerservice.registerUser([
        this.registerForm.value.username,
        this.registerForm.value.email,
        this.registerForm.value.phoneNo,
        this.registerForm.value.password
      ]).subscribe(res=>{
        if(res=="Farmer Added Successfully")
        {
          alert(res);
          this.router.navigateByUrl('addbank');
        }
        else
        {
          alert(res);
        }
      });
    }
    else if(this.registerForm.value.role=="dealer")
    {
      this.dealerservice.registerUser([
        this.registerForm.value.username,
        this.registerForm.value.email,
        this.registerForm.value.phoneNo,
        this.registerForm.value.password
      ]).subscribe(res=>{
        if(res=="Dealer Added Successfully")
        {
          alert(res);
          this.router.navigateByUrl('login');
        }
        else
        {
          alert(res);
        }
      });
    }
    
  }
}

