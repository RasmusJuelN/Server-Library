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
    private router: Router, private auth:AuthService
    ) { }

    protected registerForm = new FormGroup({
      firstName: new FormControl ('', [Validators.required]),
      lastName: new FormControl ('', [Validators.required]),
      email: new FormControl ('', [Validators.required]),
      password: new FormControl ('', [Validators.required])
    })


    onRegister(){
      if(this.registerForm.valid){
        this.auth.register(this.registerForm.value)
        .subscribe({
          next:(res)=>{console.log(res)}
        })
      }
    }
}
