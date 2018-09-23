import { Component, OnInit, ViewChild } from '@angular/core';
import { InfoService } from './info.service';
import DataSource from 'devextreme/data/data_source';
import { DxDataGridComponent } from 'devextreme-angular';
import {Router, ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.css']
})
export class InfoComponent implements OnInit {
  @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent;

  dataSource: DataSource;
  value = {};

  constructor(
    public service: InfoService,
    private route: ActivatedRoute,

  ) { }

  ngOnInit() {
    this.dataSource = new DataSource([]);

    this.service.fetch(this.route.snapshot.params.id);
    this.service.data$.subscribe((data) => {
      this.dataSource = new DataSource(data);
    })

    this.service.info$.subscribe((data) => {
      this.value = data;
    })
  }

}
