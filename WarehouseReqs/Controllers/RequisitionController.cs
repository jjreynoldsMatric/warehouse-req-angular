using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WarehouseReqs.Models;
using WarehouseReqs.Services;
using WarehouseReqs.ViewModels;

namespace WarehouseReqs.Controllers
{
   
    public class RequisitionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IRequisitionService _requisitionService;

        public RequisitionController(IRequisitionService requisitionService)
        {
            _requisitionService = requisitionService ?? throw new ArgumentNullException(nameof(requisitionService));
        }

        public IActionResult GetOpenRequisitions()
        {
            ViewBag.Title = "Open Requisitions";
            var reqs = _requisitionService.GetOpenRequisitions();
            return View(reqs);
        }

        [HttpGet("/api/requisitions/All")]
        public IActionResult Requisition()
        {
            var requisitions = _requisitionService.GetRequisitions();
            return Ok(requisitions);
        }

        [HttpGet("/api/requisitions/{itemReqId}")]
        public JsonResult GetRequisition(int itemReqId)
        {
            try
            {
                var getreq = _requisitionService.GetRequisition(itemReqId);
                return Json(getreq);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpGet("/api/requisitions/items/{reqItemId}")]
        public JsonResult GetRequisitionItem(int reqItemId)
        {
            try
            {
                var getreq = _requisitionService.GetRequisitionItem(reqItemId);
                return Json(getreq);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }


        [HttpGet("/api/employees")]
        public JsonResult Employees()
        {
            var employees = _requisitionService.GetEmployee();
            return Json(employees);
        }

        [HttpGet("/api/employees/WhseEmployees")]
        public JsonResult WhseEmployees()
        {
            var whseEmployees = _requisitionService.GetWhseEmployees();
            return Json(whseEmployees);
        }

        [HttpGet("/api/ReasonCodes")]
        public JsonResult ReasonCodes()
        {
            var reasonCodes = _requisitionService.GetReasonCodes();
            return Json(reasonCodes);
        }

        [HttpPost("/api/requisitions/Save")]
        public JsonResult NewRequisition([FromBody]Requisition requisition)
        {
            try
            {
                var newRequisition = _requisitionService.NewRequisition(requisition);
                return Json(newRequisition);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost("/api/requisitions/Shortage")]
        public JsonResult CreateShortage([FromBody] PartRequest partRequest)
        {
            try
            {
                var createShortage = _requisitionService.CreateShortage(partRequest);
                return Json(createShortage);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost("/api/requisitions/Issue")]
        public JsonResult IssuePart([FromBody] PartRequest partRequest)
        {
            try
            {
                var issuePart = _requisitionService.IssuePart(partRequest);
                return Json(issuePart);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }


        [HttpGet("/api/items/Location")]
        public JsonResult Location(int itemReqId)
        {
            var locations = _requisitionService.GetLocation(itemReqId);
            return Json(locations);
        }

        [HttpGet("/api/items/ShortageLocation/{reqItemId}")]
        public JsonResult ShortageLocation(int reqItemId)
        {
            var locations = _requisitionService.GetLocationNoQuantity(reqItemId);
            return Json(locations);
        }

        [HttpDelete("/api/requisitions/Delete/{ReqId}")]
        public JsonResult DeleteReq(string reqId)
        {
            try
            {
                var deleteReq = _requisitionService.DeleteReq(reqId);
                return Json(deleteReq);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }


        [HttpGet("/api/items/{item}")]
        public JsonResult GetItemDescription(string item)
        {
            try
            {
                var getItemDesc = _requisitionService.GetItemDescription(item);
                return Json(getItemDesc);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpGet("/api/items/ItemLot/{ReqItemId}")]
        public JsonResult GetItemLot(int reqItemId)
        {
            try
            {
                var getItemLot = _requisitionService.GetItemLot(reqItemId);
                return Json(getItemLot);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPatch("/api/requisitions/Update")]
        public JsonResult UpdateReq([FromBody] Requisition updatedReq)
        {
            try
            {
                var update = _requisitionService.UpdateRequisition(updatedReq);
                return Json(update);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpDelete("/api/requisitions/RemoveReqItem/{ReqId}/{ReqItemId}")]
        public JsonResult RemoveReqItem(int reqId, int reqItemId)
        {
            try
            {
                var remove = _requisitionService.RemoveReqItem(reqId, reqItemId);
                return Json(remove);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpGet("/api/requisitions/GetOper/{jobNum}/{itemNum}")]
        public JsonResult GetOperNum(string jobNum, string itemNum)
        {
            try
            {
                var oper = _requisitionService.GetOperNumByJobAndItem(jobNum, itemNum);
                return Json(oper);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpGet("/api/requisitions/job/{jobNum}")]
        public JsonResult IsJobValid(string jobNum)
        {
            try
            {
                var job = _requisitionService.IsJobValid(jobNum);
                return Json(job);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
