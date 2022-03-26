import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map, retry } from 'rxjs/operators'
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';
@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl= environment.apiUrl;
  private currentUserSource=new ReplaySubject<User>(1);
  currentUser$= this.currentUserSource.asObservable();
  constructor(private http: HttpClient) { }

  login(model:any){
    return this.http.post(this.baseUrl+'account/login',model).pipe(
      map((response : User)=>{
        const user=response;
        if (user) {
          localStorage.setItem('user',JSON.stringify(user));
          this.currentUserSource.next(user);
        }
        return user;
      }) 
    );
  }
  getAdminUserType(){
    var userType : string=null;
    this.currentUser$.subscribe(response=>{
      if (response!==null) {
        if (response.username==='@admin19991223'){
          userType=response.username;
        }
      }
    });
    return userType;
  }
  setCurrentUser(user:User){
    this.currentUserSource.next(user);
  }

  registerStudents(model:any){
    return this.http.post(this.baseUrl+'account/register-student',model).pipe(
      map((user:User)=>{
        if (user) {
          localStorage.setItem('user',JSON.stringify(user));
          this.currentUserSource.next(user);
        }
        return user;
      })
    );
  }
  registerTeachers(model:any){
    return this.http.post(this.baseUrl+'account/register-teacher',model).pipe(
      map((user:User)=>{
        if (user) {
          localStorage.setItem('user',JSON.stringify(user));
          this.currentUserSource.next(user);
        }
        return user;
      })
    );
  }
  register(model:any){
    return this.http.post(this.baseUrl+'account/register',model).pipe(
      map((user:User)=>{
        if (user) {
          localStorage.setItem('user',JSON.stringify(user));
          this.currentUserSource.next(user);
        }
        return user;
      })
    );
  }

  logout(){
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
