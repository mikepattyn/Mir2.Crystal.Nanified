import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Event } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit, AfterViewInit {

  constructor(private activatedRoute: ActivatedRoute) {

  }
    ngAfterViewInit(): void {
      console.log(this.activatedRoute.snapshot.data['preFetchData']);
    }

  ngOnInit(): void {
    console.log(this.activatedRoute.snapshot.data['preFetchData']);
  }

}
