import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { YmapsHintContentComponent } from './ymaps-hint-content.component';

describe('YmapsHintContentComponent', () => {
  let component: YmapsHintContentComponent;
  let fixture: ComponentFixture<YmapsHintContentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ YmapsHintContentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(YmapsHintContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
