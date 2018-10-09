import { Component, OnInit } from "@angular/core";
import { RequisitionProvider } from "../requisition.service";
import { Router, ActivatedRoute } from "@angular/router";
import { takeUntil } from "rxjs/operators"
import { Subject } from "rxjs"

@Component({
  selector: "app-confirm-remove-item",
  templateUrl: "./confirm-remove-item.component.html",
  styleUrls: ["./confirm-remove-item.component.css"]
})
export class ConfirmRemoveItemComponent implements OnInit {
  reqId: number;
  reqItemId: number;
  errorMessage: any;
  private _destroyed$ = new Subject();

  constructor(public reqService: RequisitionProvider, public router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.reqId = +this.route.snapshot.paramMap.get("ReqId");
    this.reqItemId = +this.route.snapshot.paramMap.get("ReqItemId");
  }

  confirm() {

    this.reqService.removeReqItem(this.reqId, this.reqItemId).subscribe(response => {
      console.log(`Deleted Req Item: ${this.reqItemId} from Requisition ${this.reqId}`);
      console.log(response);
      this.router.navigate(["/edit", this.reqId]);
      takeUntil(this._destroyed$);
      return response;
    }, err => {
      this.errorMessage = err;
      console.error("Could not delete the req");
      takeUntil(this._destroyed$);
      return this.errorMessage;
    });

  }

  public ngOnDestroy(): void {
    this._destroyed$.next();
  }

  cancel() {
    this.router.navigate(["/edit", this.reqId]);
  }


}
