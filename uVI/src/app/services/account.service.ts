import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';

interface LoginDetails {
  userId: string;
  password: string;
}

interface UserProfileDetails {
  userId: string;
  userName: string;
  userUid: string;
  userBirthDate: string;
  userGender: string;
  userPhone: string;
}

@Injectable({
  providedIn: 'root', // Makes the service available globally
})
export class AccountService {
  private baseUrl = 'http://localhost:5262/api/Account';

  constructor(private http: HttpClient) {}

  // Using POST method to send login details in the body
  loginUser(submittedDetails: LoginDetails): Observable<UserProfileDetails> {
    return this.http
      .post<any>(`${this.baseUrl}/LoginUser`, submittedDetails)
      .pipe(
        map((response) => {
          // Assuming the API response is already structured as UserProfileDetails
          const userProfile: UserProfileDetails = {
            userId: response.userId,
            userName: response.userName,
            userUid: response.userUid,
            userBirthDate: response.userBirthDate,
            userGender: response.userGender,
            userPhone: response.userPhone,
          };
          return userProfile;
        })
      );
  }
}
