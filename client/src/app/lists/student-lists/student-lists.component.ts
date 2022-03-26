import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/_models/student';
import { StudentsService } from 'src/app/_services/students.service';

@Component({
  selector: 'app-student-lists',
  templateUrl: './student-lists.component.html',
  styleUrls: ['./student-lists.component.css']
})
export class StudentListsComponent implements OnInit {

  students: Student[];
  constructor(private studentService: StudentsService) { }

  ngOnInit(): void {
    this.loadStudents();
  }
  loadStudents(){
    this.studentService.getStudents().subscribe(response=>{
      console.log(response);
      
      this.students=response;
    })
  }
}
