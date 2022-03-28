import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Student } from 'src/app/_models/student';
import { StudentsService } from 'src/app/_services/students.service';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.css']
})
export class StudentDetailsComponent implements OnInit {
  student: Student;
  constructor(private studentService: StudentsService,private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadStudent();
  }

  loadStudent(){
      this.studentService.getStudent(this.route.snapshot.paramMap.get('username')).subscribe(response=>{
        this.student=response;
      })
  }

}
