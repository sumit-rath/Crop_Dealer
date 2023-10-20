import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { DealerService } from 'src/app/services/dealer.service';

@Component({
  selector: 'app-subscribed',
  templateUrl: './subscribed.component.html',
  styleUrls: ['./subscribed.component.css']
})
export class SubscribedComponent {

SubscribedCrops:any[]=[];

constructor(private dealerservice:DealerService,private router:Router, private authservice:AuthenticationService){}
  ngOnInit() {
    this.dealerservice.Viewsubcrop().subscribe((res:any[])=>{
      this.SubscribedCrops=res;
    })
  }
  deletesub(cropname:string){
    this.dealerservice.DeleteSub(cropname).subscribe(res=>{
      if(res=="Unsubscribed " + cropname)
      {
        alert(res);
        location.reload();
      }
    });
  }
}
