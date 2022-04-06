import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Course } from 'src/app/_models/course';
import { AccountService } from 'src/app/_services/account.service';
import { CoursesService } from 'src/app/_services/courses.service';

@Component({
  selector: 'app-course-details',
  templateUrl: './course-details.component.html',
  styleUrls: ['./course-details.component.css']
})
export class CourseDetailsComponent implements OnInit {
  course:  Course;
  userType: string;
  constructor(private courseService: CoursesService, private route: ActivatedRoute,
              private accountService:AccountService) { }

  ngOnInit(): void {
    this.loadCourse();
  }

  getUserType(){
    this.userType = this.accountService.getUserType();
    if (this.userType.includes('@admin')) {
      return 'Admin';
    }
    else if (this.userType.includes('std')) {
      return 'Student';
    }
    return 'Teacher';
  }
  loadCourse(){
    this.courseService.getSpecificCourse(this.route.snapshot.paramMap.get('coursecode')).subscribe(
      response=>{
        this.course=response;
      }
    )
  }
}
