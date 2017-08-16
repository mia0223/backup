import { Component, OnInit } from '@angular/core';
import { VersionService } from './version.service';

@Component({
    selector: '.app-version',
    template: 'version: {{ version }}',
    providers: [VersionService]
})

export class VersionComponent implements OnInit {
    version: string;

    constructor(
        private versionService: VersionService
    ) {}

    ngOnInit(): void {
        this.versionService.getVersion().subscribe(res => {
            this.version = res._body;
        });
    }
}
