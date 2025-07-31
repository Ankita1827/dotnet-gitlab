import { CanActivateFn } from '@angular/router';

export const unauthorizedGuard: CanActivateFn = (route, state) => {
  let isLoggedIn = localStorage.getItem('status')
  if(isLoggedIn==='loggedin')
  return true;
else
  return false;
};
