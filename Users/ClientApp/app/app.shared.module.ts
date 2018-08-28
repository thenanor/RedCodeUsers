import { NgModule, ErrorHandler } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule, ToastContainerModule } from 'ngx-toastr';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { NgxPaginationModule } from 'ngx-pagination'; 

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { UserFormComponent } from './components/user-form/user-form.component';
import { UserListComponent } from './components/user-list/user-list.component';
import { ViewUserComponent } from './components/view-user/view-user.component';

import { UserService } from './services/user.service';

import { AppErrorHandler } from './app.error-handler';
import { HomeComponent } from './components/home/home.component';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        UserFormComponent,
        UserListComponent,
        ViewUserComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        BrowserModule,
        BrowserAnimationsModule,
        HttpModule,
        FormsModule,
        
        ToastrModule.forRoot({
            positionClass: 'toast-top-right',
            closeButton: true,
            preventDuplicates: true
        }),
        ToastContainerModule,
        AngularFontAwesomeModule,
        NgxPaginationModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'users/new', component: UserFormComponent },
            { path: 'users/new/:id', component: UserFormComponent },
            { path: 'users/:id', component: ViewUserComponent },
            { path: 'users', component: UserListComponent },
            { path: '**', redirectTo: 'home' }
        ])        
    ],
    providers: [
        { provide: ErrorHandler, useClass: AppErrorHandler },
        UserService
    ]
})
export class AppModuleShared {
}
