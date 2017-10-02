import { MicroServicesTemplatePage } from './app.po';

describe('abp-project-name-template App', function() {
  let page: MicroServicesTemplatePage;

  beforeEach(() => {
    page = new MicroServicesTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
