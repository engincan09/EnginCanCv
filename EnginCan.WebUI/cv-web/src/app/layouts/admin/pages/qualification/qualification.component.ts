import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DataStatus } from 'src/app/shared/models/base-entity.model';
import { ConfirmationDialogService } from 'src/app/shared/services/confirmation-dialog.service';
import { CustomvalidationService } from 'src/app/shared/services/custom-validation.service';
import { environment } from 'src/environments/environment';
import {
  Qualification,
  QualificationType,
  QualificationTypeDataSource,
} from './models/qualification.model';
import { QualificationService } from './services/qualification.service';
declare var $;

@Component({
  selector: 'app-qualification',
  templateUrl: './qualification.component.html',
  styleUrls: ['./qualification.component.scss'],
})
export class QualificationComponent implements OnInit {
  qualification: Qualification = new Qualification();
  environment = environment;
  submitted = false;
  qualificationForm: FormGroup;
  qualificationId: number;
  qualifications: any[] = [];
  qualificationTypeDataSource = QualificationTypeDataSource;
  types = Object.values(QualificationType).filter((k) => !isNaN(Number(k)));

  constructor(
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private qualificationService: QualificationService,
    private activatedRoute: ActivatedRoute,
    private route: ActivatedRoute,
    private router: Router,
    private customValidator: CustomvalidationService,
    public datepipe: DatePipe,
    private confirmationDialogService: ConfirmationDialogService
  ) {}

  ngOnInit() {
    this.createQualificationAddForm();
    this.uploadData();
  }

  get formControl() {
    return this.qualificationForm.controls;
  }

  saveQualification() {
    this.submitted = true;
    if (this.qualificationForm.valid) {
      let model: Qualification = Object.assign(
        {},
        this.qualificationForm.value
      );
      model.dataStatus = DataStatus[DataStatus.Activated];
      if (this.qualification.id) {
        this.updateQualification(model);
      } else {
        this.addQualification(model);
      }
    } else {
      this.toastr.error('Zorunlu alanları kontrol ediniz!', 'Hata');
    }
  }

  addQualification(model) {
    this.qualificationService.postQualification(model).subscribe((res) => {
      if (res.success) {
        this.uploadData();
        this.toastr.success(res.messages, 'Başarılı!');
      } else {
        this.toastr.error(res.messages, 'Hata!');
      }
    });
  }
  updateQualification(model) {
    this.qualificationService.updateQualification(model).subscribe((res) => {
      if (res.success) {
        this.uploadData();
        this.toastr.success(res.messages, 'Başarılı!');
      } else {
        this.toastr.error(res.messages, 'Hata!');
      }
    });
  }

  createQualificationAddForm() {
    this.qualificationForm = this.formBuilder.group({
      qualificationType: ['', Validators.required],
      donem: ['', Validators.required],
      baslik: ['', Validators.required],
      bolum: ['', Validators.required],
      aciklama: ['', Validators.required],
    });
  }

  createQualificationUpdateForm(id: number) {
    this.qualificationForm = this.formBuilder.group({
      id: id,
      qualificationType: ['', Validators.required],
      donem: ['', Validators.required],
      baslik: ['', Validators.required],
      bolum: ['', Validators.required],
      aciklama: ['', Validators.required],
    });
  }

  getQualification(id: number) {
    this.qualificationService.getQualification(id).subscribe((res) => {
      this.qualification = res.data;
      this.createQualificationUpdateForm(this.qualification.id);
    });
  }

  delete(id) {
    if (id) {
      this.confirmationDialogService
        .confirm(
          'İşlem Onayı',
          'Tecrübe/Eğitimi silmek istediğinize emin misiniz ?'
        )
        .then((confirmed) => {
          if (confirmed) {
            this.qualificationService
              .deleteQualification(id)
              .subscribe((res) => {
                this.uploadData();
              });
          }
        });
    }
  }
  uploadData() {
    var self = this;
    this.qualificationService.getAllQualification().subscribe((res) => {
      this.qualifications = res.data;
      $('#jsGrid1').jsGrid({
        width: '100%',
        height: 300,
        sorting: true,
        paging: true,
        pageSize: 10,
        pageButtonCount: 5,
        deleteConfirm: 'Tecrübe/Eğitimi silmek istediğinize emin misiniz?',
        inserting: false,
        editing: false,
        data: this.qualifications,
        viewrecords: true,
        gridview: true,
        autoencode: true,
        loadonce: true,
        fields: [
          {
            type: 'control',
            width: 60,
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
                  self.getQualification(item.id);
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
            name: 'baslik',
            type: 'text',
            width: 150,
            title: 'Tecrüve/Eğitim Başlığı',
            autosearch: true,
          },
          {
            name: 'qualificationType',
            type: 'text',
            width: 150,
            title: 'Tip',
            autosearch: true,
            itemTemplate: function (value, item) {
              switch (item.qualificationType) {
                case QualificationType[QualificationType.Job]:
                  return 'İş Deneyimi';
                case QualificationType[QualificationType.Education]:
                  return 'Eğitim';
                default:
                  break;
              }
            },
          },
          {
            name: 'donem',
            type: 'text',
            width: 150,
            title: 'Dönem',
            autosearch: true,
          },
          { name: 'aciklama', type: 'text', width: 150, title: 'Açıklama' },
        ],
      });
    });
  }
}
