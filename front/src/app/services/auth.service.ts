import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {ILoggedUser, LoggedUser} from '../models/LoggedUser'
import {Director, IDirector} from '../models/Director'
import {IUser, User} from '../models/User'
import { environmentVariables } from '../constants/url-constants';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl=environmentVariables.JSON_API_URL;
  private backUrl=environmentVariables.BACK_URL;

  constructor(private http: HttpClient) { }


  checkIfUserValid(email: string, password: string): Observable<ILoggedUser>{
    let url=this.backUrl+`LoggedUser/CheckIfLoginValid?email=${email}&&password=${password}`;
    return this.http.get<ILoggedUser>(url);
  }

  getAllUsers(): Observable<ILoggedUser[]>{
    let url=this.backUrl+"LoggedUser/GetLoggedUsers";
    return this.http.get<ILoggedUser[]>(url);
  }

  getUser(email: string):Observable<ILoggedUser>{
    let url=this.backUrl+`LoggedUser/GetUserByEmail?email=${email}`;
    return this.http.get<ILoggedUser>(url);
  }

  postRegisterLoggedUser(user:LoggedUser):Observable<ILoggedUser>{
    let url=this.backUrl+`LoggedUser/AddLoggedUser`;
    return this.http.post<ILoggedUser>(url,user);
  }

  postRegisterDirector(reziser:Director):Observable<IDirector>{
    let url=this.backUrl+`Director/AddDirector`;
    return this.http.post<IDirector>(url,reziser);
  }

  postRegisterUser(korisnik: User): Observable<IUser>{
    let url=this.backUrl+`User/AddUser`;
    return this.http.post<IUser>(url, korisnik);
  }

}
