import {Injectable} from '@angular/core';
import {ApiHttp} from 'app/core/api-http/api-http.service';
import {IKeyValue} from 'app/interfaces/key-value';

import 'rxjs/add/operator/toPromise';

@Injectable()
export class ConfigManagerService {

  private configs: IKeyValue[];
  private isConfigLoaded: boolean = false;

  constructor(private http: ApiHttp) {
  }

  public load() {
    return this.http.get('assets/config.json').toPromise().then(
      res => {
        this.configs = res.json();
        this.isConfigLoaded = true;
      },
    );
  }

  public isLoaded(): boolean {
    return this.isConfigLoaded;
  }

  public getConfigValue(key: string) {
    let v = this.configs.find((r) => r.key === key);
    return !!v ? v.value : '';
  }
}
