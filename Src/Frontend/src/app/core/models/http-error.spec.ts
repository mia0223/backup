import {HttpError} from './http-error';
describe('http-error', () => {
  let subjectUnderTest: HttpError;
  beforeEach(() => {
    subjectUnderTest = new HttpError();
  });

  it('should be created', () => {
    expect(subjectUnderTest).toBeTruthy();
  });

  it('should have HttpError prototype', () => {
    expect(subjectUnderTest instanceof HttpError).toBeTruthy();
  });

  it('should set default message for HttpError when no message id', () => {
    // arrange
    let errorResponse = {
      headers: {
        get: () => {
          return 'json/text'
        }
      },
      json: () => {
        return {message: 'test'}
      }
    };

    // act
    subjectUnderTest = new HttpError(errorResponse);

    // assert
    expect(subjectUnderTest.message).toEqual(HttpError.defaultMessage);
  });

  it('should set message with Id for HttpError when there is a message id', () => {
    // arrange
    let fakeID = '123';
    let errorResponse = {
      headers: {
        get: () => {
          return 'json/text'
        }
      },
      json: () => {
        return {message: fakeID + ':test'}
      }
    };

    // act
    subjectUnderTest = new HttpError(errorResponse);

    // assert
    expect(subjectUnderTest.message).toEqual(fakeID + HttpError.defaultMessage);
  });
})
;
