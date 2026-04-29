import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Contact } from '../models/contact';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ContactService {
  private apiUrl = 'http://localhost:5016/Contact';

  constructor(private http: HttpClient) {}

  // GET ALL
  getContacts(): Observable<Contact[]> {
    return this.http
      .get<Contact[]>(`${this.apiUrl}/ShowContacts`)
      .pipe(catchError(this.handleError));
  }

  // GET BY ID
  getContactById(id: number): Observable<Contact> {
    return this.http
      .get<Contact>(`${this.apiUrl}/EditContact/${id}`)
      .pipe(catchError(this.handleError));
  }

  // ADD
  addContact(contact: Contact): Observable<any> {
    return this.http.post(`${this.apiUrl}/AddContact`, contact).pipe(catchError(this.handleError));
  }

  // UPDATE
  updateContact(contact: Contact): Observable<any> {
    return this.http.post(`${this.apiUrl}/EditContact`, contact).pipe(catchError(this.handleError));
  }

  // DELETE
  deleteContact(id: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/DeleteContact/${id}`).pipe(catchError(this.handleError));
  }

  private handleError(error: any) {
    console.error('API Error:', error);
    return throwError(() => error);
  }
}
