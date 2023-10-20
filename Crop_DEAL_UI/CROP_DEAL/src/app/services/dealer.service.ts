import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { AuthenticationService } from './authentication.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DealerService {
  private baseUrl= environment.apiUrl;
  constructor(private http:HttpClient,private authservice:AuthenticationService) { }
  registerUser(userData: any)
  {
    return this.http.post(this.baseUrl + "Dealer/Dealer_Registration",{
      DealerName:userData[0],
      DealerEmail:userData[1],
      Contact:userData[2],
      Password:userData[3]
    },
    {responseType:'text',});
  }
  ViewInvoice():Observable<any[]>
  {
      var token=this.authservice.getDealerToken();
      let header=new HttpHeaders().set('Authorization','bearer '+token);
      return this.http.get<any[]>(this.baseUrl+"Dealer/View_Dealer_Invoice",{headers:header});  
  }
  ViewProfile()
  {
      var token=this.authservice.getDealerToken();
      let header=new HttpHeaders().set('Authorization','bearer '+token);
      return this.http.get(this.baseUrl+"Dealer/View_Profile",{headers:header});  
  }
  EditProfile(userData:any){
    const token=this.authservice.getDealerToken();
    let header=new HttpHeaders().set('Authorization','bearer '+token);
    return this.http.put(this.baseUrl + "Dealer/Edit_Dealer_Profile",{
      DealerId:userData[0],
      DealerName:userData[1],
      DealerEmail:userData[2],
      Password:userData[3],
      Contact:userData[4]
    },
    {headers:header,responseType:'text'});
  }
  Viewsubcrop():Observable<any[]>
  {
    var token=this.authservice.getDealerToken();
      let header=new HttpHeaders().set('Authorization','bearer '+token);
      return this.http.get<any[]>(this.baseUrl+"Dealer/View_Sub_Crops",{headers:header});
  }
  DeleteSub(cropname:string){
    var token=this.authservice.getDealerToken();
    let header=new HttpHeaders().set('Authorization','bearer '+token);
    return this.http.delete(this.baseUrl+"Dealer/Unsubscribe_Crop?cropname="+cropname,{headers:header,responseType:'text'});
  }
}

