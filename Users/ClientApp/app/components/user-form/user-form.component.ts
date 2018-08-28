import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/forkJoin';

import { UserService } from '../../services/user.service';
import { SaveUser, User } from '../../models/user.interface';

import * as _ from 'underscore';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent implements OnInit {
    

    constructor(private service: UserService,
        private route: ActivatedRoute, private router: Router,
        private toastr: ToastrService) {

        route.params.subscribe(p => {
            this.user.id = +p['id'] || 0;
        });
    }   

    interests: any[];

    user: SaveUser = {
        id: 0,
        fullName: '',
        email: '',
        gender: 'M',
        interests: [],
        contact: {            
            phone: '',
            address: ''
        }
    };

    ngOnInit() {

        var requests = [
            this.service.getInterests()
        ];

        if (this.user.id) {
            requests.push(this.service.getUser(this.user.id));
        }


        Observable.forkJoin(requests)
            .subscribe(data => {
                this.interests = data[0];
                if (this.user.id) {
                    this.setUser(data[1]);
                }            
            }, err => {
                this.router.navigate(['/users'])
            });

    }

    onInterestToggle(interestId: number, $event: any) {
        console.log(interestId, $event);
        if ($event.target.checked) {
            this.user.interests.push(interestId);
        } else {
            let index = this.user.interests.indexOf(interestId);	
            this.user.interests.splice(index, 1);
        }

    }
    private setUser(user: User) {
        this.user.id = user.id;
        this.user.fullName = user.fullName;
        this.user.email = user.email;    
        this.user.gender = user.gender;
        this.user.interests = _.pluck(user.interests, 'id');
        this.user.contact.phone = user.contact.phone;
        this.user.contact.address = user.contact.address;                   
    }

    submit() {
        var result$ = (this.user.id) ? this.service.update(this.user) : this.service.create(this.user);
        result$.subscribe(res => {
            this.toastr.success("User has been saved successfully");
            this.router.navigate(['/users/', res.id]);
            return;
        });
    }

}
