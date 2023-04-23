import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class DatabaseReflectionResolver implements Resolve<any> {
  constructor(private router: Router, private httpClient: HttpClient) { }
  handleError(error: Error) {
    this.router.navigateByUrl('/404');
    return error;
  }
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    console.log(route);
      return this.httpClient.get<ITableViewModel[]>("https://localhost:5000")
  }
}

export interface ITableViewModel {
  Name: string;
  Headers: string[];
}
