import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { FarmerService } from 'src/app/services/farmer.service';

@Component({
  selector: 'app-editbank',
  templateUrl: './editbank.component.html',
  styleUrls: ['./editbank.component.css']
})
export class EditbankComponent {

  constructor(private farmerservice:FarmerService,private router:Router){}
  bankform=new FormGroup({
    accountnum:new FormControl("",[Validators.minLength(10),Validators.maxLength(18)]),
    holdername:new FormControl(""),
    ifsc:new FormControl("",[Validators.pattern("^[A-Z]{4}0[A-Z0-9]{6}$")]),
    farmeremail:new FormControl("",[Validators.email])
})
AccountNum:string="";
hldName:string="";
IffcCode:string="";
Email:string="";
Id:number=0;
ngOnInit() {
  this.farmerservice.ViewBankDetails().subscribe((res:any)=>{
    this.AccountNum=res.accountNum;
    this.hldName=res.holderName;
    this.IffcCode=res.iffcCode;
    this.Email=res.farmerEmail;
    this.Id=res.bankId;
    this.IFSC.setValue(this.IffcCode);
    this.AccNum.setValue(this.AccountNum);
    this.HolderName.setValue(this.hldName);
    this.FarmerEmail.setValue(this.Email)
  },
  (error) => {
    if (error.status === 405) {
     alert("Bank Details Not Found");
    }
  })}
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
   
      this.farmerservice.EditFarmerBankDetail([
        this.bankform.value.accountnum,
        this.bankform.value.holdername,
        this.bankform.value.ifsc,
        this.bankform.value.farmeremail,
        this.Id
      ]).subscribe(res=>{
        console.log(res);
        if(res=="Bank Details Updated Successfully")
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
}
