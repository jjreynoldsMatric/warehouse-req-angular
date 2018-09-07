import { Component, Input, Output, EventEmitter, OnInit } from "@angular/core";
import { ReasonCodesProvider } from "../reason-codes.service";
import { ItemsProvider } from "../items.service";
import { FormGroup } from "@angular/forms";

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
  reqItems: any;
  constructor(private reasonCodesService: ReasonCodesProvider, private itemServ: ItemsProvider) {
    this.reasonCodesService.loadReasonCodes();

  }

  ngOnInit() {
    //console.log(this.newReqForm);
    this.rc = this.newReqForm.controls["reasonCode"].value;
    //console.log(this.rc);
  }

  isSelected(reasonCode) {
    if (reasonCode == this.rc) {
      return reasonCode;
    }

  }

  enterItem(item: string) {
    if (item) {
      this.itemServ.getItemDescription(item).subscribe(res => {
        this.itemDesc = res.toString();
      }, err => {
        this.itemDesc = "Could not find this item";
      }
      );
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
