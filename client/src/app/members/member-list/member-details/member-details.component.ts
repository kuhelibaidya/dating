import { Component, Input, OnInit } from '@angular/core';
import { members } from 'src/app/_models/members';

@Component({
  selector: 'app-member-details',
  templateUrl: './member-details.component.html',
  styleUrls: ['./member-details.component.css']
})
export class MemberDetailsComponent implements OnInit {
  @Input() Member:members;

  constructor() { }

  ngOnInit(): void {
  }

}
