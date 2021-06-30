import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Event, IEvent} from '../models/Event'
import { environmentVariables } from '../constants/url-constants'
import { IDirector } from '../models/Director';
import { IUser } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class DirectorService {

  private baseUrl=environmentVariables.JSON_API_URL;
  private backUrl=environmentVariables.BACK_URL;

  constructor(private http: HttpClient) { }

  getDirectorByEmail(email: string): Observable<IDirector>{
    let url=this.backUrl+`Director/GetDirectorByEmail?email=${email}`;
    return this.http.get<IDirector>(url);
  }
  
  getEventsByDirectorsId( id: string): Observable<IEvent[]>{
    let url=this.backUrl+`Event/GetEventsByDirectorsId?directorsId=${id}`;
    return this.http.get<IEvent[]>(url);
  }

  postEvent(oglas: Event):Observable<IEvent>{
    let url=this.backUrl+`Event/AddEvent`;
    return this.http.post<IEvent>(url,oglas);
  }

  updateEvent(oglas: Event):Observable<IEvent>{
    console.log(oglas)
    let url=this.backUrl+`Event/UpdateEvent`;
    return this.http.put<IEvent>(url,oglas);
  }

  deleteEvent( eventId: string):Observable<IEvent>{
    let url=this.backUrl+`Event/DeleteEvent?idEvent=${eventId}`;
    return this.http.delete<IEvent>(url);
  }

  getAllUsers() : Observable<IUser[]>{
    let url=this.backUrl+`User/GetAllUsers`;
    return this.http.get<IUser[]>(url);
  }

}
