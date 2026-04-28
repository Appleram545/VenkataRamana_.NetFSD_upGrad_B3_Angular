import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Contactdetail } from './contactdetail';

describe('Contactdetail', () => {
  let component: Contactdetail;
  let fixture: ComponentFixture<Contactdetail>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Contactdetail],
    }).compileComponents();

    fixture = TestBed.createComponent(Contactdetail);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
