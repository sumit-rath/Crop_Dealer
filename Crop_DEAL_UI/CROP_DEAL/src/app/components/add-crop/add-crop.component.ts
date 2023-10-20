import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Crop } from 'src/app/model/Crop';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { CropService } from 'src/app/services/crop.service';
import { FarmerService } from 'src/app/services/farmer.service';

@Component({
  selector: 'app-add-crop',
  templateUrl: './add-crop.component.html',
  styleUrls: ['./add-crop.component.css']
})
export class AddCropComponent {
constructor(private cropservice:CropService,private router:Router,private authservice:AuthenticationService){}
  displayMsg:string='';
  farmeremail:string='default';
  isAccountLogin:boolean=false;
  addCropForm=new FormGroup({
    cropname:new FormControl("",[Validators.required]),
    croptype:new FormControl("",[Validators.required]),
    cropquantity:new FormControl("",[Validators.required]),
    cropPrice:new FormControl("",[Validators.required]),
    croplocation:new FormControl("",[Validators.required])
  })
  get CropName():FormControl
  {
    return this.addCropForm.get("cropname") as FormControl;
  }
  get CropType():FormControl
  {
    return this.addCropForm.get("croptype") as FormControl;
  }
  get CropQuantity():FormControl
  {
    return this.addCropForm.get("cropquantity") as FormControl;
  }
  get CropPrice():FormControl
  {
    return this.addCropForm.get("cropPrice") as FormControl;
  }
  get CropLocation():FormControl
  {
    return this.addCropForm.get("croplocation") as FormControl;
  }
  
  AddCrop(){
    this.cropservice.AddCropService([
      this.addCropForm.value.cropname,
      this.addCropForm.value.croptype,
      this.addCropForm.value.cropquantity,
      this.addCropForm.value.cropPrice,
      this.farmeremail,
      this.addCropForm.value.croplocation
      
    ]).subscribe(res=>{
      if(res=="Crop Added Successfully")
      {
        alert(res);
        location.reload();
      }
      else{
        alert(res);
        location.reload();
      }
    })
  }
}
