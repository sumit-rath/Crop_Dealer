import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { Observable } from 'rxjs';
import { AuthenticationService } from './authentication.service';
@Injectable({
  providedIn: 'root'
})
export class FarmerService {

  private baseUrl= environment.apiUrl;
  constructor(private http:HttpClient,private authservice:AuthenticationService) { }
  registerUser(userData: any)
  {
    return this.http.post(this.baseUrl + "Farmer/Farmer_Registration",{
      FarmerName:userData[0],
      FarmerEmail:userData[1],
      Contact:userData[2],
      Password:userData[3]
    },
    {responseType:'text',});
  }
  AddFarmerBankDetail(userData: any)
  {
    return this.http.post(this.baseUrl + "Farmer/Bank_Details",{
      AccountNum:userData[0],
      HolderName:userData[1],
      IffcCode:userData[2],
      FarmerEmail:userData[3]
    },
    {responseType:'text',});
  }
  EditFarmerBankDetail(userData: any)
  {
    const token=this.authservice.getFarmerToken();
    let header=new HttpHeaders().set('Authorization','bearer '+token);
    return this.http.put(this.baseUrl + "Farmer/Edit_Bank_Details",{
      AccountNum:userData[0],
      HolderName:userData[1],
      IffcCode:userData[2],
      FarmerEmail:userData[3],
      BankId:userData[4]
    },
    {headers:header,responseType:'text'});
  }
  ViewBankDetails()
  {
      var token=this.authservice.getFarmerToken();
      let header=new HttpHeaders().set('Authorization','bearer '+token);
      return this.http.get(this.baseUrl+"Farmer/View_Bank_Details",{headers:header});  
  }
  ViewInvoice():Observable<any[]>
  {
      var token=this.authservice.getFarmerToken();
      let header=new HttpHeaders().set('Authorization','bearer '+token);
      return this.http.get<any[]>(this.baseUrl+"Farmer/View_Farmer_Invoice",{headers:header});  
  }
  ViewProfile()
  {
      var token=this.authservice.getFarmerToken();
      let header=new HttpHeaders().set('Authorization','bearer '+token);
      return this.http.get(this.baseUrl+"Farmer/View_Profile",{headers:header});  
  }
  EditProfile(userData:any){
    const token=this.authservice.getFarmerToken();
    let header=new HttpHeaders().set('Authorization','bearer '+token);
    return this.http.put(this.baseUrl + "Farmer/Edit_Farmer_Profile",{
      FarmerId:userData[0],
      FarmerName:userData[1],
      FarmerEmail:userData[2],
      Password:userData[3],
      Contact:userData[4]
    },
    {headers:header,responseType:'text'});
  }
}
