import {Utils} from '../utils/utils';
export class HttpError extends Error {
  public static defaultMessage = 'Something went wrong. Please try again!';
  public innerStack: string;

  static getErrorMessageID(errorResponse: any) {
    if (Utils.isErrorResponse(errorResponse)) {
      const messageParts = errorResponse.json().message.split(':');
      if (messageParts.length > 1) {
        return messageParts[0] + HttpError.defaultMessage;
      }
    }
    return HttpError.defaultMessage;
  }

  constructor(error?: any) {
    super(HttpError.getErrorMessageID(error));
    Object.setPrototypeOf(this, HttpError.prototype);
    this.innerStack = error;
  }
}
