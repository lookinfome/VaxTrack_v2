import { Component } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl } from '@angular/forms';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule, RouterModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  pageTitle: string = "registration";
  pageDescription: string = "join our community and fight with us";

  registerForm:FormGroup;

  constructor()
  {
    this.registerForm = new FormGroup(
      {
        firstName: new FormControl(),
        lastName: new FormControl(),
        emailId: new FormControl(),
        phoneNumber: new FormControl(),
        gender: new FormControl(),
        uniqueId: new FormControl(),
        birthDate: new FormControl()
      }
    );
  }

  onSubmitLogin()
  {
    console.log(this.registerForm.value);
  }


}
