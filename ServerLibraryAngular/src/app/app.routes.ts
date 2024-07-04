import { Routes } from '@angular/router';
import { LoginComponent } from './Components/Accounts/login/login.component';
import { RegisterComponent } from './Components/Accounts/register/register.component';
import { AccountComponent } from './Components/Accounts/account/account.component';

export const routes: Routes = [
    { path: '', redirectTo: '/login', pathMatch: 'full'},
    { path: 'login', component: LoginComponent},
    { path: 'register', component: RegisterComponent },
    {path : 'account', component: AccountComponent}
    
];
