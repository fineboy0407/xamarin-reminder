import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../auth/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  constructor(private router: Router, private authService: AuthService) { }

  ngOnInit() {
  }

  onLogin() {
    this.authService.startAuthentication();
  }

  onLogout() {
    this.authService.startLogout();
    this.router.navigate(['/']);
  }

  isAuthenticated() {
    return this.authService.isLoggedIn();
  }
}
