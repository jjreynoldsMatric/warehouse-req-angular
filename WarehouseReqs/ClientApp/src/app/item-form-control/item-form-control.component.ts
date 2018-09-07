import { Component, OnInit, Input } from "@angular/core";
import { ReasonCodesProvider } from "../reason-codes.service";
import { ItemsProvider } from "../items.service";
import { FormGroup, FormArray, ReactiveFormsModule } from "@angular/forms";
import { RequisitionProvider } from "../requisition.service";

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
  operNums: any;
  constructor(private reasonCodesService: ReasonCodesProvider, private itemServ: ItemsProvider, private reqService: RequisitionProvider) {
    this.reasonCodesService.loadReasonCodes();
  }

  ngOnInit() {
  }
  enterItem(item: string) {

    let job = this.newReqForm.parent.parent.get("job").value;

    //START ITEM DESC
    if (item) {
      this.itemServ.getItemDescription(item).subscribe(res => {
        this.itemDesc = res.toString();
      }, err => {
        this.itemDesc = "Could not find this item";
      }
      );
    }
    //END ITEM DESC
    if (job && item) {

      this.reqService.getOperNum(job, item).subscribe(res => {
        this.operNums = res;
        //console.log(this.operNums);
      });
    }
  }
  removeItem(index) {
    const arrayControl = <FormArray>this.newReqForm.parent;
    arrayControl.removeAt(this.index);
  }
}
