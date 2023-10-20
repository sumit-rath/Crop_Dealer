import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/services/admin.service';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-viewdealer',
  templateUrl: './viewdealer.component.html',
  styleUrls: ['./viewdealer.component.css']
})
export class ViewdealerComponent {
  DealerList:any[]=[];
  constructor(private adminservice:AdminService,private router:Router, private authservice:AuthenticationService){}
  ngOnInit() {
    this.adminservice.ViewDealer().subscribe((res:any[])=>{
      this.DealerList=res;
    })
  }
  deleteDealer(id:number){
    this.adminservice.DeleteDealer(id).subscribe(res=>{
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
