import { Component, Input, OnInit } from '@angular/core';
import { Teacher } from 'src/app/_models/teacher';

@Component({
  selector: 'app-teacher-card',
  templateUrl: './teacher-card.component.html',
  styleUrls: ['./teacher-card.component.css']
})
export class TeacherCardComponent implements OnInit {
  @Input() teacher: Teacher
  constructor() { }

  ngOnInit(): void {
  }

}
