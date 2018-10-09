using System;
using System.Collections.Generic;

namespace WarehouseReqs.Models
{
    public partial class Requisition
    {
        public Requisition()
        {
            RequisitionItem = new HashSet<RequisitionItem>();
        }

        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Department { get; set; }
        public string Employee { get; set; }
        public bool? Filled { get; set; }
        public string Job { get; set; }
        public DateTime? UpdateDate { get; set; }
        //needs to be an IEnumerable
        public IEnumerable<RequisitionItem> RequisitionItem { get; set; }
    }
}
