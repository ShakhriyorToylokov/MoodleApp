import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { SharedModule } from './_modules/shared.module';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { ErrorInterceptor } from './_inteceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { JwtInterceptor } from './_inteceptors/jwt.interceptor';
import { CoursesListsComponent } from './lists/courses-lists/courses-lists.component';
import { StudentDetailsComponent } from './students/student-details/student-details.component';
import { TeacherDetailsComponent } from './teachers/teacher-details/teacher-details.component';
import { StudentListsComponent } from './lists/student-lists/student-lists.component';
import { TeachersListsComponent } from './lists/teachers-lists/teachers-lists.component';
import { MessagesComponent } from './messages/messages.component';
import { CourseDetailsComponent } from './courses/course-details/course-details.component';
import { TestComponent } from './test/test.component';
import { StudentCardComponent } from './students/student-card/student-card.component';
import { TeacherCardComponent } from './teachers/teacher-card/teacher-card.component';
import { CourseCardComponent } from './courses/course-card/course-card.component';
import { StudentEditComponent } from './students/student-edit/student-edit.component';
import { TeacherEditComponent } from './teachers/teacher-edit/teacher-edit.component';
import { AdminEditComponent } from './admin-edit/admin-edit.component';
import { StudentSettingsComponent } from './userpreferences/student-settings/student-settings.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { LoadingInterceptor } from './_inteceptors/loading.interceptor';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    TestErrorsComponent,
    NotFoundComponent,
    ServerErrorComponent,
    CoursesListsComponent,
    StudentDetailsComponent,
    TeacherDetailsComponent,
    StudentListsComponent,
    TeachersListsComponent,
    MessagesComponent,
    CourseDetailsComponent,
    TestComponent,
    StudentCardComponent,
    TeacherCardComponent,
    CourseCardComponent,
    StudentEditComponent,
    TeacherEditComponent,
    AdminEditComponent,
    StudentSettingsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    SharedModule,
    NgxSpinnerModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true}

  ], 
  bootstrap: [AppComponent]
})
export class AppModule { }
