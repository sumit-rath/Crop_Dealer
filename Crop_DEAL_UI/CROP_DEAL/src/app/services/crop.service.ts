import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { FarmerService } from './farmer.service';
import { AuthenticationService } from './authentication.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CropService {
  private baseUrl=environment.apiUrl;
  constructor(private http:HttpClient,private authservice:AuthenticationService) { }
  AddCropService(userdata:any){
    var token;
    if(this.authservice.getFarmerToken()!=null)
    {
      token=this.authservice.getFarmerToken();
    }
    else
    {
      token=this.authservice.getAdminToken();
    }
    let header=new HttpHeaders().set('Authorization','bearer '+token);
    return this.http.post(this.baseUrl+"Farmer/Add_Crop",{
      CropName:userdata[0],
      Crop_Type:userdata[1],
      Quatity:userdata[2],
      PricePerKg:userdata[3],
      FarmerEmail:userdata[4],
      CropLocation:userdata[5]      
    },{headers:header,responseType:'text'});
  }
  ViewCrops():Observable<any[]>
  { var token;
    if(this.authservice.getFarmerToken()!=null)
    {
      token=this.authservice.getFarmerToken();
      let header=new HttpHeaders().set('Authorization','bearer '+token);
      return this.http.get<any[]>(this.baseUrl+"Farmer/View_Crop",{headers:header});
    }
    else if(this.authservice.getDealerToken()!=null)
    {
      token=this.authservice.getDealerToken();

      let header=new HttpHeaders().set('Authorization','bearer '+token);
      return this.http.get<any[]>(this.baseUrl+"Dealer/View_All_Crops",{headers:header});
    }
    else
    {
      token=this.authservice.getAdminToken();
      let header=new HttpHeaders().set('Authorization','bearer '+token);
      return this.http.get<any[]>(this.baseUrl+"Dealer/View_All_Crops",{headers:header});
    }
  }
  DeleteCrop(id:any){

    var token;
    if(this.authservice.getFarmerToken()!=null)
    {
    token=this.authservice.getFarmerToken();
    let header=new HttpHeaders().set('Authorization','bearer '+token);
    return this.http.delete(this.baseUrl+"Farmer/Delete_Crop?id="+id,{headers:header,responseType:'text'});
    }
    else{
      token=this.authservice.getAdminToken();
    let header=new HttpHeaders().set('Authorization','bearer '+token);
    return this.http.delete(this.baseUrl+"Farmer/Delete_Crop?id="+id,{headers:header,responseType:'text'});
    }
  }
  BuyCrop(userData:any){
    var token=this.authservice.getDealerToken();
    let header=new HttpHeaders().set('Authorization','bearer '+token);
    return this.http.post(this.baseUrl+"Dealer/Buy_Crops",{Id:userData[0],quantity:userData[1]},{headers:header});
  }
  SubCrop(cropname:string){
    var token=this.authservice.getDealerToken();
    let header=new HttpHeaders().set('Authorization','bearer '+token);
    return this.http.post(this.baseUrl+"Dealer/Subscribe_Crop?cropname="+cropname,null,{headers:header,responseType:'text'});
  }
}
