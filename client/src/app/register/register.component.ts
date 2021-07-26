import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_service/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  
  @Output() cancelRegister= new EventEmitter();
  registerForm:FormGroup;
  maxDate:Date;
  validationError: string[]=[];

  constructor(private accountService: AccountService,private toastr:ToastrService,
    private fb: FormBuilder,private router:Router) { }

  ngOnInit(): void {
    this.initializationForm();
    this.maxDate=new Date();
    this.maxDate.setFullYear(this.maxDate.getFullYear()-18);

  }

  initializationForm(){
    this.registerForm=this.fb.group({
      username:['',Validators.required],
      gender:['male'],
      knownAs:['',Validators.required],
      dateOfBirth:['',Validators.required],
      city:['',Validators.required],
      country:['',Validators.required],
      password:['',[Validators.required,
        Validators.minLength(4),Validators.maxLength(8)]],
      confirmPassword:['',[Validators.required,this.matchValues('password')]]

    })
    this.registerForm.controls.password.valueChanges.subscribe(()=>{
      this.registerForm.controls.confirmPassword.updateValueAndValidity();
    })
  }
  matchValues(matchTo:string):ValidatorFn{
    return(control: AbstractControl)=>{
      return control?.value===control?.parent?.controls[matchTo].value?null:{isMatching:true}
    }
  }
  register(){
    //console.log(this.registerForm.value);
    this.accountService.register(this.registerForm.value).subscribe(response=>{
    this.router.navigateByUrl('/members');
    },error=>{
      this.validationError=error;
      
    })
  
  }
  cancel(){
    this.cancelRegister.emit(false);
  }

}
