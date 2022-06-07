import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Course, QuizFiles } from 'src/app/_models/course';
import { CoursesService } from 'src/app/_services/courses.service';
import { QuizService } from 'src/app/_services/quiz.service';

@Component({
  selector: 'app-quiz-main-page',
  templateUrl: './quiz-main-page.component.html',
  styleUrls: ['./quiz-main-page.component.css']
})
export class QuizMainPageComponent implements OnInit {
  quizFiles:QuizFiles;
  questionsList:any=[];

  constructor(private courseService:CoursesService,private route:ActivatedRoute,private questionsService:QuizService) { }
  
  ngOnInit(): void {
    this.getAllQuestions();
    this.loadCourse();
  }
  loadCourse(){
    this.courseService.getSpecificCourse(this.route.snapshot.paramMap.get('coursecode')).subscribe(
      response=>{
        console.log(response);
        this.quizFiles=response.quizFiles[response.quizFiles.length-1];
        
        console.log(this.quizFiles);
        
      }
    )
  }
  getAllQuestions(){
    this.questionsService.getQuestionsJson().subscribe(res=>{
      console.log(res.questions);
      this.questionsList=res.questions;
    });
  }
}
