using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WarehouseReqs.Models;

namespace WarehouseReqs.ViewModels
{
    public class CreateReqViewModel
    {
        public CreateReqViewModel()
        {

        }
        public CreateReqViewModel(NewRequisitionViewModel nrvm)
        {
            NewReq = nrvm;
        }
        public CreateReqViewModel(NewRequisitionViewModel nrvm, AddRequisitionItemViewModel arivm)
        {
            NewReq = nrvm;
            AddRequisitionItemViewModels.Add(arivm);
        }
        public NewRequisitionViewModel NewReq{ get; set; }
        public Collection<AddRequisitionItemViewModel> AddRequisitionItemViewModels { get; set; }
        public AddRequisitionItemViewModel NewItem { get; set; }
    }
    public class NewRequisitionViewModel
    {
        public string SelectedEmployee { get; set; }
        public IEnumerable<SelectListItem> Employees { get; set; }

        public string Department { get; set; }

        public string Job { get; set; }
        IEnumerable<RequisitionItem> RequisitionItem { get; set; }

    }

    


}
