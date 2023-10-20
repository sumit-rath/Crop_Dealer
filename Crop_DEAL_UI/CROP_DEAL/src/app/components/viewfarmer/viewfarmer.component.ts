import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/services/admin.service';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { CropService } from 'src/app/services/crop.service';

@Component({
  selector: 'app-viewfarmer',
  templateUrl: './viewfarmer.component.html',
  styleUrls: ['./viewfarmer.component.css']
})
export class ViewfarmerComponent {
  FarmerList:any[]=[];
  constructor(private adminservice:AdminService,private router:Router, private authservice:AuthenticationService){}
  ngOnInit() {
    this.adminservice.ViewFarmers().subscribe((res:any[])=>{
      this.FarmerList=res;
    })
  }
  deleteFarmer(id:number){
    this.adminservice.DeleteFarmer(id).subscribe(res=>{
      if(res=="Deleted Successfully")
      {
        alert(res);
        location.reload();
      }
      else{
        alert(res);
      }
    });
  }
}
