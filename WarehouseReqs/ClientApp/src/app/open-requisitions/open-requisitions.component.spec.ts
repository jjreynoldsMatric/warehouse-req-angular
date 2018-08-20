import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { OpenRequisitionsComponent } from "./open-requisitions.component";

describe("OpenRequisitionsComponent", () => {
  let component: OpenRequisitionsComponent;
  let fixture: ComponentFixture<OpenRequisitionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OpenRequisitionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OpenRequisitionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
