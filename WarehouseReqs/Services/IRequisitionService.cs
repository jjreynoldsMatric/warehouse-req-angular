using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseReqs.Models;
using WarehouseReqs.ViewModels;

namespace WarehouseReqs.Services
{
    public interface IRequisitionService
    {       
        IEnumerable<RequisitionViewModel> GetRequisitions();
        IEnumerable<RequisitionViewModel> GetOpenRequisitions();
        IEnumerable<RequisitionViewModel> GetCompletedRequisitions();
        IEnumerable<EmployeeViewModel> GetEmployee();
        IEnumerable<EmployeeViewModel> GetWhseEmployees();
        //IEnumerable<ReasonCode> GetReasonCodes();
        List<string> GetReasonCodes();
        IEnumerable<ItemLocViewModel> GetLocation(int itemReqId);
        IEnumerable<ItemLocViewModel> GetLocationNoQuantity(int itemReqId);
        Requisition NewRequisition(Requisition requisition);
        Requisition CreateShortage(PartRequest partRequest);
        Requisition IssuePart(PartRequest partRequest);
        bool DeleteReq(string itemReqId);
        Requisition GetRequisition(int itemReqId);
        string GetItemDescription(string item);
        IEnumerable<ItemLotLocViewModel> GetItemLot(int itemReqId);
        bool UpdateRequisition(Requisition updatedReq);
        bool RemoveReqItem(int reqId, int reqItemId);
        RequisitionItem GetRequisitionItem(int reqItemId);
        List<OperationSelectViewModel> GetOperNumByJob(string jobNum);
        bool IsJobValid(string jobNum);
        string GetUnitOfMeasure(string item);
        
    }
}