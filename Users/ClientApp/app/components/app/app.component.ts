import { Component, OnInit, ViewChild } from '@angular/core';

import { ToastContainerDirective, ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    @ViewChild(ToastContainerDirective) toastContainer: ToastContainerDirective;

    constructor(private toastrService: ToastrService) { }
    ngOnInit() {
        this.toastrService.overlayContainer = this.toastContainer;
    }
}
