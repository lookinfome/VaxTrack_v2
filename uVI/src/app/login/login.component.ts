import { Component } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl, FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AccountService } from '../services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, RouterModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  pageTitle: string = "Login";
  pageDescription: string = "so that we can welcome you";

  loginForm: FormGroup;

  constructor(private accountService: AccountService, private router: Router)
  {
    this.loginForm = new FormGroup(
      {
        userId: new FormControl(),
        password: new FormControl(),
      }
    )
  }

  onSubmitLogin(): void {
    if (this.loginForm.valid) {
      const loginDetails =
      {
        userId: this.loginForm.value.userId,
        password: this.loginForm.value.password
      };

      this.accountService.loginUser(loginDetails).subscribe(
        {
          next: (response) => {
            console.log(response);
          },
          error: (error) => {
            console.log(`${error}`);
          }
        }
      );
    } else {
      console.log('Invalid username or password input format');
    }
  }


}
