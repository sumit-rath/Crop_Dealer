import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, MinValidator, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { CropService } from 'src/app/services/crop.service';

@Component({
  selector: 'app-view-crop',
  templateUrl: './view-crop.component.html',
  styleUrls: ['./view-crop.component.css']
})
export class ViewCropComponent{
CropList:any[]=[];
Invoice:any[]=[];
buyCropForm=new FormGroup({
  cropquantity:new FormControl("",[Validators.required,Validators.min(0.1)])
})

constructor(private cropservice:CropService,private router:Router, private authservice:AuthenticationService){}
  ngOnInit() {
    this.cropservice.ViewCrops().subscribe((res:any[])=>{
      this.CropList=res;
    })
  }
  get CropQuantity():FormControl
  {
    return this.buyCropForm.get("cropquantity") as FormControl;
  }
  deletecrop(id:number){
    this.cropservice.DeleteCrop(id).subscribe(res=>{
      if(res=="Deleted Successfully")
      {
        alert(res);
        location.reload();
      }
    });
  }
  buycrop(id:number){
    this.cropservice.BuyCrop([id,this.buyCropForm.value.cropquantity]).subscribe((res:any)=>
    {
      if(res)
      {
       this.Invoice=res;
       console.log(this.Invoice);
       alert("Successfull");
       location.reload();
      }
    },
    (error) => {
      if (error.status === 425) {
       alert("Quantity Not Available");
      }
      if(error.status==450){
        alert("Error occured please retry");
      }
    });
  }
  subcrop(cropname:string){
    this.cropservice.SubCrop(cropname).subscribe(res=>{
        alert(res);
        location.reload();
    });
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
}
