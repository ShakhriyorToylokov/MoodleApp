import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Teacher } from 'src/app/_models/teacher';
import { TeachersService } from 'src/app/_services/teachers.service';

@Component({
  selector: 'app-teacher-details',
  templateUrl: './teacher-details.component.html',
  styleUrls: ['./teacher-details.component.css']
})
export class TeacherDetailsComponent implements OnInit {
  teacher: Teacher;
  constructor(private teacherService: TeachersService,private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadTeacher();
  }

  loadTeacher(){
      this.teacherService.getTeacher(this.route.snapshot.paramMap.get('username')).subscribe(response=>{
        this.teacher=response;
      })
  }
}
