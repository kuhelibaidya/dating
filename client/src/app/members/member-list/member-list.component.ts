import { Component, OnInit } from '@angular/core';
import { members } from 'src/app/_models/members';
import { MembersService } from 'src/app/_service/members.service';


@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
members: members[];
  constructor(private memberService:MembersService) { }

  ngOnInit(): void {
    this.loadMembers();
  }
  loadMembers(){this.memberService.getMembers().subscribe(members=>{this.members=members;})}

}
