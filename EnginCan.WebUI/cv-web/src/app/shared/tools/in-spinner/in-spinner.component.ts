import { LoadingService } from './../../services/loading.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'in-spinner',
  templateUrl: './in-spinner.component.html',
  styleUrls: ['./in-spinner.component.css']
})
export class InSpinnerComponent implements OnInit {

  constructor(public loader: LoadingService) { }


  ngOnInit() {
  }

}
