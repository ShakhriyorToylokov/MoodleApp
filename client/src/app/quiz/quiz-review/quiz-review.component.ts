import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-quiz-review',
  templateUrl: './quiz-review.component.html',
  styleUrls: ['./quiz-review.component.css']
})
export class QuizReviewComponent implements OnInit {
  questionsList:any=[];
  answersList:any=[];
  currentQuestion:number=0;

  constructor() { }

  ngOnInit(): void {
  }

  nextQuestion(){
    this.currentQuestion++;
  
  }
  previousQuestion(){
    this.currentQuestion--;
  }


}
