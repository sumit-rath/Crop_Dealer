import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FarmerService } from 'src/app/services/farmer.service';
import { RegistrationComponent } from '../registration/registration.component';

@Component({
  selector: 'app-addbank',
  templateUrl: './addbank.component.html',
  styleUrls: ['./addbank.component.css']
})
export class AddbankComponent 
{
    constructor(private farmerservice:FarmerService,private router2:Router){}
      bankform=new FormGroup({
        accountnum:new FormControl("",[Validators.required,Validators.minLength(10),Validators.maxLength(18)]),
        holdername:new FormControl("",[Validators.required]),
        ifsc:new FormControl("",[Validators.required,Validators.pattern("^[A-Z]{4}0[A-Z0-9]{6}$")]),
        farmeremail:new FormControl("",[Validators.required,Validators.email])
    })
    get AccNum():FormControl
    {
      return this.bankform.get("accountnum") as FormControl;
    }
    get HolderName():FormControl
    {
      return this.bankform.get("holdername") as FormControl;
    }
    get IFSC():FormControl
    {
      return this.bankform.get("ifsc") as FormControl;
    }
    get FarmerEmail():FormControl
    {
      return this.bankform.get("farmeremail") as FormControl;
    }
    bankDetails()
      {
        
        console.log(this.bankform.value);
          this.farmerservice.AddFarmerBankDetail([
            this.bankform.value.accountnum,
            this.bankform.value.holdername,
            this.bankform.value.ifsc,
            this.bankform.value.farmeremail
          ]).subscribe(res=>{
            console.log(res);
            if(res=="Bank Details Added Successfully")
            {
              alert(res);
              this.router2.navigateByUrl('login');
            }
            else
            {
              alert(res);
            }
          });
       } 
  }