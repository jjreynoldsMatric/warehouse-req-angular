using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseReqs.ViewModels
{
    public class AddRequisitionItemViewModel
    {
        public string Item { get; set; }
        public string Quantity { get; set; }
        public string Operation { get; set; }
        public string SelectedReasonCode { get; set; }
        public IEnumerable<SelectListItem> ReasonCodes { get; set; }
    }
}
