import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {
  signInForm: FormGroup;

  constructor(private authService: AuthService, private formbuilder: FormBuilder, private router: Router) {
  }

  ngOnInit() {
    this.signInForm = this.formbuilder.group({
      email: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });
  }

  onSubmit(signInForm: NgForm) {
    const email = signInForm.controls['email'].value;
    const password = signInForm.controls['password'].value;
    this.authService.startAuthentication();
  }
}
