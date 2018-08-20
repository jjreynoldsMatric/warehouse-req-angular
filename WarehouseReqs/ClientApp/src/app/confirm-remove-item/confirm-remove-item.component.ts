import { Component, OnInit } from "@angular/core";
import { RequisitionProvider } from "../requisition.service";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-confirm-remove-item",
  templateUrl: "./confirm-remove-item.component.html",
  styleUrls: ["./confirm-remove-item.component.css"]
})
export class ConfirmRemoveItemComponent implements OnInit {
  reqId: number;
  reqItemId: number;
    errorMessage: any;
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
        return response;
        
    }, err => {
      this.errorMessage = err;
      console.error("Could not delete the req");
      return this.errorMessage;
    });
    
  }

    cancel() {
        this.router.navigate(["/edit", this.reqId]);
    }
  

}
