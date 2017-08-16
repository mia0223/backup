import {Observable, Subscription} from "rxjs";
export class Utils {
  public static unsubscribeFromObservable(subscription: Subscription) {
    if (!!subscription && subscription instanceof Subscription)
      subscription.unsubscribe();
  }

  public static isJsonResponse(response: Response) {
    return !!response &&
            !!response.headers &&
            !!response.headers.get('content-type') &&
            response.headers.get('content-type').indexOf('json') > -1;
  }

  public static isErrorResponse(response: any) {
    return Utils.isJsonResponse(response) && !!response.json().message;
  }
}
