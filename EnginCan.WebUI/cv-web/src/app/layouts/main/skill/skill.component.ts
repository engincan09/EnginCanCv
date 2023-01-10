import { Component, OnInit } from '@angular/core';
declare var $: any;


@Component({
  selector: 'in-skill',
  templateUrl: './skill.component.html',
  styleUrls: ['./skill.component.css']
})
export class SkillComponent implements OnInit {

  constructor() { }

  ngOnInit() {
        // Skills
        $('.skill').waypoint(
          function () {
            $('.progress .progress-bar').each(function () {
              $(this).css('width', $(this).attr('aria-valuenow') + '%');
            });
          },
          { offset: '80%' }
        );
  }

}
