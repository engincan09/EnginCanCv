import { ContactService } from './services/contact.service';
import { Component, OnInit } from '@angular/core';
import { ConfirmationDialogService } from 'src/app/shared/services/confirmation-dialog.service';
import { ResponseDto } from './dtos/response.dto';
import { ToastrService } from 'ngx-toastr';
declare var $;
@Component({
  selector: 'app-iletisim-talepleri',
  templateUrl: './iletisim-talepleri.component.html',
  styleUrls: ['./iletisim-talepleri.component.css'],
})
export class IletisimTalepleriComponent implements OnInit {
  contacts: any[] = [];
  displayDialog:boolean = false;
  header:string;
  responseDto:ResponseDto = new ResponseDto();
  constructor(
    private contactService: ContactService,
    private confirmationDialogService: ConfirmationDialogService,
    private toastr: ToastrService,
  ) {}

  ngOnInit() {
    this.uploadData();
  }

  uploadData() {
    var self = this;
    this.contactService.getAllContact().subscribe((res) => {
      this.contacts = res.data;
      $('#jsGrid1').jsGrid({
        width: '100%',
        height: 300,
        sorting: true,
        paging: true,
        pageSize: 10,
        pageButtonCount: 5,
        deleteConfirm: 'İletişim talebini silmek istediğinize emin misiniz?',
        inserting: false,
        editing: false,
        data: this.contacts,
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
                  self.displayDialog = true;
                  self.header = item.fullName;
                  self.responseDto.contactId = item.id;
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
            name: 'createdAt',
            title: 'Mesaj Tarihi',
            sortable: true,
            type: 'date',
            format: 'dd/mm/yyyy',
          },
          {
            name: 'fullName',
            type: 'text',
            width: 150,
            title: 'Ad Soyad',
            autosearch: true,
          },
          {
            name: 'email',
            type: 'text',
            width: 150,
            title: 'Mail',
            autosearch: true,
          },
          {
            name: 'subject',
            type: 'text',
            width: 150,
            title: 'Konu',
            autosearch: true,
          },
          { name: 'message', type: 'text', width: 150, title: 'Mesaj' },
          {
            name: 'isResponse',
            type: 'text',
            width: 30,
            title: 'Cevap Verildi',
            autosearch: true,
            itemTemplate: function (value, item) {
              if (item.isResponse) {
                return 'Evet';
              } else {
                return 'Hayır';
              }
            },
          },
        ],
      });
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
            this.contactService.deleteContact(id).subscribe((res) => {
              this.uploadData();
            });
          }
        });
    }
  }

  postResponse(){
    this.contactService.postResponse(this.responseDto).subscribe((res)=>{
      if (res.success) {
        this.toastr.success(res.messages, 'Başarılı!');
        this.displayDialog = false;
        this.responseDto = new ResponseDto();
      } else {
        this.toastr.error(res.messages, 'Hata!');
        this.displayDialog = false;
        this.responseDto = new ResponseDto();
      }
    });
    
  }
}
