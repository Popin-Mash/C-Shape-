import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor(private tosat: ToastrService) { }
  toastMessage(status: string,message:string){
      if(status === "Succeed"){
        this.tosat.success(message,"Message");
      }else if(status=== "Error"){
        this.tosat.error(message,"Message");
      }else{
        this.tosat.warning(message,"Message");
      }
  } 
}
