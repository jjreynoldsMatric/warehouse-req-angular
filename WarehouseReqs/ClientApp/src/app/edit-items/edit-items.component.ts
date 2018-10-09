import { Component, Input, Output, EventEmitter, OnInit } from "@angular/core";
import { ReasonCodesProvider } from "../reason-codes.service";
import { ItemsProvider } from "../items.service";
import { FormGroup } from "@angular/forms";
import { RequisitionProvider } from "../requisition.service";
import { takeUntil } from "rxjs/operators"
import { Subject } from "rxjs"

@Component({
  selector: "edit-items",
  templateUrl: "./edit-items.component.html",
  styleUrls: ["./edit-items.component.css"]
})
export class EditItemsComponent implements OnInit {
  rc: any;
  @Input() newReqForm: FormGroup;
  @Output() remove: EventEmitter<number> = new EventEmitter<number>();
  @Input() index: number;
  itemDesc: any;
  opRequired: boolean;
  operList: any;
  unitOfMeasure: any;
  private _destroyed$ = new Subject();

  constructor(private reasonCodesService: ReasonCodesProvider, private itemServ: ItemsProvider, private reqService: RequisitionProvider) {
    this.reasonCodesService.loadReasonCodes();

  }

  ngOnInit() {
    //console.log(this.newReqForm);
    this.rc = this.newReqForm.controls["reasonCode"].value;


    let job = this.newReqForm.parent.parent.get("job").value;
    let item = this.newReqForm.get("item").value;
    if (item) {
      this.itemServ.getItemDescription(item).subscribe(res => {
        this.itemDesc = res.toString();
        takeUntil(this._destroyed$);
      }, err => {
        this.itemDesc = "Could not find this item";
        takeUntil(this._destroyed$);
        });
      this.reqService.getUnitOfMeasure(item).subscribe(res => {
        this.unitOfMeasure = res;
        takeUntil(this._destroyed$);
      });
    }
    if (job && item) {

      this.reqService.getOperNum(job).subscribe(res => {
        this.operList = res;
        takeUntil(this._destroyed$);
        //console.log(this.operNums);
      });
    }
  }

  public ngOnDestroy(): void {
    this._destroyed$.next();
  }

  isSelected(reasonCode) {
    if (reasonCode == this.rc) {
      return reasonCode;
    }

  }

  enterItem(item: string) {
    let job = this.newReqForm.parent.parent.get("job").value;

    if (item) {
      this.itemServ.getItemDescription(item).subscribe(res => {
        this.itemDesc = res.toString();
        takeUntil(this._destroyed$);
      }, err => {
        this.itemDesc = "Could not find this item";
        takeUntil(this._destroyed$);
      }
      );
    }
    if (job && item) {

      this.reqService.getOperNum(job).subscribe(res => {
        this.operList = res;
        //console.log(this.operNums);
        takeUntil(this._destroyed$);
      });
    }
    
  }

  getFormInfo() {
    let formInfo = this.newReqForm.parent.parent.get("job").value;
    console.log(`FORM INFO: ${JSON.stringify(formInfo)}`);
  }

  removeItem(index) {

    //let reqItems = this.newReqForm.parent.parent.value;
    //console.log(reqItems);
    this.remove.emit(this.index);

  }


}
