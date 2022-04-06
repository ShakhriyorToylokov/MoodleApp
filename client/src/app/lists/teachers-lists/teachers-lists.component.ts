import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Teacher } from 'src/app/_models/teacher';
import { TeachersService } from 'src/app/_services/teachers.service';

@Component({
  selector: 'app-teachers-lists',
  templateUrl: './teachers-lists.component.html',
  styleUrls: ['./teachers-lists.component.css']
})
export class TeachersListsComponent implements OnInit {

  teachers$: Observable<Teacher[]> ;
  constructor(private teacherService: TeachersService) { }

  ngOnInit(): void {
    this.teachers$=this.teacherService.getTeachers();
  }

}
