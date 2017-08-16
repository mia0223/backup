import { Http, RequestMethod, RequestOptions, RequestOptionsArgs, Headers, Request, Response } from "@angular/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Rx";
import {HttpError} from "../models/http-error";

@Injectable()
export class ApiHttp {
    constructor(
        private http: Http
    ) { }

    public get(
        url: string,
        options?: RequestOptionsArgs
    ): Observable<Response> {
        return this.intercept(RequestMethod.Get, url, null, options);
    }

    public post(
        url: string,
        body: string,
        options?: RequestOptionsArgs
    ): Observable<Response> {
        return this.intercept(RequestMethod.Post, url, body, options);
    }

    public put(
        url: string,
        body: string,
        options?: RequestOptionsArgs
    ): Observable<Response> {
        return this.intercept(RequestMethod.Put, url, body, options);
    }

    public delete(
      url: string,
      options?: RequestOptionsArgs
    ): Observable<Response> {
      return this.intercept(RequestMethod.Delete, url, null, options);
    }

    private intercept(
        method: RequestMethod,
        url: string,
        body?: string,
        options?: RequestOptionsArgs
    ): Observable<Response> {
        let headers = new Headers();
        headers.set("Content-Type", "application/json");

        let args = new RequestOptions({
            headers: headers,
            method: method,
            url: url,
            body: body
        });

        this.showLoading();

        return Observable.create((observer) => {
            this
                .http
                .request(new Request(args.merge(options)))
                .subscribe(
                    (res) => {
                        this.hideLoading();
                        observer.next(res);
                        observer.complete();
                    },
                    (err) => {
                        this.hideLoading();
                        throw new HttpError(err);
                    }
                )
        })
    }

    private showLoading() {
        //TODO: show loading
    }

    private hideLoading() {
        //TODO: hide loading
    }
}
