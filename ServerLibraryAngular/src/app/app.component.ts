import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { LoginComponent } from "./Components/Accounts/login/login.component";
import { RegisterComponent } from "./Components/Accounts/register/register.component";
import { NavbarComponent } from './Components/navbar/navbar.component';
import { AccountComponent } from './Components/Accounts/account/account.component';


@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    imports: [CommonModule, RouterOutlet, LoginComponent, RegisterComponent, NavbarComponent, AccountComponent]
})
export class AppComponent {
  title = 'ServerLibraryAngular';
}
