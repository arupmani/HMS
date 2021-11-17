import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { UserModel } from 'src/app/model/user';
import { AuthenticationService } from 'src/app/services/auth.service';
import { FormGroup,FormControl,Validators, FormBuilder   } from '@angular/forms';
import { SocialUser } from 'angularx-social-login';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loading = false;
  submitted = false;
  user: UserModel;
  requiredForm: FormGroup;
  public currentUserSubject: BehaviorSubject<UserModel>;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authService:AuthenticationService,
    private fb:FormBuilder
) { 
  this.formValidations();
}

  ngOnInit(): void {
    this.user=new UserModel();
   
  }
  onSubmit() {
    this.submitted = true;

    

    this.loading = true;
  
}
login(form:NgForm) {
  this.user.username=form.value.username;
  this.user.password=form.value.password;
  return this.authService.login(this.user).subscribe(data => {      
    if (data) {        
      this.user = data;
      
      // store user details and jwt token in local storage to keep user logged in between page refreshes
      localStorage.setItem('currentUser', JSON.stringify(this.user));
      const navigationDetails: string[] = ['/roomlist'];
      this.router.navigate(navigationDetails);
    }
    return this.user
  }, error => {
    console.log(error);
  });
}
 externalLogin  () {
  this.authService.signInWithGoogle()
  .then(res => {
    const user: SocialUser = { ...res };
    console.log(user);
  }, error => console.log(error))
}
formValidations()
{
  this.requiredForm = this.fb.group({
    name: ['', Validators.required ]
    });
}
}
