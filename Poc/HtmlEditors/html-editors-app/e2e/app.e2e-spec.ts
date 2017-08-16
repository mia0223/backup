import { HtmlEditorsAppPage } from './app.po';

describe('html-editors-app App', function() {
  let page: HtmlEditorsAppPage;

  beforeEach(() => {
    page = new HtmlEditorsAppPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
