import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { StudentListsComponent } from './lists/student-lists/student-lists.component';
import { TeachersListsComponent } from './lists/teachers-lists/teachers-lists.component';
import { CoursesListsComponent } from './lists/courses-lists/courses-lists.component';
import { StudentDetailsComponent } from './students/student-details/student-details.component';
import { TeacherDetailsComponent } from './teachers/teacher-details/teacher-details.component';
import { MessagesComponent } from './messages/messages.component';
import { CourseDetailsComponent } from './courses/course-details/course-details.component';
import { TestComponent } from './test/test.component';
import { ToastrModule } from 'ngx-toastr';
@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
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
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass:'toast-bottom-right'
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
