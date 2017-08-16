import {Injectable} from '@angular/core';
import {ConfigManagerService} from 'app/core/config-management/config-manager.service';
import {IKeyValue} from 'app/interfaces/key-value';
import {WindowRef} from '../window-reference.service';

@Injectable()
export class UrlHelper {
  private window: Window;
  constructor(private configManager: ConfigManagerService, _window: WindowRef ) {
    this.window = _window.getWindow();
  }

  public getUrl(key: string, params?: IKeyValue[]): string {
    return this.getServiceUrl(key, params);
  }

  protected getServiceUrl(service: string, params?: IKeyValue[]): string {
    let serviceUrl = this.configManager.getConfigValue(service);
    serviceUrl = this.parseUrl(serviceUrl, params);
    return serviceUrl;
  }

  protected parseUrl(url: string, params?: IKeyValue[]): string {
    if (url.search('%%DOMAIN%%') !== -1) {
      url = url.replace('%%DOMAIN%%', this.window.location.host);
    }

    if (url.search('%%PROTOCOL%%') !== -1) {
      url = url.replace('%%PROTOCOL%%', this.window.location.protocol);
    }

    if (params) {
      if (params.length === 1 && url.indexOf('?') < 0) {
        url += `/${params[0].value}`;
      } else {
        if (url.indexOf('?') < 0) {
          url += '?';
        }
        url += params.map((param: IKeyValue) => { return `${param.key}=${param.value}` }).join('&');
        ;
      }
    }
    return url;
  }
}
