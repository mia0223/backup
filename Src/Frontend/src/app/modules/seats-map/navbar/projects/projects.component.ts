import {Component, OnInit, Input} from '@angular/core';
import { Project } from 'app/core/models/project'
import {ProjectsService} from "../../../../core/web-dal/projects.service";
import {SeatsMapService} from "../../seats-map.service";


@Component({
    selector: 'projects, .projects',
    templateUrl: './projects.component.html',
    providers: [ProjectsService]
})

export class ProjectsComponent implements OnInit {
    public internalProjects: Project[];
    public externalProjects: Project[];

    constructor(
        private projectsService: ProjectsService,
        private seatsMapService: SeatsMapService
    ) {}

    ngOnInit(): void {
        this.seatsMapService.locationIdChangesObservable.subscribe(id => {
            this.projectsService.getByLocation(id).subscribe(res => {
                this.internalProjects = res.filter(p => p.internal);
                this.externalProjects = res.filter(p => !p.internal);
            });
        })
    }
}
