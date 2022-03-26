import { Component, OnInit } from '@angular/core';
import { Teacher } from 'src/app/_models/teacher';
import { TeachersService } from 'src/app/_services/teachers.service';

@Component({
  selector: 'app-teachers-lists',
  templateUrl: './teachers-lists.component.html',
  styleUrls: ['./teachers-lists.component.css']
})
export class TeachersListsComponent implements OnInit {

  teachers: Teacher[];
  constructor(private teacherService: TeachersService) { }

  ngOnInit(): void {
    this.loadTeachers();
  }

  loadTeachers(){
    this.teacherService.getTeachers().subscribe(response=>{
      this.teachers=response;
    });
  }
}
