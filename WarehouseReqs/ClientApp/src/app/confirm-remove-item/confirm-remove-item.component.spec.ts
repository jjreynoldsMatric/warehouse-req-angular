import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ConfirmRemoveItemComponent } from "./confirm-remove-item.component";

describe("ConfirmRemoveItemComponent", () => {
  let component: ConfirmRemoveItemComponent;
  let fixture: ComponentFixture<ConfirmRemoveItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfirmRemoveItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfirmRemoveItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
