import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CourseDetailsComponent } from './courses/course-details/course-details.component';
import { HomeComponent } from './home/home.component';
import { CoursesListsComponent } from './lists/courses-lists/courses-lists.component';
import { StudentListsComponent } from './lists/student-lists/student-lists.component';
import { TeachersListsComponent } from './lists/teachers-lists/teachers-lists.component';
import { MessagesComponent } from './messages/messages.component';
import { RegisterComponent } from './register/register.component';
import { StudentDetailsComponent } from './students/student-details/student-details.component';
import { TeacherDetailsComponent } from './teachers/teacher-details/teacher-details.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  {path:'',component: HomeComponent},
  {
    path:'',
    runGuardsAndResolvers: 'always',
    canActivate:[AuthGuard],
    children:[
      {path:'students',component: StudentListsComponent},
      {path:'teachers',component: TeachersListsComponent},
      {path:'register',component: RegisterComponent},
      {path:'courses',component: CoursesListsComponent},
      {path:'messages',component: MessagesComponent},
      {path:'students/:id',component: StudentDetailsComponent},
      {path:'teachers/:id',component: TeacherDetailsComponent},
      {path:'courses/:id',component: CourseDetailsComponent}    
    ]
  },
  {path:'**',component: HomeComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
