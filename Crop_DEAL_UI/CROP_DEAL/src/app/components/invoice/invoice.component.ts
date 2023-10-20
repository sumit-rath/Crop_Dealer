import { Component } from '@angular/core';
import { AdminService } from 'src/app/services/admin.service';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { DealerService } from 'src/app/services/dealer.service';
import { FarmerService } from 'src/app/services/farmer.service';

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.css']
})
export class InvoiceComponent {
 InvoiceList:any[]=[];
  constructor(private farmerservice:FarmerService,private dealerservice:DealerService,private adminservice:AdminService,private authservice:AuthenticationService){}
  ngOnInit() {
    if(this.Farmerclaim())
    {
      this.farmerservice.ViewInvoice().subscribe((res:any[])=>{
        this.InvoiceList=res;
      })
    }
    else if(this.Dealerclaim())
    {
      this.dealerservice.ViewInvoice().subscribe((res:any[])=>{
        this.InvoiceList=res;
      })
    }
    else if(this.Adminclaim())
    {
      this.adminservice.ViewInvoice().subscribe((res:any[])=>{
        this.InvoiceList=res;
      })
    }
    else{
      alert("Error Please Re-Login");
    }
    }
    deleteinvoice(id:number){
      this.adminservice.DeleteInvoice(id).subscribe(res=>{
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
