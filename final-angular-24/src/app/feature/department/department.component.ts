import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { FormGroup, FormControl } from '@angular/forms';
import { DepartmentService } from 'src/app/service/department.service';
import { ToastrService } from 'ngx-toastr';
import { AlertService } from 'src/app/alert/alert.service';
declare const $:any;
@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css'],
})
export class DepartmentComponent implements OnInit, OnDestroy {
  departmentList: any;
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject<any>();

  departmentForm = new FormGroup({
    departmentId: new FormControl(''),
    departmentNameKh: new FormControl(''),
    departmentNameEn: new FormControl(''),
    isActive: new FormControl(''),
    createBy: new FormControl('0'),
  });
  //end form group

  // Button ave update delete
  departmentVisible: boolean = false;
  btnSave: boolean = false;
  btnUpdate: boolean = false;
  btnDelete: boolean = false;
  //end buttom
  constructor(
    private departmentSerive: DepartmentService,
    private toastr: AlertService
  ) {}

  ngOnInit(): void {
    this.getDepartment(); // form  load


  }
  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }
  getDepartment() {

    if ($.fn.dataTable.isDataTable('#dtdepartment')){
      $('#dtdepartment').dataTable().fnDestroy();
    }
    this.dtOptions = {
      pagingType: 'full_numbers',
      searching: true,
      lengthChange: false,
      language: {
        searchPlaceholder: 'ស្វែងរក',
      },
    };

    this.departmentSerive.getDepartment().subscribe((res) => {
      this.departmentList = res;
      this.dtTrigger.next(null);
      console.log(res);
    });
  }

  // button group save/delete/update
  buttonVisible(save: boolean, edite: boolean, remove: boolean) {
    if (save === true) {
      this.btnSave = true;
      this.departmentVisible = false;
    } else {
      this.departmentVisible = true;
    }
    this.btnSave = save;
    this.btnUpdate = edite;
    this.btnDelete = remove;
  }

  //Button view condition
  ViewDapartmnt(departmentId: number, cud: number) {
    if (cud === 1) {
      //view
      this.buttonVisible(false, false, false);
    } else if (cud === 2) {
      //edit
      this.buttonVisible(false, true, false);
    } else if (cud === 3) {
      //delete
      this.buttonVisible(false, false, true);
    }
    this.departmentSerive.getDartmentById(departmentId).subscribe((res) => {
      console.log(res);
      //  view form controll
      this.departmentForm = new FormGroup({
        departmentId: new FormControl(res.departmentId),
        departmentNameKh: new FormControl(res.departmentNameKh),
        departmentNameEn: new FormControl(res.departmentNameEn),
        isActive: new FormControl(res.isActive),
        createBy: new FormControl('0'),
      });
    });
  }
  //end View condition

  // do messagwe
  DoMessage(status: string, message: string) {
    if (status === 'Succeed') {
      this.getDepartment();
      document.getElementById('btnClose')?.click(); //Close form when save it
    }
    this.toastr.toastMessage(status, message);
  }
  //end message

  //Add New Department/ Save
  addNewDepartment() {
    this.buttonVisible(true, false, false);
  }
  //Save Department
  SaveDepartment() {
    this.departmentForm.value.departmentId = '0';
    this.departmentSerive
      .saveDepartment(this.departmentForm.value)
      .subscribe((res) => {
        this.DoMessage(res.status, res.message);
        /*if (res.status === 'Succeed') {
          this.getDepartment();
          this.toastr.toastMessage(res.status, res.message); //alert toast
          document.getElementById('btnClose')?.click(); //Close form when save it
        } else {
          this.toastr.toastMessage(res.status, res.message);
        }
        */
      });
    // console.log(this.departmentForm.value);
  }
  //end Save Department

  // Update

  UpdateDepartment() {
    this.departmentSerive
      .editDepartment(this.departmentForm.value)
      .subscribe((res) => {
        this.DoMessage(res.status, res.message);
      });
  }
  //End Update

  // delete
  DeleteDepartment() {
    this.departmentSerive
      .deleteDepartment(this.departmentForm.value)
      .subscribe((res) => {
        this.DoMessage(res.status, res.message);
      });
  }
  //end delete
}
