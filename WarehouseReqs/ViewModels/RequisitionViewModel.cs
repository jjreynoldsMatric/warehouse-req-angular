using System;
using System.Collections.Generic;
using WarehouseReqs.Models;

namespace WarehouseReqs.ViewModels
{
    public class RequisitionViewModel : Requisition {

        public IEnumerable<RequisitionItem> RequisitionItem {get; set;}
    }

    public class RequisitionItemWithLocationViewModel : RequisitionItem {
        
        public IEnumerable<ItemLocViewModel> ItemLocViewModel {get; set;}
    }
}