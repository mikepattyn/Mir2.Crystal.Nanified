import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Event } from '@angular/router';
import { ITableViewModel } from '../database-reflection-resolver';
declare let $: any

@Component({
  selector: 'app-explorer',
  templateUrl: './explorer.component.html',
  styleUrls: ['./explorer.component.css']
})
export class ExplorerComponent implements OnInit, AfterViewInit {
  public tables: ITableViewModel[] = [];
  public selectedTable: ITableViewModel | null = null;
  constructor(private activatedRoute: ActivatedRoute) {

  }

  ngOnInit(): void {
    this.tables = this.activatedRoute.snapshot.data['preFetchData'];
    this.selectedTable = this.tables[0]
    if (this.activatedRoute.snapshot.queryParams["tableName"])
      this.selectedTable = this.tables[this.tables.findIndex(x=>x.Name == this.activatedRoute.snapshot.queryParams["tableName"])];
    console.log(this.activatedRoute.snapshot.queryParams);
  }
  ngAfterViewInit() {
    $('#table1').DataTable();
    console.log($('#tableCard')[0].children[0].children[0]);
  }

  tableNameClicked(e: any) {
  console.log(e);
    console.log(this.activatedRoute.snapshot.queryParams);
    if (this.activatedRoute.snapshot.queryParams["tableName"])
      this.selectedTable = this.tables[this.tables.findIndex(x=>x.Name == this.activatedRoute.snapshot.queryParams["tableName"])];
    this.ngOnInit();
  }
}
