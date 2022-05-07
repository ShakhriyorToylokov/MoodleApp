import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map, retry } from 'rxjs/operators'
import { environment } from 'src/environments/environment';
import { Faculty } from '../_models/faculty';
import { Admin, RegisterFiles } from '../_models/registerFile';
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
  getUserType(){
    var userType : string=null;
    this.currentUser$.subscribe(response=>{
      if (response!==null) {
          userType=response.username;
      }
    });
    return userType;
  }
  getAdmin(username: string){
    return this.http.get<Admin>(this.baseUrl+'admins/'+username);
  }

  deleteRegisterFile(fileId:number){
    return this.http.delete(this.baseUrl+'account/delete-file/'+fileId);
  }
  setCurrentUser(user:User){
    localStorage.setItem('user',JSON.stringify(user));
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

  getFaculties(){
    return this.http.get<Faculty[]>(this.baseUrl+'faculties');
  }
  logout(){
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
