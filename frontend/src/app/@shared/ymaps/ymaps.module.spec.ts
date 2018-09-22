import { YmapsModule } from './ymaps.module';

describe('YmapsModule', () => {
  let ymapsModule: YmapsModule;

  beforeEach(() => {
    ymapsModule = new YmapsModule();
  });

  it('should create an instance', () => {
    expect(ymapsModule).toBeTruthy();
  });
});
