import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User, QueryResult } from '../../models/user.interface';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

    constructor(private service: UserService) { }

    private readonly PAGE_SIZE = 3;

    result: QueryResult = {
        items: [],
        totalItems: 0
    };   

    columns = [
        { title: 'Id'},
        { title: 'Full Name', key: 'fullName', isSortable: true},
        { title: 'Registration Date', key: 'registrationDate', isSortable: true},
        {}
    ];   

    query: any = {
        page: 1,
        pageSize: this.PAGE_SIZE
    };

    private populateUsers() {        
        this.service.getUsers(this.query)
            .subscribe(result => {
                this.result.items = result.items;
                this.result.totalItems = result.totalItems;
            });
    }

    ngOnInit() {        
        this.populateUsers();
    }

    private resetPages() {
        this.query.page = 1;
        this.query.pageSize = this.PAGE_SIZE;
    }

    onFilterChange() {          
        this.resetPages();        
        this.populateUsers();
    }

    onResetFilter() {
        this.query = {};
        this.onFilterChange();
    }

    onSortBy(sortBy: string) {
        this.query.sortBy = sortBy;
        this.query.isSortAscending = !this.query.isSortAscending;
        this.resetPages();  
        this.populateUsers();
    }

    onPageChange(page: any) {
        this.populateUsers();
    }






}
