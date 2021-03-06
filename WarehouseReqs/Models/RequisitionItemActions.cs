﻿using System;
using System.Collections.Generic;

namespace WarehouseReqs.Models
{
    public partial class RequisitionItemActions
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
        public decimal? Quantity { get; set; }
        public int RequisitionitemId { get; set; }

        public RequisitionItem Requisitionitem { get; set; }
    }
}
