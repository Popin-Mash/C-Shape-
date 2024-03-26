import {Component, OnDestroy, OnInit} from '@angular/core';
import {PositionService} from "../../service/position.service";
import { Subject } from 'rxjs';
import { FormGroup, FormControl } from '@angular/forms';
import { AlertService } from 'src/app/alert/alert.service';

declare const $:any;
@Component({
  selector: 'app-position',
  templateUrl: './position.component.html',
  styleUrls: ['./position.component.css']
})
export class PositionComponent implements  OnInit,OnDestroy{

  positionList:any;
  positionID:any =0;
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject<any>();

  positionForm = new FormGroup({
    positionId: new FormControl(''),
    positionNameKh: new FormControl(''),
    positionNameEn: new FormControl(''),
    isAvtive: new FormControl(''),
    createBy: new FormControl(''),
  });

  //Button
  positionIdVisible: boolean = false;
  btnSave: boolean = false;
  btnUpdate: boolean = false;
  btnDelete: boolean = false;
  //End

  constructor(private positionService :PositionService,
        private alert : AlertService
    ) {
  }


  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }

  ngOnInit(): void {
    this.getPosition();
  }

  getPosition(){
    if ($.fn.dataTable.isDataTable('#dtposition')){
      $('#dtposition').dataTable().fnDestroy();
    }
      this.dtOptions = {
        pagingType: 'full_numbers',
        searching: true,
        lengthChange: false,
        language:{
          searchPlaceholder: 'Search Position'
        },
      };
    

    this.positionService.getPosition().subscribe((res)=>{
      if (res.status === "Succeed"){
        this.positionList = res.position;
        this.dtTrigger.next(null);
      }
    });
  }

    // button group save/delete/update
    buttonVisible(save: boolean, edite: boolean, remove: boolean) {
      if (save === true) {
        this.btnSave = true;
        this.positionIdVisible = false;
      } else{
        this.positionIdVisible= true;
      }
   
      this.btnSave = save;
      this.btnUpdate = edite;
      this.btnDelete = remove;
  
    }

    // getPositionById(positionId: number,cud: number){
    //   this.positionService.getPositionById(positionId).subscribe((res)=>{
    //     if(res.status === "Succeed"){
    //       this.positionForm  = new FormGroup({
    //         positionId: new FormControl(res?.positionId[0]?.positionId),
    //         positionNameKh: new FormControl(res?.positionNameKh[0]?.positionNameKh),
    //         positionNameEn: new FormControl(res?.positionNameEn[0]?.positionNameEn),
    //         isAvtive: new FormControl(res.positionId[0]?.isAvtive),
    //         createBy: new FormControl('0'),
    //       });
    //     }
    //   });
    getPositionById(positionId: number, cud: number) {
      this.positionService.getPositionById(positionId).subscribe((res) => {
        if (res.status === "Succeed") {
          this.positionForm = new FormGroup({
            positionId: new FormControl(res.positionId[0].positionId),
            positionNameKh: new FormControl(res.positionNameKh[0].positionNameKh),
            positionNameEn: new FormControl(res.positionNameEn[0].positionNameEn),
            isAvtive: new FormControl(res.positionId[0].isAvtive), // Corrected spelling
            createBy: new FormControl('0'),
          });
        }
      });
    
      
    
    
      if(cud ===1){
        this.buttonVisible(false,false,false);
      }else if(cud ===2){
        this.buttonVisible(false,true,false);
      } else if(cud ===3){
        this.buttonVisible(false,false,true);
      }
    }

  // Add New Position data
    AddnewPosition(){
        this.buttonVisible(true,false,false)
    }


    CUDPosition(CUD:string){
      
      if(CUD === "U" || CUD === "D" ){
        this.positionID=this.positionForm.value.positionId;
       }
      let data ={
        positionId: this.positionID,
        positionNameKh:this.positionForm.value.positionNameKh,
        positionNameEn: this.positionForm.value.positionNameEn,
        isAvtive: this.positionForm.value.isAvtive,
        createBy: "1",
        cud: CUD
      };
     
      this.positionService.cudPosition(data).subscribe((res)=>{
          if(res.status === "Succeed"){
            document.getElementById("btnClose")?.click();
            this.getPosition();
          }
          this.alert.toastMessage(res.status,res.message);
      });
      console.log(data);
    }

 


}
