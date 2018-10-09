import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { AppComponent } from "./app.component";
import { OpenRequisitionsComponent } from "./open-requisitions/open-requisitions.component";
import { CompletedRequisitionsComponent } from "./completed-requisitions/completed-requisitions.component";
import { EditComponent } from "./edit/edit.component";
import { ManageComponent } from "./manage/manage.component";
import { NewRequisitionComponent } from "./new-requisition/new-requisition.component";
import { ConfirmComponent } from "./confirm/confirm.component";
import { ConfirmRemoveItemComponent } from "./confirm-remove-item/confirm-remove-item.component";
import { CreateShortageComponent } from "./create-shortage/create-shortage.component";
import { EditItemsComponent } from "./edit-items/edit-items.component";
import { IssuePartsComponent } from "./issue-parts/issue-parts.component";
import { HttpClient, HttpClientModule } from "@angular/common/http";
import { ngxZendeskWebwidgetModule, ngxZendeskWebwidgetConfig } from "ngx-zendesk-webwidget";
import { FormsModule, ReactiveFormsModule } from "../../node_modules/@angular/forms";
import { RequisitionProvider } from "./requisition.service";
import { ReasonCodesProvider } from "./reason-codes.service";
import { ItemsProvider } from "./items.service";
import { EmployeeProvider } from "./employee.service";
import { ItemFormControlComponent } from "./item-form-control/item-form-control.component";
import { APP_BASE_HREF } from "@angular/common";
import { HelpComponent } from './help/help.component';
import { ModalComponent } from './modal/modal.component';
import { ModalService } from "./modal.service";

export class ZendeskConfig extends ngxZendeskWebwidgetConfig {
  accountUrl = "matric.zendesk.com";
  beforePageLoad(zE) {
    zE.setLocale("en");
    zE.hide();
  }
}

const routes: Routes = [
  { path: "", component: OpenRequisitionsComponent },
  { path: "open-requisitions", component: OpenRequisitionsComponent },
  { path: "completed-requisitions", component: CompletedRequisitionsComponent },
  { path: "manage/:ReqId", component: ManageComponent },
  { path: "edit/:ReqId", component: EditComponent },
  { path: "new-requisition", component: NewRequisitionComponent },
  { path: "issue-parts/:ReqId/:ReqItemId", component: IssuePartsComponent },
  { path: "create-shortage/:ReqId/:ReqItemId", component: CreateShortageComponent },
  { path: "confirm-remove-item/:ReqId/:ReqItemId", component: ConfirmRemoveItemComponent },
  { path: "confirm/:ReqId", component: ConfirmComponent },
  { path: "help", component: HelpComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    OpenRequisitionsComponent,
    CompletedRequisitionsComponent,
    EditComponent,
    ManageComponent,
    NewRequisitionComponent,
    ConfirmComponent,
    ConfirmRemoveItemComponent,
    CreateShortageComponent,
    EditItemsComponent,
    IssuePartsComponent,
    ItemFormControlComponent,
    HelpComponent,
    ModalComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes, {
      useHash: true
    }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ngxZendeskWebwidgetModule.forRoot(ZendeskConfig),

  ],
  entryComponents: [
    ItemFormControlComponent,
    AppComponent,
    OpenRequisitionsComponent,
    CompletedRequisitionsComponent,
    EditComponent,
    ManageComponent,
    NewRequisitionComponent,
    ConfirmComponent,
    ConfirmRemoveItemComponent,
    CreateShortageComponent,
    EditItemsComponent,
    IssuePartsComponent,
    HelpComponent
  ],
  exports: [],
  providers: [RequisitionProvider, ReasonCodesProvider, ItemsProvider, EmployeeProvider, { provide: APP_BASE_HREF, useValue: "/" }, ModalService],
  bootstrap: [AppComponent]
})
export class AppModule { }
