import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environmentVariables } from '../constants/url-constants'
import { IEvent } from '../models/Event';
import { IUser, User } from '../models/User';
import { map } from 'rxjs/operators';
import { EventSignedEmplyed, IEventSignedEmployed } from '../models/EventSignedEmployed';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseUrl=environmentVariables.JSON_API_URL;
  private backUrl=environmentVariables.BACK_URL;

  constructor(private http: HttpClient) { }

  getUserByEmail(email: string): Observable<IUser>{
    let url=this.backUrl+`User/GetUserByEmail?email=${email}`;
    return this.http.get<IUser>(url);
  }

  updateUser(user: User): Observable<IUser>{
    let url=this.backUrl+`User/UpdateUser`;
    return this.http.put<IUser>(url,user)
  }

  getAllEvents(): Observable<IEvent[]>{
    let url=this.backUrl+`Event/GetAllEvents`;
    return this.http.get<IEvent[]>(url);
  }

  getAllEventSigned(): Observable<IEventSignedEmployed[]>{
    let url=this.backUrl+`Event/GetAllEventsSigned`;
    return this.http.get<IEventSignedEmployed[]>(url);
  }

  getAllEventSignedForUser( idUser: string): Observable<IEventSignedEmployed[]>{
    let url=this.backUrl+`Event/GetAllEventsSignedForUser?userId=${idUser}`;
    return this.http.get<IEventSignedEmployed[]>(url);
  }

  postEventSigned( eventSigned: EventSignedEmplyed): Observable<IEventSignedEmployed>{
    let url=this.backUrl+`Event/AddEventSigned`;
    return this.http.post<IEventSignedEmployed>(url,eventSigned);
  }

  deletEventSigned(idObjekta: string): Observable<IEventSignedEmployed>{
    let url=this.backUrl+`Event/DeleteEventSigned?id=${idObjekta}`;
    return this.http.delete<IEventSignedEmployed>(url);
  }

  getAllEventsEmployed(): Observable<IEventSignedEmployed[]>{
    let url=this.backUrl+`Event/GetAllEventsEmployed`;
    return this.http.get<IEventSignedEmployed[]>(url);
  }

  getAllEventEmployedForUser( idUser: string): Observable<IEventSignedEmployed[]>{
    let url=this.backUrl+ `Event/GetAllEventsEmployedForUsered?userId=${idUser}`;
    return this.http.get<IEventSignedEmployed[]>(url);
  }

  postEventEmployed( eventEmployed: EventSignedEmplyed): Observable<IEventSignedEmployed>{
    let url=this.backUrl+"Event/AddEventEmployed";
    return this.http.post<IEventSignedEmployed>(url,eventEmployed);
  }

  deletEventEmployed(idObjekta: string): Observable<IEventSignedEmployed>{
    let url=this.backUrl+`Event/DeleteEventEmployed?id=${idObjekta}`;
    return this.http.delete<IEventSignedEmployed>(url);
  }

  

}
