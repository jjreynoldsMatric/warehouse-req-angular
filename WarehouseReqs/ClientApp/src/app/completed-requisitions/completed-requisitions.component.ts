import { Component, OnInit } from "@angular/core";
import { RequisitionProvider } from "../requisition.service";
import { ngxZendeskWebwidgetService } from "../../../node_modules/ngx-zendesk-webwidget";
import { Router } from "@angular/router";
import { takeUntil } from "rxjs/operators"
import { Subject } from "rxjs"

@Component({
  selector: "app-completed-requisitions",
  templateUrl: "./completed-requisitions.component.html",
  styleUrls: ["./completed-requisitions.component.css"]
})
export class CompletedRequisitionsComponent implements OnInit {

  requisitions: any;
  private _destroyed$ = new Subject();

  constructor(public reqService: RequisitionProvider, private _ngxZendeskWebwidgetService: ngxZendeskWebwidgetService, public router: Router) {
    _ngxZendeskWebwidgetService.show();
  }

  openFeedback() {
    this._ngxZendeskWebwidgetService.activate();
  }

  ngOnInit() {
    this.reqService.loadRequisitions().subscribe(response => {
      this.requisitions = response;
      //console.log(this.requisitions);
      takeUntil(this._destroyed$);
    });
  }
  manage(req) {
    let id = req.id;
    console.log(`THIS IS THE REQ${id}`);
    this.router.navigate(["/manage", id]);
  }

  public ngOnDestroy(): void {
    this._destroyed$.next();
  }
}
