import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { CreateShortageComponent } from "./create-shortage.component";

describe("CreateShortageComponent", () => {
  let component: CreateShortageComponent;
  let fixture: ComponentFixture<CreateShortageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateShortageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateShortageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
