import { Component } from '@angular/core';
import {ToasterConfig} from "angular2-toaster";
import {ConfigManagerService} from "./core/config-management/config-manager.service";

@Component({
    selector: 'app-root',
    templateUrl: 'app.component.html'
})
export class AppComponent {
  toasterConfig: ToasterConfig;

  constructor(private configurationManager: ConfigManagerService){
    this.toasterConfig = new ToasterConfig(this.configurationManager.getConfigValue("toaster"));
  }
}
