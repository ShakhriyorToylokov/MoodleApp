import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminEditComponent } from './admin-edit/admin-edit.component';
import { StudentAssignCourseComponent } from './assign-courses/student-assign-course/student-assign-course.component';
import { CourseDetailsComponent } from './courses/course-details/course-details.component';
import { CourseEditComponent } from './courses/course-edit/course-edit.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { HomeComponent } from './home/home.component';
import { CoursesListsComponent } from './lists/courses-lists/courses-lists.component';
import { StudentListsComponent } from './lists/student-lists/student-lists.component';
import { TeachersListsComponent } from './lists/teachers-lists/teachers-lists.component';
import { MessagesComponent } from './messages/messages.component';
import { QuizMainPageComponent } from './quiz/quiz-main-page/quiz-main-page.component';
import { QuizPageComponent } from './quiz/quiz-page/quiz-page.component';
import { QuizUploaderComponent } from './quiz/quiz-uploader/quiz-uploader.component';
import { RegisterManuallyComponent } from './register-options/register-manually/register-manually.component';
import { RegisterComponent } from './register/register.component';
import { StudentDetailsComponent } from './students/student-details/student-details.component';
import { StudentEditComponent } from './students/student-edit/student-edit.component';
import { TeacherDetailsComponent } from './teachers/teacher-details/teacher-details.component';
import { TeacherEditComponent } from './teachers/teacher-edit/teacher-edit.component';
import { StudentSettingsComponent } from './userpreferences/student-settings/student-settings.component';
import { AdminActivateGuard } from './_guards/admin-activate.guard';
import { AuthGuard } from './_guards/auth.guard';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';
import { TeacherActivateGuard } from './_guards/teacher-activate.guard';

const routes: Routes = [
  {path:'',component: HomeComponent},
  {
    path:'',
    runGuardsAndResolvers: 'always',
    canActivate:[AuthGuard],
    children:[
      {path:'students',component: StudentListsComponent},
      {path:'teachers',component: TeachersListsComponent},
      {path:'register-manually',component: RegisterManuallyComponent,canActivate:[AdminActivateGuard]},
      {path:'register',component: RegisterComponent,canActivate:[AdminActivateGuard]},
      {path:'courses',component: CoursesListsComponent},
      {path:'messages',component: MessagesComponent},
      {path:'students/:username',component: StudentDetailsComponent},
      {path:'teachers/:username',component: TeacherDetailsComponent},
      {path:'courses/:coursecode',component: CourseDetailsComponent},
      {path:'students/:username/edit',component: StudentEditComponent, canDeactivate:[PreventUnsavedChangesGuard]},
      {path:'teachers/:username/edit',component: TeacherEditComponent, canActivate:[TeacherActivateGuard] , canDeactivate:[PreventUnsavedChangesGuard]},
      {path:'courses/:coursecode/edit',component: CourseEditComponent, canActivate:[TeacherActivateGuard], canDeactivate:[PreventUnsavedChangesGuard]},
      {path:'admin/edit',component: AdminEditComponent},
      {path:'student/:username/edit',component: StudentSettingsComponent},
      {path:'students/:username/edit/assign-course',component: StudentAssignCourseComponent},
      {path:'courses/:coursecode/quiz',component: QuizPageComponent}

    ]
  },
  {path:'errors',component: TestErrorsComponent},
  {path:'not-found',component: NotFoundComponent},
  {path:'server-error',component: ServerErrorComponent},
  {path:'**',component: NotFoundComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
