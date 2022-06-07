import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { interval } from 'rxjs';
import { delay } from 'rxjs/operators';
import { Course } from 'src/app/_models/course';
import { CoursesService } from 'src/app/_services/courses.service';
import { QuizService } from 'src/app/_services/quiz.service';

@Component({
  selector: 'app-quiz-page',
  templateUrl: './quiz-page.component.html',
  styleUrls: ['./quiz-page.component.css']
})
export class QuizPageComponent implements OnInit {
  questionsList:any=[];
  answersList:any=[];
  course: Course;
  currentQuestion:number=0;
  points:number=0;
  counter=60;
  minutes=Math.floor(this.counter/60);
  seconds=this.counter - this.minutes * 60
  correctAnswer:number=0;
  incorrectAnswer:number=0;
  interval$:any;
  progress="0";
  isQuizCompleted:boolean=false;
  isSubmitted:boolean=false;
  isChoosen:boolean=true;
  isCanceled:boolean=false;
  lastElem:number;
  reviewBtn=false;
  constructor(private questionsService:QuizService,private courseService: CoursesService,
              private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.loadCourse();
    this.getAllQuestions();
    this.startCounter();
  }
  loadCourse(){
    this.courseService.getSpecificCourse(this.route.snapshot.paramMap.get('coursecode')).subscribe(
      response=>{
        console.log(response);
        this.course=response;
        this.lastElem=this.course.quizFiles.length-1;
       this.counter=this.course.quizFiles[this.lastElem].time * 60;
        this.minutes=Math.floor(this.counter/60);
        this.seconds=this.counter - this.minutes * 60
  
      }
    )
  }
  reviewQuiz(){
    this.reviewBtn=true;
  }
  getAllQuestions(){
    this.questionsService.getQuestionsJson().subscribe(res=>{
      this.questionsList=res.questions;
    });
  }
  nextQuestion(){
    this.isChoosen=true;
    this.currentQuestion++;
    this.getProgressPercent();

  }
  previousQuestion(){
    this.isChoosen=true;
    this.currentQuestion--;
    this.getProgressPercent();
  }

  answer(currentQno:number,option:any){
    this.answersList[currentQno-1]=option.text;
    console.log(this.answersList);
    
    this.isChoosen=false;
    if (currentQno===this.questionsList.length) {
      
        this.isQuizCompleted=true;
    }
    if(option.correct){
      this.points+=10;
      this.correctAnswer++;
     
    }else{
        this.incorrectAnswer++; 
    }
  }
  getUserAnswer(currentQno:number,text:string):boolean{
    var answer=this.answersList[currentQno-1];
    if (this.answersList[currentQno-1].toString()===text.toString()) {
      console.log(this.answersList[currentQno-1],text);
      return true;
    }
    return false;
  }
  getAnswer(currentQno:number):string{
    var answer=this.answersList[currentQno-1];
   return answer;
  }
  submitted(){
    setTimeout(() => {
    this.isQuizCompleted=false;
    this.isSubmitted=true;
    this.stopCounter();  
    }, 600);
    this.currentQuestion=0;
  }
  startCounter(){
    this.interval$=interval(1000).subscribe(val=>{
      this.counter--;
      if(this.counter===0){
        this.currentQuestion++;
        this.points-=10;
      }
      this.minutes=Math.floor(this.counter/60);
      this.seconds=this.counter - this.minutes * 60
  
    });
    setTimeout(()=>{
      this.interval$.unsubscribe();
    },this.counter*1000)
  }

  stopCounter(){
    this.interval$.unsubscribe();
    this.counter=0;
  }
  resetCounter(){
    this.stopCounter();
    this.counter=this.course.quizFiles[this.lastElem].time * 60;
    this.startCounter();
  }
  resetQuiz(){
    this.isChoosen=true;
    this.resetCounter();
    this.getAllQuestions();
    this.points=0;
    this.counter=this.course.quizFiles[this.lastElem].time * 60;
    this.currentQuestion=0;
    this.progress='0';
    this.answersList=[];
  }
  //write to review quiz solve the issue option is not popping up
  clearChoice(){
    console.log(this.isCanceled);
    
    this.isCanceled=true;
  }
  getProgressPercent(){
    this.progress=((this.currentQuestion/this.questionsList.length)*100).toString();
    return this.progress;
  }
}
