import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private baseUrl=environment.apiUrl;
  constructor(private http:HttpClient) { }
  Farmerlogin(userData:any)
  {
    return this.http.post(this.baseUrl + "Auth/Farmer_Login",{email:userData[0],password:userData[1]},{responseType:'text',});
  }
  Dealerlogin(userData:any)
  {
    return this.http.post(this.baseUrl + "Auth/Dealer_Login",{email:userData[0],password:userData[1]},{responseType:'text',});
  }
  Adminlogin(userData:any)
  {
    return this.http.post(this.baseUrl + "Auth/Admin_Login",{email:userData[0],password:userData[1]},{responseType:'text',});
  }
  //#region farmertoken
  getFarmerToken():string | null
  {
    return localStorage.getItem("Farmertoken");
  }
  setFarmerToken(value:string)
  {
    localStorage.setItem("Farmertoken",value);
  }

  isFarmerLoggedIn():boolean
  {
    return localStorage.getItem("Farmertoken")?true:false;
  }
  removeFarmerToken()
  {
    localStorage.removeItem("Farmertoken");
  }
  //#endregion
  //#region Dealertoken
  getDealerToken():string | null
  {
    return localStorage.getItem("Dealertoken");
  }
  setDealerToken(value:string)
  {
    localStorage.setItem("Dealertoken",value);
  }

  isDealerLoggedIn():boolean
  {
    return localStorage.getItem("Dealertoken")?true:false;
  }
  removeDealerToken()
  {
    localStorage.removeItem("Dealertoken");
  }
  //#endregion
  //#region Admintoken
  getAdminToken():string | null
  {
    return localStorage.getItem("Admintoken");
  }
  setAdminToken(value:string)
  {
    localStorage.setItem("Admintoken",value);
  }

  isAdminLoggedIn():boolean
  {
    return localStorage.getItem("Admintoken")?true:false;
  }
  removeAdminToken()
  {
    localStorage.removeItem("Admintoken");
  }
  //#endregion
}
