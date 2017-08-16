import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
// HttpModule for calling module
import {HttpModule} from '@angular/http';

import {AppComponent} from './app.component';
import {DataAccessService} from './data-access.service';
// learning route
import {RouterModule, Routes} from '@angular/router';
import {SimpleObjectComponent} from './simple-object.component';
import {PageNotFoundComponent} from './page-not-found.component';
import {SimpleObjectService} from './simple-object.service';
import {SimpleObjectListComponent} from './simple-object-list.component';
import {AddSimpleObjectComponent} from './add-simple-object.component';

// add drag and drop feature
import {DndModule } from 'ng2-dnd';
import {SimpleDndComponent} from './drag-and-drop-first.component';
import {SimpleDndHandleComponent} from './simple-drag-and-drop-handle.component';

/*routed Angular application has one singleton instance of the Router service.*/
const appRoutes: Routes = [
  {path: '', redirectTo: '/SimpleObjectList', pathMatch: 'full'},
  {path: 'AddNewObject', component: AddSimpleObjectComponent},
  {path: 'AddNewObject/:seat', component: AddSimpleObjectComponent},
  {path: 'SimpleObjectList', component: SimpleObjectListComponent},
  {path: 'SimpleObject/:name', component: SimpleObjectComponent},
  {path: '**', component: PageNotFoundComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    SimpleObjectComponent,
    PageNotFoundComponent,
    SimpleObjectListComponent,
    AddSimpleObjectComponent,
    // simple drag and drop component
    SimpleDndComponent,
    SimpleDndHandleComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    /*deal with no provider with router*/
    RouterModule.forRoot(appRoutes),
    // drag and drop feature
    DndModule.forRoot()
  ],
  providers: [DataAccessService, SimpleObjectService],
  bootstrap: [AppComponent]
})
export class AppModule {
}
