import { QualificationService } from './../../admin/pages/qualification/services/qualification.service';
import { Component, OnInit } from '@angular/core';
import { Qualification, QualificationType } from './models/qualification.model';

@Component({
  selector: 'in-qualification',
  templateUrl: './qualification.component.html',
  styleUrls: ['./qualification.component.css'],
})
export class QualificationComponent implements OnInit {
  data: Qualification[] = [];
  jobList: Qualification[] = [];
  educationList: Qualification[] = [];
  constructor(private qualificationService: QualificationService) {}

  ngOnInit() {
    this.getAllQualification();
  }

  getAllQualification() {
    this.qualificationService.getAllQualification().subscribe((res) => {
      this.data = res.data;
      this.educationList = this.data.filter(
        (m) =>
          m.qualificationType === QualificationType[QualificationType.Education]
      );
      this.jobList = this.data.filter(
        (m) => m.qualificationType === QualificationType[QualificationType.Job]
      );
    });
  }
}
