import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthenticationService } from './authentication.service';
import { environment } from 'src/environments/environment.development';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private baseUrl= environment.apiUrl;
  constructor(private http:HttpClient,private authservice:AuthenticationService) { }
  ViewInvoice():Observable<any[]>
  {
      var token=this.authservice.getAdminToken();
      let header=new HttpHeaders().set('Authorization','bearer '+token);
      return this.http.get<any[]>(this.baseUrl+"Admin/All_Invoice",{headers:header});  
  }
  
  DeleteInvoice(id:any){
    var token=this.authservice.getAdminToken();
    let header=new HttpHeaders().set('Authorization','bearer '+token);
    return this.http.delete(this.baseUrl+"Admin/Delete_Invoice?id="+id,{headers:header,responseType:'text'});
    }
  ViewFarmers():Observable<any[]>
  {
  
      var token=this.authservice.getAdminToken();
      let header=new HttpHeaders().set('Authorization','bearer '+token);
      return this.http.get<any[]>(this.baseUrl+"Admin/All_Farmers",{headers:header});
    
  }
  ViewDealer():Observable<any[]>
  {
  
      var token=this.authservice.getAdminToken();
      let header=new HttpHeaders().set('Authorization','bearer '+token);
      return this.http.get<any[]>(this.baseUrl+"Admin/All_Dealers",{headers:header});
    
  }
  DeleteFarmer(id:any)
  {
    var token=this.authservice.getAdminToken();
    let header=new HttpHeaders().set('Authorization','bearer '+token);
    return this.http.delete(this.baseUrl+"Admin/Delete_Farmer?id="+id,{headers:header,responseType:'text'});
  }
  DeleteDealer(id:any)
  {
    var token=this.authservice.getAdminToken();
    let header=new HttpHeaders().set('Authorization','bearer '+token);
    return this.http.delete(this.baseUrl+"Admin/Delete_Dealer?id="+id,{headers:header,responseType:'text'});
  }
  }
