import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { AlertService } from 'src/app/alert/alert.service';
import { AddressService } from 'src/app/service/address.service';
import { DepartmentService } from 'src/app/service/department.service';
import { EducationService } from 'src/app/service/education.service';
import { EmployeeService } from 'src/app/service/employee.service';
import { MajorService } from 'src/app/service/major.service';
import { PositionService } from 'src/app/service/position.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css'],
})
export class EmployeeComponent implements OnInit {
  employeeForm = new FormGroup({
    employeeId: new FormControl(''),
    employeeNameKh: new FormControl(''),
    employeeNameEn: new FormControl(''),
    gender: new FormControl(''),
    positionId: new FormControl(''),
    departmentId: new FormControl(''),
    villageId: new FormControl(''),
    createBy: new FormControl('0'),

   
  });

  employeeExperiencesForm = new FormGroup({
    employeeExperiendId: new FormControl(0),
    position: new FormControl(''),
    salary: new FormControl('0'),
    dateJoin: new FormControl(''),
    dateResign: new FormControl(''),
  });

  employeeEducationForm = new FormGroup({
    employeeEducationId: new FormControl(0),
    educationLevelId: new FormControl(0),
    eduactionLevelText: new FormControl(''),
    majorText: new FormControl(''),
    majorId: new FormControl(0),
    schoolName: new FormControl(''),
    yearStart: new FormControl(''),
    yearEnd: new FormControl(''),
  })

  departmentList: any;
  positionList: any;
  provineList: any;
  districkList: any;
  commueList: any;
  villageList: any;
  employeeExperiencesList :any = [];
  educatonLevelList:any;
  majorList:any;
  employeeList:any;


  employeeExperiendId:any=[];
  employeEudcationList:any = [];
  eduactionLevelText:any ='';
  majorText:any ='';

  employeeExperienceRequests: any = [];


  constructor(
    private departmentSerivce: DepartmentService,
    private posistionService: PositionService,
    private alert: AlertService,
    private addSerivce: AddressService,
    private educationService: EducationService,
    private majorSerivce: MajorService,
    private emloyeeService: EmployeeService
  ) {}

  ngOnInit(): void {
    this.getDepartment();
    this.getPostition();
    this.getAddresses('P', '0');
    this.getEducation();
    this.getMajor();
    this.getEmployeeList();
    
  }

  
  getEducation() {
    this.educationService.getEducation().subscribe((res) => {
      if (res.status === 'Succeed') {
        this.educatonLevelList = res.edu;
      }
    });
  }

  getMajor() {
    this.majorSerivce.getMajor().subscribe((res) => {
      if (res.status === 'Succeed') {
        this.majorList = res.major;
      }
    });
  }

  getDepartment() {
    this.departmentSerivce.getDepartment().subscribe((res) => {
      this.departmentList = res;
    });
  }



  getPostition() {
    this.posistionService.getPosition().subscribe((res) => {
      if (res.status === 'Succeed') {
        this.positionList = res.position;
      }
    });
  }

  getAddresses(PDCV: string, parentId: any) {
    this.addSerivce.getAddresses(parentId).subscribe((res) => {
      if (res.status === 'Succeed') {
        if (PDCV === 'P') {
          this.provineList = res.address;
        } else if (PDCV === 'D') {
          this.districkList = res.address;
        } else if (PDCV === 'C') {
          this.commueList = res.address;
        } else if (PDCV === 'V') {
          this.villageList = res.address;
        }
      }
    });
  }

  onChangeProvine(event: any) {
    let provineId = event.target.selectedOptions[0].value;
    this.getAddresses('D', provineId);
    this.alert.toastMessage('Succeed', provineId);
  }
  districkChange(event: any) {
    let districkId = event.target.selectedOptions[0].value;
    this.getAddresses('C', districkId);
    this.alert.toastMessage('Succeed', districkId);
  }
  commueChange(event: any) {
    let commueId = event.target.selectedOptions[0].value;
    this.getAddresses('V', commueId);
    this.alert.toastMessage('Succeed', commueId);
  }


  //button AddExperience()
  AddExperience(){

    let expExist = this.employeeExperiencesList
    .filter((x: {position:any})=>x.position  === this.employeeExperiencesForm.value.position)
    if(expExist.length===1){
      this.alert.toastMessage("Error","This posistion existed")
    }else{
    this.employeeExperiencesList.push(this.employeeExperiencesForm.value);
  }

  }

  RemoveExper(position:any){
    let i = this.employeeExperiencesList.findIndex((x: {position:any})=>x.position ===position);
    this.employeeExperiencesList.splice(i,1);
  }

  AddEducation(){

    let expExist = this.employeEudcationList
    .filter((x: {educationLevelId:any})=>x.educationLevelId  === this.employeeEducationForm.value.educationLevelId)
    if(expExist.length===1){
      this.alert.toastMessage("Error","This posistion existed")
    }else{
      this.employeeEducationForm.value.eduactionLevelText = this.eduactionLevelText;
      this.employeeEducationForm.value.majorText = this.majorText;
    this.employeEudcationList.push(this.employeeEducationForm.value);
  }

  }

  RemoveEducation(educationLevelId: any){
    let i = this.employeEudcationList.findIndex((x: {educationLevelId:any})=>x.educationLevelId ===educationLevelId);
    this.employeEudcationList.splice(i,1);
  }

  onEducationChange(event:any){

    this. eduactionLevelText= event.target.selectedOptions[0].text;
    console.log(this.eduactionLevelText);
  }

  onMajorChange(event:any){
    this. majorText= event.target.selectedOptions[0].text;
    console.log(this.majorText);
  }

  getEmployeeList(){
    this.emloyeeService.getEmployee().subscribe((res)=>{
      if (res.status === 'Succeed') {
        this.employeeList = res.exp;
      }
    })
  }

  SaveEmployee(){
    let emp = this.employeeForm.value;

    let data={
    employeeId: emp.employeeId,
    employeeNameKh:emp.employeeNameKh,
    employeeNameEn: emp.employeeNameEn,
    gender: emp.gender,
    positionId:emp.positionId,
    departmentId:emp.departmentId,
    villageId:emp.villageId,
    createBy: emp.createBy,
    employeeExperienceRequests:   this.employeeExperiencesList,
    employeeEductionRequests:   this.employeEudcationList,
    };
    this.emloyeeService.addEmployee(data).subscribe((res)=>{
      if(res.status==="Succeed"){
        this.getEmployeeList();
       
      }
      this.alert.toastMessage(res.status,res.message);
    });
  
  }

}
