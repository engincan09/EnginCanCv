import { Skill } from './models/skill.model';
import { Component, OnInit } from '@angular/core';
import { SkillService } from './services/skill..service';
declare var $: any;
declare var Waypoint: any;


@Component({
  selector: 'in-skill',
  templateUrl: './skill.component.html',
  styleUrls: ['./skill.component.css'],
})
export class SkillComponent implements OnInit {
  skills: Skill[] = [];
  aboutId: number;
  constructor(private skillService: SkillService) {}

  ngOnInit() {
    this.getAllSkills();
    // Skills
    let skilsContent = $('.skills-content') //select('.skills-content');
    if (skilsContent) {
      new Waypoint({
        element: skilsContent,
        offset: '80%',
        handler: function(direction) {
          let progress =$('.progress .progress-bar');
          progress.forEach((el) => {
            el.style.width = el.getAttribute('aria-valuenow') + '%'
          });
        }
      })
    }
  }
  getAllSkills() {
    this.skillService.getAllSkills().subscribe((res) => {
      this.skills = res.data;
    });
  }
}
