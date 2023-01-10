import { Component, OnInit } from '@angular/core';
import Typed from 'typed.js';
declare var $: any;
@Component({
  selector: 'in-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    // Typed Initiate
    if ($('.typed').length == 1) {
      var typed_strings = $('.typed').attr('data-typed-items');
      var typed = new Typed('.typed', {
        strings: typed_strings.split(', '),
        typeSpeed: 100,
        backSpeed: 20,
        smartBackspace: false,
        loop: true,
      });
    }
  }

}
