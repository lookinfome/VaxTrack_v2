import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root', // Makes the service available globally
})
export class AccountService {
  private baseUrl = 'http://localhost:5262/api/Account';

  constructor(private http: HttpClient) {}

  loginUser(credentials: { userid: string; password: string }): Observable<any>
  {
    return this.http.post(`${this.baseUrl}/LoginUser`, credentials);
  }
}
