import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ToastrModule } from 'ngx-toastr';
import { StudentListsComponent } from '../lists/student-lists/student-lists.component';
import { TeachersListsComponent } from '../lists/teachers-lists/teachers-lists.component';
import { CoursesListsComponent } from '../lists/courses-lists/courses-lists.component';
import { StudentDetailsComponent } from '../students/student-details/student-details.component';
import { TeacherDetailsComponent } from '../teachers/teacher-details/teacher-details.component';
import { MessagesComponent } from '../messages/messages.component';
import { CourseDetailsComponent } from '../courses/course-details/course-details.component';
import { TestComponent } from '../test/test.component';



@NgModule({
  declarations: [
    StudentListsComponent,
    TeachersListsComponent,
    CoursesListsComponent,
    StudentDetailsComponent,
    TeacherDetailsComponent,
    MessagesComponent,
    CourseDetailsComponent,
    TestComponent
  ],
  imports: [
    CommonModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass:'toast-bottom-right'
    })
  ],
  exports: [
    BsDropdownModule,
    ToastrModule
  ]
})
export class SharedModule { }
