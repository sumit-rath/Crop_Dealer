import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';

export const authFarmerGuard: CanActivateFn = (route, state) => {
  let authservice:AuthenticationService=inject(AuthenticationService);
  let router=inject(Router);
  const result:boolean=authservice.isFarmerLoggedIn();
  if(result)
  {
    return true;
  }
  else{
    router.navigate(["login"]);
    return false;
  }
};
export const authDealerGuard: CanActivateFn = (route, state) => {
  let authservice:AuthenticationService=inject(AuthenticationService);
  let router=inject(Router);
  const result:boolean=authservice.isDealerLoggedIn();
  if(result)
  {
    return true;
  }
  else{
    router.navigate(["login"]);
    return false;
  }
};
export const authAdminGuard: CanActivateFn = (route, state) => {
  let authservice:AuthenticationService=inject(AuthenticationService);
  let router=inject(Router);
  const result:boolean=authservice.isAdminLoggedIn();
  if(result)
  {
    return true;
  }
  else{
    router.navigate(["login"]);
    return false;
  }
};
