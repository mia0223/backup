/* tslint:disable:no-console */
import {ErrorHandler, Injectable} from "@angular/core";
import {ToasterService} from "angular2-toaster";
import {HttpError} from "../models/http-error";

@Injectable()
export class AppErrorHandler implements ErrorHandler {

  constructor(private toasterService: ToasterService) {
  }

  public handleError(error: any): void {
    switch (error.constructor) {
      case HttpError:
        this.toasterService.pop('error', '', error.message);
        this.consoleLog(error);
        break;
      default:
        this.consoleLog(error);
        break;
    }
  }

  private consoleLog(error: any) {
    console.log("%cError caught: " + new Date(), "color: red");
    console.log("%c======================================", "color: red");
    console.log(error);
    console.log("%c======================================", "color: red");
  }
}
