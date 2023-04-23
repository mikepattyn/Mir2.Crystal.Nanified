import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from "./dashboard/dashboard.component";
import { ExplorerComponent } from "./explorer/explorer.component";
import { DatabaseReflectionResolver } from "./database-reflection-resolver";
import { CommonModule } from '@angular/common';
import { DashboardPrefetchResolver } from './fetch-dashboard-data-resolver';

const routes: Routes = [
  {
    path: "",
    component: DashboardComponent,
    resolve: {
      preFetchData: DashboardPrefetchResolver
    }
  },
  {
    path: "explorer",
    component: ExplorerComponent,
    resolve: {
      preFetchData: DatabaseReflectionResolver
    }
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes), CommonModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
