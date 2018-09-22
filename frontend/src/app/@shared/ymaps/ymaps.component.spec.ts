import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { YmapsComponent } from './ymaps.component';

describe('YmapsComponent', () => {
  let component: YmapsComponent;
  let fixture: ComponentFixture<YmapsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ YmapsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(YmapsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
