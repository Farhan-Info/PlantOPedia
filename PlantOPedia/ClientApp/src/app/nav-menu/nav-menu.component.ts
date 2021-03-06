import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../login/login.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  loggedIn! : boolean;
  roleType!:string |null;
  roleFlag!: boolean;
  uName!: string | null;

  constructor (private loginService : LoginService,
                private router : Router){}

  ngOnInit(): void {
    this.loggedIn = this.loginService.isUserLoggedIn();
    this.uName = this.loginService.getLoggedInUserName(); 
    this.roleType = this.loginService.getLoggedInUserType(); 
    if(this.roleType == 'Admin'){
        this.roleFlag = true;
    }
    else {
        this.roleFlag = false;
    }
  }


  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  removeLoggedInUserDetails(): void {
    localStorage.clear();
    // this.reloadCurrentComponent();
    // this.router.navigate(['']);
    window.location.reload();

  }

}
