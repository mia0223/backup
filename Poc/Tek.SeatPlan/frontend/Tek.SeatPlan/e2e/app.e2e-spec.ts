import { TekSeatPlanPage } from './app.po';

describe('tek.seat-plan App', () => {
  let page: TekSeatPlanPage;

  beforeEach(() => {
    page = new TekSeatPlanPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
