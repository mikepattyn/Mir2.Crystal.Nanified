import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from "@angular/router";
import { DashboardData } from "./dashboard-data";

@Injectable({
  providedIn: 'root'
})
export class DashboardPrefetchResolver implements Resolve<any> {
  constructor(private router: Router, private httpClient: HttpClient) { }
  handleError(error: Error) {
    this.router.navigateByUrl('/404');
    return error;
  }
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    return this.httpClient.get<DashboardData>("http://localhost:5000/dashboard");
  }
}
