using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseReqs.Models
{
    public class OperNumViewModel
    {
        public string Job { get; set; }
        public int OperNum { get; set; }
        public string Item { get; set; }
        public byte? Complete { get; set; }
    }
}
