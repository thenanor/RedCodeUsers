import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../../models/user.interface';

@Component({
  selector: 'app-view-user',
  templateUrl: './view-user.component.html',
  styleUrls: ['./view-user.component.css']
})
export class ViewUserComponent implements OnInit {

    constructor(private service: UserService, private route: ActivatedRoute, private router: Router) {
        route.params.subscribe(p =>
            this.userId = +p['id']
        );

        if (isNaN(this.userId) || this.userId <= 0) {
            router.navigate(['/users']);
            return;
        }
    }

    user: any;
    userId: number;

    ngOnInit() {

        this.service.getUser(this.userId)
            .subscribe(user => this.user = user);
    }

    delete() {
        if (confirm("Are you sure?")) {
            this.service.remove(this.userId)
                .subscribe(res => this.router.navigate(['/users']));
        }        
    }


}
