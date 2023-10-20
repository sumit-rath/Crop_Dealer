import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { DealerService } from 'src/app/services/dealer.service';
import { FarmerService } from 'src/app/services/farmer.service';

@Component({
  selector: 'app-editprofile',
  templateUrl: './editprofile.component.html',
  styleUrls: ['./editprofile.component.css']
})
export class EditprofileComponent {
  
  UserName:string='';
  UserEmail:string='';
  UserContact:number=0;
  UserPass:string='';
  UserId:number=0;

  constructor(private farmerservice:FarmerService,private dealerservice:DealerService ,private router:Router,private authservice:AuthenticationService){}
  editForm=new FormGroup({
    username:new FormControl("",[Validators.required]),
    phoneNo:new FormControl("",[Validators.required,Validators.minLength(10),Validators.maxLength(10),Validators.pattern("[0-9]*")]),
    pass:new FormControl("",[Validators.required,Validators.minLength(6),Validators.maxLength(16)]),
  });
  get Name():FormControl
  {
    return this.editForm.get("username") as FormControl;
  }
  get PhoneNo():FormControl
  {
    return this.editForm.get("phoneNo") as FormControl;
  }
  get Password():FormControl
  {
    return this.editForm.get("pass") as FormControl;
  }
  ngOnInit() {
    if(this.Farmerclaim())
    {
      this.farmerservice.ViewProfile().subscribe((res:any)=>{
        this.UserName=res.farmerName;
        this.UserEmail=res.farmerEmail;
        this.UserContact=res.contact;
        this.UserPass=res.password;
        this.UserId=res.farmerId;
        this.Name.setValue(this.UserName);
        this.PhoneNo.setValue(this.UserContact);
        this.Password.setValue(this.UserPass);
      },(error) => {
        if (error.status === 405) {
         alert("Farmer Details Not Found");
        }
      })
    }
    else if(this.Dealerclaim())
    {
      this.dealerservice.ViewProfile().subscribe((res:any)=>{
        this.UserName=res.dealerName;
        this.UserEmail=res.dealerEmail;
        this.UserContact=res.contact;
        this.UserPass=res.password;
        this.UserId=res.dealerId;
        this.Name.setValue(this.UserName);
        this.PhoneNo.setValue(this.UserContact);
        this.Password.setValue(this.UserPass);
      },(error) => {
        if (error.status === 405) {
         alert("Dealer Details Not Found");
        }
      })
    }
    else{
      alert("Error Please Re-Login");
    }
    }
    editUser(){
      if(this.Farmerclaim())
    {
      
      this.farmerservice.EditProfile([
        this.UserId,
        this.editForm.value.username,
        this.UserEmail,
        this.editForm.value.pass,
        this.editForm.value.phoneNo
      ]).subscribe(res=>{
        console.log(res);
        if(res=="Farmer Updated Successfully")
        {
          alert(res);
          this.router.navigateByUrl('farmerpage');
        }
        else
        {
          alert(res);
          location.reload();
        }
      });
    }
    else if(this.Dealerclaim())
    {  
      console.log(this.editForm.value);
        this.dealerservice.EditProfile([
          this.UserId,
          this.editForm.value.username,
          this.UserEmail,
          this.editForm.value.pass,
          this.editForm.value.phoneNo
        ]).subscribe(res=>{
          console.log(res);
          if(res=="Dealer Updated Successfully")
          {
            alert(res);
          }
          else
          {
            alert(res);
            location.reload();
          }
        });
    }
    }
    
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
}
