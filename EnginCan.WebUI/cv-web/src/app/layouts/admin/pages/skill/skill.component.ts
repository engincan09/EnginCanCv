import { Skill } from './models/skill.component';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { SkillService } from './services/skill.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomvalidationService } from 'src/app/shared/services/custom-validation.service';
import { ToastrService } from 'ngx-toastr';
import { DatePipe } from '@angular/common';
import { DataStatus } from 'src/app/shared/models/base-entity.model';
import { ConfirmationDialogService } from 'src/app/shared/services/confirmation-dialog.service';
declare var $;
@Component({
  selector: 'app-skill',
  templateUrl: './skill.component.html',
  styleUrls: ['./skill.component.scss']
})
export class SkillComponent implements OnInit {
  skill: Skill = new Skill();
  environment = environment;
  submitted = false;
  skillForm: FormGroup;
  skillId: number;
  skills: any[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private skillService: SkillService,
    private activatedRoute: ActivatedRoute,
    private route: ActivatedRoute,
    private router: Router,
    private customValidator: CustomvalidationService,
    public datepipe: DatePipe,
    private confirmationDialogService: ConfirmationDialogService
  ) {}

  ngOnInit() {
    this.createSkillAddForm();
    this.uploadData();
  }
  get formControl() {
    return this.skillForm.controls;
  }
  saveSkill() {
    this.submitted = true;
    if (this.skillForm.valid) {
      let model: Skill = Object.assign({}, this.skillForm.value);
      model.dataStatus = DataStatus[DataStatus.Activated];
      if (this.skill.id) {
        this.updateSkill(model);
      } else {
        this.addSkill(model);
      }
    } else {
      this.toastr.error('Zorunlu alanları kontrol ediniz!', 'Hata');
    }
  }

  
  addSkill(model) {
    this.skillService.postSkill(model).subscribe((res) => {
      if (res.success) {
        this.uploadData();
        this.toastr.success(res.messages, 'Başarılı!');
      } else {
        this.toastr.error(res.messages, 'Hata!');
      }
    });
  }
  updateSkill(model) {
    this.skillService.updateSkill(model).subscribe((res) => {
      if (res.success) {
        this.uploadData();
        this.toastr.success(res.messages, 'Başarılı!');
      } else {
        this.toastr.error(res.messages, 'Hata!');
      }
    });
  }

  createSkillAddForm() {
    this.skillForm = this.formBuilder.group({
      ad: ['', Validators.required],
      oran: ['', Validators.required],
    });
  }

  createSkillUpdateForm() {
    this.skillForm = this.formBuilder.group({
      id: this.skillId,
      ad: ['', Validators.required],
      oran: ['', Validators.required],
    });
  }

  getSkill(aboutId: number) {
    this.skillService.getSkill(aboutId).subscribe((res) => {
      this.skill = res.data;
    });
  }

  delete(id) {
    if (id) {
      this.confirmationDialogService
        .confirm('İşlem Onayı', 'Kullanıcı silmek istediğinize emin misiniz ?')
        .then((confirmed) => {
          if (confirmed) {
            this.skillService.deleteSkill(id).subscribe((res) => {
              this.uploadData();
            });
          }      
        });
    }
  }
  uploadData() {
    var self = this;
    this.skillService.getAllSkill().subscribe((res) => {
      this.skills = res.data;
      $('#jsGrid1').jsGrid({
        width: '100%',
        height: 300,
        sorting: true,
        paging: true,
        pageSize: 10,
        pageButtonCount: 5,
        deleteConfirm: 'Yeteneği silmek istediğinize emin misiniz?',
        inserting: false,
        editing: false,
        data: this.skills,
        viewrecords: true,
        gridview: true,
        autoencode: true,
        loadonce: true,
        fields: [
          {
            type: 'control',
            width: 40,
            editButton: false,
            deleteButton: false,
            title: 'İşlemler',
            itemTemplate: function (value, item) {
              var $iconPencil = $('<i>').attr({ class: 'fa fa-pencil p-2' });
              var $iconTrash = $('<i>').attr({ class: 'fa fa-trash p-2' });
  
              var $customEditButton = $('<button>')
                .attr({
                  class:
                    'btn btn-warning btn-xs mr-2 d-flex justify-content-center',
                })
                .attr({ role: 'button' })
                .attr({ title: 'Düzenle' })
                .attr({ id: 'btn-edit-' + item.id })
                .click((e) => {
                  self.getSkill(item.id);
                })
                .append($iconPencil);
  
              var $customDeleteButton = $('<button>')
                .attr({ class: 'btn btn-danger btn-xs' })
                .attr({ role: 'button' })
                .attr({ title: 'Sil' })
                .attr({ id: 'btn-delete-' + item.id })
                .click(function (e) {
                  self.delete(item.id);
                })
                .append($iconTrash);
  
              return $('<div>')
                .attr({ class: 'btn-toolbar' })
                .append($customEditButton)
                .append($customDeleteButton);
            },
          },
          {
            name: 'ad',
            type: 'text',
            width: 150,
            title: 'Yetenek Adı',
            autosearch: true,
          },
          { name: 'oran', type: 'text', width: 150, title: 'Oran' },
        ],
      });
    });
  
  
  }

}
