import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanDeactivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { CourseEditComponent } from '../courses/course-edit/course-edit.component';
import { StudentEditComponent } from '../students/student-edit/student-edit.component';
import { TeacherEditComponent } from '../teachers/teacher-edit/teacher-edit.component';

@Injectable({
  providedIn: 'root'
})
export class PreventUnsavedChangesGuard implements CanDeactivate<unknown> {
  canDeactivate(
    component: StudentEditComponent | TeacherEditComponent | CourseEditComponent): boolean | UrlTree {
      if (component.editForm.dirty) {
        return confirm("Are you sure you want to continue? Any unsaved changes will be lost!");
      }
    return true;
    
  }
  
  
}
