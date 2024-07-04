import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { inject } from '@angular/core';
import { AuthService } from '../../../Services/auth.service';
import { MatButtonModule } from '@angular/material/button';
import { MatRippleModule } from '@angular/material/core';


@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ ReactiveFormsModule, RouterModule, MatButtonModule, MatRippleModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {

  constructor(
    private router: Router, private authService :AuthService
    ) { }

    protected registerForm = new FormGroup({
      firstName: new FormControl ('', [Validators.required]),
      lastName: new FormControl ('', [Validators.required]),
      email: new FormControl ('', [Validators.required, Validators.pattern("[a-zA-Z0-9._%+-]+@([a-zA-Z0-9._%+-]+)?tec\\.dk")]),
      password: new FormControl ('', [Validators.required])
    })


    onRegister() {
      if (this.registerForm.valid) {
        console.log(this.registerForm.value)
        this.authService.register(this.registerForm.value).subscribe({
          
          next: (response) => {
            console.log("sucesss????");
            console.log('Registration successful', response);
            // Navigate to the login page or any other page
            alert(response.message);
            this.router.navigate(['']);
          },
          error: (error) => {
            console.log('Registration error', error);
            var errorMessage = error.error || 'An error occurred during registration';
            alert(error.message);
          }
        });
      }
      
    }
}
