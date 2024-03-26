import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DepartmentComponent } from './feature/department/department.component';
import { PositionComponent } from './feature/position/position.component';
import { EmployeeComponent } from './feature/employee/employee.component';




const routes: Routes = [
  {
    path: 'department',
    component: DepartmentComponent
  },
  {
    path: 'position',
    component: PositionComponent
  },
  {
    path: 'employee',
    component: EmployeeComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
