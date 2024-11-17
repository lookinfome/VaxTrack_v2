import { Component } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl, FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  pageTitle: string = "Login";
  pageDescription: string = "so that we can welcome you";

  loginForm: FormGroup;

  constructor()
  {
    this.loginForm = new FormGroup(
      {
        userid: new FormControl(),
        password: new FormControl(),
      }
    )
  }

  onSubmitLogin()
  {
    console.log(`login hit success...`);
  }

}
