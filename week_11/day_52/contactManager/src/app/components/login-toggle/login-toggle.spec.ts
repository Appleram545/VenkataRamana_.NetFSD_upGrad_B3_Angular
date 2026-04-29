import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginToggle } from './login-toggle';

describe('LoginToggle', () => {
  let component: LoginToggle;
  let fixture: ComponentFixture<LoginToggle>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LoginToggle],
    }).compileComponents();

    fixture = TestBed.createComponent(LoginToggle);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
