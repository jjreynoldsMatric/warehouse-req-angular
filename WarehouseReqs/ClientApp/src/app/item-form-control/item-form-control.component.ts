import { Component, OnInit, Input } from "@angular/core";
import { ReasonCodesProvider } from "../reason-codes.service";
import { ItemsProvider } from "../items.service";
import { FormGroup, FormArray, ReactiveFormsModule } from "@angular/forms";
import { RequisitionProvider } from "../requisition.service";
import { takeUntil } from "rxjs/operators"
import { Subject } from "rxjs"

@Component({
  selector: "item-form-control",
  templateUrl: "./item-form-control.component.html",
  styleUrls: ["./item-form-control.component.css"]
})
export class ItemFormControlComponent implements OnInit {

  @Input("ReqForm") newReqForm: FormGroup;
  @Input() index: number;
  itemDesc: any;
  opRequired: boolean;
  operList: any;
  unitOfMeasure: any;
  reasonCodes: any;
  private _destroyed$ = new Subject();

  constructor(private reasonCodesService: ReasonCodesProvider, private itemServ: ItemsProvider, private reqService: RequisitionProvider) {
    
  }

  ngOnInit() {
    this.reasonCodesService.loadReasonCodes().subscribe(response => {
      this.reasonCodes = response;
    });
  }
  enterItem(item: string) {

    let job = this.newReqForm.parent.parent.get("job").value;

    //START ITEM DESC
    if (item) {
      this.itemServ.getItemDescription(item).subscribe(res => {
        this.itemDesc = res.toString();
      }, err => {
        this.itemDesc = "Could not find this item";
        });
      this.reqService.getUnitOfMeasure(item).subscribe(res => {
        this.unitOfMeasure = res;
      });
    }
    //END ITEM DESC
    if (job && item) {

      this.reqService.getOperNum(job).subscribe(res => {
        this.operList = res;
        console.log(this.operList);
      });
      
    }

  }
  public ngOnDestroy(): void {
    this._destroyed$.next();
  }
  removeItem(index) {
    const arrayControl = <FormArray>this.newReqForm.parent;
    arrayControl.removeAt(this.index);
  }
}
