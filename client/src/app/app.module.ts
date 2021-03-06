import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
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
import { CourseEditComponent } from './courses/course-edit/course-edit.component';
import { StudentphotoEditorComponent } from './students/studentphoto-editor/studentphoto-editor.component';
import { TeacherphotoEditorComponent } from './teachers/teacherphoto-editor/teacherphoto-editor.component';
import { FileUploaderComponent } from './courses/file-uploader/file-uploader.component';
import { LectureNotesComponent } from './courses/course-tabs/lecture-notes/lecture-notes.component';
import { LectureVideosComponent } from './courses/course-tabs/lecture-videos/lecture-videos.component';
import { VideoUploadComponent } from './courses/course-tabs/video-upload/video-upload.component';
import { LectureAnnouncementsComponent } from './courses/course-tabs/lecture-announcements/lecture-announcements.component';
import { RegisterManuallyComponent } from './register-options/register-manually/register-manually.component';
import { RegisterByFileComponent } from './register-options/register-by-file/register-by-file.component';
import { RegisterByFileStudentComponent } from './register-options/register-by-file-student/register-by-file-student.component';
import { RegisterByFileTeacherComponent } from './register-options/register-by-file-teacher/register-by-file-teacher.component';
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { DateInputComponent } from './_forms/date-input/date-input.component';
import { CountryInputComponent } from './_forms/country-input/country-input.component';
import { AddNewCourseComponent } from './register-options/add-new-course/add-new-course.component';
import { StudentAssignCourseComponent } from './assign-courses/student-assign-course/student-assign-course.component';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { HomeworkUploadComponent } from './courses/homework-upload/homework-upload.component';
import { HomeworkPageComponent } from './courses/homework-page/homework-page.component';
import { QuizMainPageComponent } from './quiz/quiz-main-page/quiz-main-page.component';
import { QuizPageComponent } from './quiz/quiz-page/quiz-page.component';
import { ChangeBgDirective } from './quiz/change-bg.directive';
import { QuizUploaderComponent } from './quiz/quiz-uploader/quiz-uploader.component';
import { QuizSetComponent } from './quiz/quiz-set/quiz-set.component';
import { QuizReviewComponent } from './quiz/quiz-review/quiz-review.component';
import { ReviewQuizDirective } from './quiz/review-quiz.directive';


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
    StudentSettingsComponent,
    CourseEditComponent,
    StudentphotoEditorComponent,
    TeacherphotoEditorComponent,
    FileUploaderComponent,
    LectureNotesComponent,
    LectureVideosComponent,
    VideoUploadComponent,
    LectureAnnouncementsComponent,
    RegisterManuallyComponent,
    RegisterByFileComponent,
    RegisterByFileStudentComponent,
    RegisterByFileTeacherComponent,
    TextInputComponent,
    DateInputComponent,
    CountryInputComponent,
    AddNewCourseComponent,
    StudentAssignCourseComponent,
    HomeworkUploadComponent,
    HomeworkPageComponent,
    QuizMainPageComponent,
    QuizPageComponent,
    ChangeBgDirective,
    QuizUploaderComponent,
    QuizSetComponent,
    QuizReviewComponent,
    ReviewQuizDirective
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    SharedModule,
    NgxSpinnerModule,
    ReactiveFormsModule,
    NgMultiSelectDropDownModule.forRoot()
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true}
  ], 
  bootstrap: [AppComponent]
})
export class AppModule { }
