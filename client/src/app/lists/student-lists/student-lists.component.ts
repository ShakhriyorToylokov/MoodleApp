import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from 'src/app/_models/student';
import { StudentsService } from 'src/app/_services/students.service';

@Component({
  selector: 'app-student-lists',
  templateUrl: './student-lists.component.html',
  styleUrls: ['./student-lists.component.css']
})
export class StudentListsComponent implements OnInit {

  students$: Observable<Student[]> ;
  constructor(private studentService: StudentsService) { }

  ngOnInit(): void {
    this.students$=this.studentService.getStudents();
    
  }
}
