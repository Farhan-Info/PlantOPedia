import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IUser } from '../login/login';
import { LoginService } from '../login/login.service';
import { isNotNullOrUndefine } from '../Shared/methods';
import { SuccessEnum } from '../Shared/models';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  newuserform: FormGroup = new FormGroup({});

  responce!: any;

  constructor(private formBuilder: FormBuilder,
    private loginService: LoginService,
    private router: Router) { }

  ngOnInit(): void {
    this.newuserform = this.formBuilder.group({
      name: [undefined, [Validators.required]],
      email: [undefined, [Validators.required, Validators.email]],
      address: [undefined, [Validators.required]],
      mobileNo: [undefined, [Validators.required]],
      password: [undefined, [Validators.required]],
      roleId: 'C54DBF56-F8C9-4063-873F-9BD3DEFDEE0E'
    })

  }

  addNewUser() {
    if(this.newuserform.invalid)
    {
      alert("Field is Invalid or Empty");

    }
    else {
      this.loginService.addUser(this.newuserform.value).subscribe({
        next: (responce) => {
          this.responce = responce;
          if (this.responce.message === SuccessEnum.message) {
            alert("You are now signup Successfully");
            this.router.navigate(['/login']);

          }
          else {
            this.router.navigate(['/signup']);
          }
        }
      })
    }
  }



}
