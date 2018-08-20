import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { CompletedRequisitionsComponent } from "./completed-requisitions.component";

describe("CompletedRequisitionsComponent", () => {
  let component: CompletedRequisitionsComponent;
  let fixture: ComponentFixture<CompletedRequisitionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompletedRequisitionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompletedRequisitionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
