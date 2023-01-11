import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CustomvalidationService } from 'src/app/shared/services/custom-validation.service';
import { environment } from 'src/environments/environment';
import { About } from './models/about.model';
import { AboutService } from './services/about.service';
import { DatePipe, formatDate } from '@angular/common';
import { DataStatus } from 'src/app/shared/models/base-entity.model';
import { UploadImage } from './dtos/image-upload.dto';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss'],
  providers: [DatePipe],
})
export class AboutComponent implements OnInit {
  about: About = new About();
  environment = environment;
  submitted = false;
  aboutForm: FormGroup;
  aboutId: number;
  imageBaseData: string | ArrayBuffer = null;
  constructor(
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private aboutService: AboutService,
    private activatedRoute: ActivatedRoute,
    private route: ActivatedRoute,
    private router: Router,
    private customValidator: CustomvalidationService,
    public datepipe: DatePipe
  ) {}

  ngOnInit() {
    this.aboutId = 1;
    this.getAbout(this.aboutId);
    this.createAboutUpdateForm();
  }

  get formControl() {
    return this.aboutForm.controls;
  }

  saveAbout() {
    this.submitted = true;
    if (this.aboutForm.valid) {
      let model: About = Object.assign({}, this.aboutForm.value);
      console.log(model, 'md');

      model.dogumTarih = new Date(model.dogumTarih);
      model.dataStatus = DataStatus[DataStatus.Activated];
      if (this.about.id) {
        this.updateAbout(model);
      } else {
        this.addAbout(model);
      }
    } else {
      this.toastr.error('Zorunlu alanları kontrol ediniz!', 'Hata');
    }
  }

  addAbout(model) {
    this.aboutService.postAbout(model).subscribe((res) => {
      if (res.success) {
        this.toastr.success(res.messages, 'Başarılı!');
      } else {
        this.toastr.error(res.messages, 'Hata!');
      }
    });
  }
  updateAbout(model) {
    this.aboutService.updateAbout(model).subscribe((res) => {
      if (res.success) {
        this.toastr.success(res.messages, 'Başarılı!');
      } else {
        this.toastr.error(res.messages, 'Hata!');
      }
    });
  }

  createAboutAddForm() {
    this.aboutForm = this.formBuilder.group({
      fullName: ['', Validators.required],
      dogumTarih: ['', Validators.required],
      mezuniyetDurum: ['', Validators.required],
      deneyimSuresi: ['', Validators.required],
      email: ['', Validators.required],
      ozetMetin: ['', [Validators.required]],
      altAciklama: ['', [Validators.required]],
      yas: ['', [Validators.required]],
      url: ['', [Validators.required]],
      sehir: ['', [Validators.required]],
      photo: [''],
    });
  }

  createAboutUpdateForm() {
    this.aboutForm = this.formBuilder.group({
      id: this.aboutId,
      fullName: ['', Validators.required],
      dogumTarih: ['', Validators.required],
      mezuniyetDurum: ['', Validators.required],
      deneyimSuresi: ['', Validators.required],
      email: ['', Validators.required],
      ozetMetin: ['', [Validators.required]],
      altAciklama: ['', [Validators.required]],
      yas: ['', [Validators.required]],
      url: ['', [Validators.required]],
      sehir: ['', [Validators.required]],
      photo: [''],
    });
  }

  getAbout(aboutId: number) {
    this.aboutService.getAbout(aboutId).subscribe((res) => {
      this.about = res.data;
      this.about.dogumTarih = new Date(this.about.dogumTarih);
    });
  }

  handleFileInput(files: FileList) {
    let me = this;
    let file = files[0];
    let reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
      me.aboutForm.patchValue({ photo: reader.result.toString() });

      me.about.photo = reader.result.toString();
    };
    reader.onerror = function (error) {
      console.log('Error: ', error);
    };
  }
}
