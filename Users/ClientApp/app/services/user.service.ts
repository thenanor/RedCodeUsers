import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { SaveUser } from '../models/user.interface';
import { forEach } from '@angular/router/src/utils/collection';

@Injectable()
export class UserService {

    constructor(private http: Http) { }

    private readonly usersEndPoint = '/api/users';
    private readonly InterestsEndPoint = '/api/interests';

    toQueryString(obj: any) {        
        var parts = [];

        for (var prop in obj) {
            var value = obj[prop];                        
            if (value != null && value != undefined)
                parts.push(encodeURIComponent(prop) + '=' + encodeURIComponent(value));
        }

        return parts.join('&');
    }

    getInterests() {
        return this.http.get(this.InterestsEndPoint)
            .map(res => res.json());
    }

    getUsers(query: any) {
        return this.http.get(this.usersEndPoint + '?' + this.toQueryString(query))
            .map(res => res.json());
    }

    getUser(id: number) {
        return this.http.get(this.usersEndPoint + '/' + id)
            .map(res => res.json());
    }

    create(user: SaveUser) {        
        return this.http.post(this.usersEndPoint, user)
            .map(res => res.json());
    }

    update(user: SaveUser) {
        return this.http.put(this.usersEndPoint + '/' + user.id, user)      //maybe JSON.stringify(user)
            .map(res => res.json());
    }

    remove(id: number) {
        return this.http.delete(this.usersEndPoint + '/' + id)
            .map(res => res.json());

    }

}
