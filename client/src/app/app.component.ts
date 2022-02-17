import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Moodle App';
  students: any;
  teachers:any;
  api ="https://localhost:5001/api/";
  constructor(private http: HttpClient){}
  ngOnInit(){
    this.getStudents();
    this.getTeachers();
  }

  getStudents(){

      this.http.get(this.api +'students').subscribe(response=>{
        this.students=response
      },error =>{
      console.log(error);
      })
  }

  
  getTeachers(){

    this.http.get(this.api +'teachers').subscribe(response=>{
      this.teachers=response
    },error =>{
    console.log(error);
    })
}
}
