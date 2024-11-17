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

  loginDetails!: {
    userid: string, password: string;
  }


  constructor(private accountService: AccountService, private router: Router)
  {
    this.loginForm = new FormGroup(
      {
        userid: new FormControl(),
        password: new FormControl(),
      }
    )
  }

  onSubmitLogin():any
  {
    if (this.loginForm.valid) {
      this.loginDetails =
      {
        userid: this.loginForm.value.userid,
        password: this.loginForm.value.password
      };

      this.accountService.loginUser(this.loginDetails).subscribe(
        {
          next: (response) =>
          {
            console.log(`login success for user: ${this.loginDetails.userid}`);
            this.router.navigate([`userprofile/${this.loginDetails.userid}`]);
          },
          error: (response) =>
          {
            console.error(`invalid username/password`);
          }
        }

      );

    } else {
      console.log(`invalid form input formats`);
    }

  }


}
