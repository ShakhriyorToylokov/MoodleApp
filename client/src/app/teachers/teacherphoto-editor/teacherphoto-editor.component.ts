import { Component, Input, OnInit } from '@angular/core';
import { Teacher } from 'src/app/_models/teacher';

@Component({
  selector: 'app-teacherphoto-editor',
  templateUrl: './teacherphoto-editor.component.html',
  styleUrls: ['./teacherphoto-editor.component.css']
})
export class TeacherphotoEditorComponent implements OnInit {
  @Input() teacher:Teacher;
  constructor() { }
  
  ngOnInit(): void {
  }

}
