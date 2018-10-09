using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
using Newtonsoft.Json;
using WarehouseReqs.Models;
using WarehouseReqs.ViewModels;

namespace WarehouseReqs.Services
{
    public class RequisitionService : IRequisitionService
    {
        public IEnumerable<RequisitionViewModel> GetRequisitions()
        {
            using (var matContext = new MatAppContext())
            {
                using (var requisitionContext = new WarehouseRequisitionContext())
                {
                    var location = matContext.Itemloc.Where(i => i.QtyOnHand > 0).ToList();

                    var requisitionsWithLocation = from r in requisitionContext.Requisition
                                                   select new RequisitionViewModel
                                                   {
                                                       Id = r.Id,
                                                       Job = r.Job,
                                                       Department = r.Department,
                                                       CreateDate = r.CreateDate,
                                                       Employee = r.Employee,
                                                       Filled = r.Filled,
                                                       RequisitionItem = from ri in requisitionContext.RequisitionItem
                                                                         where ri.RequisitionId == r.Id
                                                                         select new RequisitionItemWithLocationViewModel
                                                                         {
                                                                             Id = ri.Id,
                                                                             Item = ri.Item,
                                                                             ItemDescription = ri.ItemDescription,
                                                                             Lot = ri.Lot,
                                                                             Operation = ri.Operation,
                                                                             Quantity = ri.Quantity,
                                                                             QuantityFilled = ri.QuantityFilled,
                                                                             ReasonCode = ri.ReasonCode,
                                                                             RequisitionId = ri.RequisitionId,
                                                                             Filled = ri.Filled,
                                                                             Unitcost = ri.Unitcost,
                                                                             Totalcost = ri.Unitcost * ri.Quantity,
                                                                             Backflush = ri.Backflush,
                                                                             LotTracked = ri.LotTracked,
                                                                             SerialTracked = ri.SerialTracked,
                                                                             CycleCounted = ri.CycleCounted,
                                                                             ItemLocViewModel = from l in location
                                                                                                where l.Item == ri.Item
                                                                                                select new ItemLocViewModel
                                                                                                {
                                                                                                    Item = l.Item,
                                                                                                    Rank = l.Rank,
                                                                                                    QtyOnHand = l.QtyOnHand,
                                                                                                    Location = l.Loc
                                                                                                }
                                                                         }
                                                   };
                    return requisitionsWithLocation.ToList();
                }
            }
        }
        public Requisition GetRequisition(int itemReqId)
        {
            using (var matContext = new MatAppContext())
            {
                using (var requisitionContext = new WarehouseRequisitionContext())
                {
                    var location = matContext.Itemloc.Where(i => i.QtyOnHand > 0).ToList();
                    var singleReq = from r in requisitionContext.Requisition
                                    where r.Id == itemReqId
                                    select new Requisition
                                    {
                                        Id = r.Id,
                                        Job = r.Job,
                                        Department = r.Department,
                                        CreateDate = r.CreateDate,
                                        Employee = r.Employee,
                                        Filled = r.Filled,
                                        RequisitionItem = from ri in requisitionContext.RequisitionItem
                                                          where ri.RequisitionId == itemReqId
                                                          select new RequisitionItemWithLocationViewModel
                                                          {
                                                              Id = ri.Id,
                                                              Item = ri.Item,
                                                              ItemDescription = ri.ItemDescription,
                                                              Lot = ri.Lot,
                                                              Operation = ri.Operation,
                                                              Quantity = ri.Quantity,
                                                              QuantityFilled = ri.QuantityFilled,
                                                              ReasonCode = ri.ReasonCode,
                                                              RequisitionId = ri.RequisitionId,
                                                              Filled = ri.Filled,
                                                              Unitcost = ri.Unitcost,
                                                              Totalcost = ri.Unitcost * ri.Quantity,
                                                              Backflush = ri.Backflush,
                                                              LotTracked = ri.LotTracked,
                                                              SerialTracked = ri.SerialTracked,
                                                              CycleCounted = ri.CycleCounted,
                                                              ItemLocViewModel = from l in location
                                                                                 where l.Item == ri.Item
                                                                                 select new ItemLocViewModel
                                                                                 {
                                                                                     Item = l.Item,
                                                                                     Rank = l.Rank,
                                                                                     QtyOnHand = l.QtyOnHand,
                                                                                     Location = l.Loc
                                                                                 }               
                                                          }

                                    };
                    
                    return singleReq.FirstOrDefault();
                }
            }
        }

        public RequisitionItem GetRequisitionItem(int reqItemId)
        {
            using (var matContext = new MatAppContext())
            {
                using (var requisitionContext = new WarehouseRequisitionContext())
                {
                    var location = matContext.Itemloc.Where(i => i.QtyOnHand > 0).ToList();

                    var singleReqItem = from ri in requisitionContext.RequisitionItem
                                        where ri.Id == reqItemId
                                        select new RequisitionItemWithLocationViewModel
                                        {
                                            Id = ri.Id,
                                            Item = ri.Item,
                                            ItemDescription = ri.ItemDescription,
                                            Lot = ri.Lot,
                                            Operation = ri.Operation,
                                            Quantity = ri.Quantity,
                                            QuantityFilled = ri.QuantityFilled,
                                            ReasonCode = ri.ReasonCode,
                                            RequisitionId = ri.RequisitionId,
                                            Filled = ri.Filled,
                                            Unitcost = ri.Unitcost,
                                            Totalcost = ri.Unitcost * ri.Quantity,
                                            Backflush = ri.Backflush,
                                            LotTracked = ri.LotTracked,
                                            SerialTracked = ri.SerialTracked,
                                            CycleCounted = ri.CycleCounted,
                                            ItemLocViewModel = from l in location
                                                               where l.Item == ri.Item
                                                               select new ItemLocViewModel
                                                               {
                                                                   Item = l.Item,
                                                                   Rank = l.Rank,
                                                                   QtyOnHand = l.QtyOnHand,
                                                                   Location = l.Loc
                                                               }
                                        };
                    return singleReqItem.FirstOrDefault();
                }
            }
        }

        public IEnumerable<RequisitionViewModel> GetCompletedRequisitions()
        {
            using (var matContext = new MatAppContext())
            {
                using (var requisitionContext = new WarehouseRequisitionContext())
                {
                    var location = matContext.Itemloc.Where(i => i.QtyOnHand > 0).ToList();
                    
                    var requisitions = from r in requisitionContext.Requisition
                                                   select new RequisitionViewModel
                                                   {
                                                       Id = r.Id,
                                                       Job = r.Job,
                                                       Department = r.Department,
                                                       CreateDate = r.CreateDate,
                                                       Employee = r.Employee,
                                                       Filled = r.Filled,
                                                   };
                    var completedReqs = requisitions.Where(r => r.Filled == true);
                    return completedReqs.ToList();
                }
            }
        }
        public IEnumerable<RequisitionViewModel> GetOpenRequisitions()
        {
            using (var matContext = new MatAppContext())
            {
                using (var requisitionContext = new WarehouseRequisitionContext())
                {
                    var location = matContext.Itemloc.Where(i => i.QtyOnHand > 0).ToList();

                    var requisitionsWithLocation = from r in requisitionContext.Requisition
                                                   select new RequisitionViewModel
                                                   {
                                                       Id = r.Id,
                                                       Job = r.Job,
                                                       Department = r.Department,
                                                       CreateDate = r.CreateDate,
                                                       Employee = r.Employee,
                                                       Filled = r.Filled,
                                                   };
                    var openReqs = requisitionsWithLocation.Where(r => r.Filled == false);
                    return openReqs.ToList();
                }
            }
        }

        public bool IsJobValid(string jobNum)
        {
            using (var matContext = new MatAppContext())
            {
                var job = matContext.Job.Where(j => j.Job1.TrimStart() == jobNum && j.Stat == "R").FirstOrDefault();

                //If job does not exist add an error.
                if (job == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public Requisition NewRequisition(Requisition requisition)
        {
            using (var matContext = new MatAppContext())
            {
                var errors = new List<string>();
                var jobValid = false;


                //If the user enters a job...
                if (requisition.Job.Length > 0)
                {
                    requisition.Job = requisition.Job.Trim();
                    //Check if job exist and has status of released.
                    var job = matContext.Job.Where(j => j.Job1.TrimStart() == requisition.Job && j.Stat == "R").FirstOrDefault();

                    //If job does not exist add an error.
                    if (job == null)
                    {
                        errors.Add("Job: " + job + " is not a valid released job.");
                        jobValid = false;
                    }
                    else
                    {
                        jobValid = true;
                    }
                }

                //Create new requisition.
                var newRequisition = new Requisition
                {
                    Employee = requisition.Employee,
                    Department = requisition.Department,
                    Job = requisition.Job,
                    Filled = false,
                    CreateDate = DateTime.Now
                };

                //List to store the requisition items
                var requisitionItems = new List<RequisitionItem>();

                //for each requisition item (child component of item, operation, lot, quantity, etc) that is passed from client
                foreach (var item in requisition.RequisitionItem)
                {
                    //check if item exists
                    var itemExists = matContext.Item.Where(i => i.Item1 == item.Item).FirstOrDefault();
                    //check if item is cycle counted
                    var cycle = matContext.Cycle.Where(i => i.Item == itemExists.Item1 && i.Stat == "C").FirstOrDefault();
                    byte cycleCounted;
                    if (jobValid)
                    {

                        if (item.Operation == "")
                        {
                            errors.Add("Please enter an operation");
                        }
             
                    }
                    if (item.Quantity <= 0)
                    {
                        errors.Add("Quantity must be a positive number");
                    }
                    if (cycle == null)
                    {
                        cycleCounted = 0;
                    }
                    else
                    {
                        cycleCounted = 1;
                    }

                    //if item does not exist add error
                    if (itemExists == null)
                    {
                        errors.Add("The item: " + item.Item + " is not a valid item.");
                    }
                    else
                    {
                        //create new requisition item
                        var requisitionItem = new RequisitionItem()
                        {
                            Item = item.Item,
                            Quantity = item.Quantity,
                            ReasonCode = item.ReasonCode,
                            Operation = item.Operation,
                            ItemDescription = itemExists.Description,
                            QuantityFilled = 0,
                            Filled = false,
                            Unitcost = itemExists.UnitCost,
                            Backflush = itemExists.Backflush,
                            SerialTracked = itemExists.SerialTracked,
                            LotTracked = itemExists.LotTracked,
                            CycleCounted = cycleCounted
                        };
                        //add it to list
                        requisitionItems.Add(requisitionItem);
                    }
                    
                }

                //if more than one requisition item has been added, add them back to the original requsition.
                if (requisitionItems.Count > 0)
                {
                    newRequisition.RequisitionItem = requisitionItems;
                }

                //if any errors have been added to the errors list, return bad request.
                if (errors.Count > 0)
                {
                    string errorStr = String.Join("\n", errors);
                    throw new Exception(errorStr);
                }


                //if no errors have been added insert into database.
                using (var requisitionContext = new WarehouseRequisitionContext())
                {
                    try
                    {
                        requisitionContext.Add(newRequisition);
                        requisitionContext.SaveChanges();
                        return newRequisition;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public Requisition CreateShortage(PartRequest partRequest)
        {
            using (var matContext = new MatAppContext())
            {
                using (var requisitionContext = new WarehouseRequisitionContext())
                {
                    var errors = new List<string>();

                    var requisitionItem = requisitionContext.RequisitionItem.Where(r => r.Id == partRequest.ItemReqId).FirstOrDefault();
                    var requisition = requisitionContext.Requisition.Where(r => r.RequisitionItem.Any(ri => ri.Id == partRequest.ItemReqId)).FirstOrDefault();
                    var item = matContext.Item.Where(i => i.Item1 == requisitionItem.Item).FirstOrDefault();

                    var requisitionId = requisitionContext.RequisitionItem.Where(r => r.Id == partRequest.ItemReqId).FirstOrDefault().RequisitionId;

                    var requisitionItems = requisitionContext.RequisitionItem.Where(r => r.RequisitionId == requisitionId).ToList();

                    if (requisition != null)
                    {
                        if (requisitionItem != null)
                        {
                            if (item != null)
                            {
                                var insertItem = new InsertItem
                                {
                                    Quantity = partRequest.Quantity,
                                    Job = requisition.Job,
                                    OperNum = requisitionItem.Operation,
                                    Item = requisitionItem.Item,
                                    Loc = partRequest.Location,
                                    Um = item.Um,
                                    Lot = partRequest.Lot,
                                    Reasoncode = requisitionItem.ReasonCode,
                                    ProcessedBy = partRequest.ProcessedBy.Split(':')[0]
                                };

                                if (partRequest.Quantity <= 0)
                                {
                                    errors.Add("Quantity must be a positive number");
                                }

                                var result = CreateShortage(insertItem);

                                if (result == 1)
                                {
                                    //CreateShortage(partRequest.quantity, requisition.Job, requisitionItem.Operation, requisitionItem.Item, partRequest.location, item.UM, partRequest.lot);

                                    RequisitionItemActions requisitionItemActions = new RequisitionItemActions
                                    {
                                        Action = "shortage",
                                        RequisitionitemId = requisitionItem.Id,
                                        Quantity = partRequest.Quantity,
                                        ActionBy = partRequest.ProcessedBy,
                                        ActionDate = DateTime.Now
                                    };

                                    requisitionItem.QuantityFilled += partRequest.Quantity;

                                    if (requisitionItem.QuantityFilled == requisitionItem.Quantity)
                                    {
                                        requisitionItem.Filled = true;
                                    }

                                    if ((requisitionItems.Count() == 1) && (requisitionItem.Filled == true))
                                    {

                                        requisition.Filled = true;

                                    }
                                    //if wholeReq.reqItem >= 1;
                                    //if for reqitem in wholeReq, if reqItem.filled ==true, req.filled = true. else, break

                                    ////MAYBE CONVERT TO CASE STATEMENT LATER
                                    if (requisitionItems.Count() > 1)
                                    {
                                        for (int i = 0; i < requisitionItems.Count(); i++)
                                        {

                                            if (requisitionItems[i].Filled == false)
                                            {
                                                requisition.Filled = false;
                                                break;
                                            }
                                            else
                                            {
                                                requisition.Filled = true;
                                            }
                                        }
                                    }
                                    //if any errors have been added to the errors list, return bad request.
                                    if (errors.Count > 0)
                                    {
                                        string errorStr = String.Join("\n", errors);
                                        throw new Exception(errorStr);
                                    }

                                    try
                                    {
                                        requisitionContext.Update(requisition);
                                        requisitionContext.Update(requisitionItem);
                                        requisitionContext.Update(requisitionItemActions);
                                        requisitionContext.SaveChanges();
                                        return requisitionContext.Requisition.Where(i => i.Id == requisitionItem.Id).FirstOrDefault();
                                    }
                                    catch (Exception ex)
                                    {
                                        throw ex;
                                    }
                                }
                            }
                        }
                    }

                    throw new Exception("No requisition found with id " + Convert.ToString(partRequest.ItemReqId));
                }
            }
        }
        //decimal quantity, string job, string oper_num, string item, string loc, string u_m, string lot
        internal int CreateShortage(InsertItem insertItem)
        {
            using (var matContext = new MatAppContext())
            {
                var errors = new List<string>();

                if (insertItem.Quantity <= 0)
                {
                    errors.Add("Quantity must be a positive number");
                }
                try
                {
                    if (insertItem.Job.Length > 0)
                    {
                        var dcjmId = matContext.Database.ExecuteSqlCommand(@"INSERT INTO dcjm (trans_type, stat, trans_date, job, suffix, oper_num, item, whse, loc, qty, u_m, lot, override, emp_num)
                            VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}); 
                            SELECT CAST(scope_identity() AS int)", insertItem.Quantity > 0 ? "1" : "2", "U", DateTime.Now, insertItem.Job.PadLeft(10), 0, (insertItem.OperNum != null ? Convert.ToInt32(insertItem.OperNum) : (int?)null), insertItem.Item, "MAIN", insertItem.Loc, insertItem.Quantity, insertItem.Um, (!String.IsNullOrWhiteSpace(insertItem.Lot)) ? insertItem.Lot.ToString() : null, 1, insertItem.ProcessedBy.PadLeft(7));

                        var dcjm = matContext.Dcjm.Where(i => i.TransNum == dcjmId).FirstOrDefault();

                        if (dcjm.ErrorMessage != null)
                        {
                            errors.Add(dcjm.ErrorMessage);
                        }

                    }
                    else
                    {
                        Random random = new Random();
                        int rand_trans_num = random.Next(1, 10000);
                        matContext.Database.ExecuteSqlCommand(@"INSERT INTO dcitem (trans_num, trans_type, stat, trans_date, item, whse, loc, count_qty, u_m, lot, reason_code, emp_num) 
                        VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11})", rand_trans_num, insertItem.Quantity > 0 ? "2" : "3", "U", DateTime.Now, insertItem.Item, "MAIN", insertItem.Loc, insertItem.Quantity, insertItem.Um, (!String.IsNullOrWhiteSpace(insertItem.Lot)) ? insertItem.Lot.ToString() : null, insertItem.Reasoncode.Substring(0, insertItem.Reasoncode.IndexOf("-")).Trim(), insertItem.ProcessedBy.PadLeft(7));

                        var dcitem = matContext.Dcitem.Where(i => i.TransNum == rand_trans_num).FirstOrDefault();
                        if (dcitem?.ErrorMessage != null)
                        {
                            errors.Add(dcitem.ErrorMessage);
                        }

                    }
                    //if any errors have been added to the errors list, return bad request.
                    if (errors.Count > 0)
                    {
                        string errorStr = String.Join("\n", errors);
                        throw new Exception(errorStr);
                    }
                    return 1;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public IEnumerable<EmployeeViewModel> GetEmployee()
        {
            using (var matContext = new MatAppContext())
            {
                var employees = matContext.Employee
                .Where(emp => emp.TermDate == null)
                .Select(emp => new EmployeeViewModel
                {
                    EmpFull = emp.EmpNum + ": " + emp.Fname + ' ' + emp.Lname,
                    EmpDept = emp.Dept

                });

                var empList = employees.ToList();
                return empList;

            }
        }

        public IEnumerable<EmployeeViewModel> GetWhseEmployees()
        {
            using (var matContext = new MatAppContext())
            {
                var whseEmployees = matContext.Employee
                .Where(emp => emp.TermDate == null && (emp.Dept == "310" || emp.Dept == "308"))
                .Select(emp => new EmployeeViewModel
                {
                    EmpFull = emp.EmpNum + ": " + emp.Fname + ' ' + emp.Lname

                });


                var whseList = whseEmployees.ToList();
                return whseList;
            }
        }

        public IEnumerable<ItemLocViewModel> GetLocation(int itemReqId)
        {
            using (var requisitionContext = new WarehouseRequisitionContext())
            {

                var requisitionItem = requisitionContext.RequisitionItem.Where(i => i.Id == itemReqId).FirstOrDefault();

                using (var matContext = new MatAppContext())
                {
                    var itemloc = matContext.Itemloc.Where(i => i.Item == requisitionItem.Item && i.QtyOnHand > 0).Select(i => new ItemLocViewModel
                    {
                        Item = i.Item,
                        Rank = i.Rank,
                        Location = i.Loc,
                        QtyOnHand = i.QtyOnHand
                    });


                    var locList = itemloc.ToList();
                    return locList;
                }
            }
        }

        public IEnumerable<ItemLocViewModel> GetLocationNoQuantity(int itemReqId)
        {
            using (var requisitionContext = new WarehouseRequisitionContext())
            {

                var requisitionItem = requisitionContext.RequisitionItem.Where(i => i.Id == itemReqId).FirstOrDefault();

                using (var matContext = new MatAppContext())
                {
                    var itemloc = matContext.Itemloc.Where(i => i.Item == requisitionItem.Item).Select(i => new ItemLocViewModel
                    {
                        Item = i.Item,
                        Rank = i.Rank,
                        Location = i.Loc,
                        QtyOnHand = i.QtyOnHand
                    });



                    var locList = itemloc.ToList();

                    return locList;
                }
            }
        }

        public List<string> GetReasonCodes()
        {
            using (var context = new WarehouseRequisitionContext())
            {
                var reasonCodes = context.ReasonCode;
                var rcFullList = new List<string>();

                foreach (ReasonCode rc in reasonCodes)
                {
                    var rcFull = rc.Code + " - " + rc.Description;
                    rcFullList.Add(rcFull);
                }

                return rcFullList;
            }
        }
        /*
        public IEnumerable<ReasonCode> GetReasonCodes()
        {
            using (var context = new WarehouseRequisitionContext())
            {
                var reasonCodes = context.ReasonCode;
                
                var firstRC = new ReasonCode
                {
                    Code = "-- Reason Code --"
                };

                var rcList = reasonCodes.ToList();
                rcList.Insert(0, firstRC);
                return rcList;
            }
        }
        */
        internal int InsertDcjm(InsertItem insertItem)
        {
            using (var matContext = new MatAppContext())
            {
                try
                {
                    var errors = new List<string>();

                    if (insertItem.Quantity <= 0)
                    {
                        errors.Add("Quantity must be a positive number");
                    }
                    if (insertItem.Job.Length > 0)
                    {
                        var dcjmId = matContext.Database.ExecuteSqlCommand(@"INSERT INTO dcjm (trans_type, stat, trans_date, job, suffix, oper_num, item, whse, loc, qty, u_m, lot, override, emp_num)
                    VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}); 
                    SELECT CAST(scope_identity() AS int)
                    ", insertItem.Quantity > 0 ? "1" : "2", "U", DateTime.Now, insertItem.Job.PadLeft(10), 0, (insertItem.OperNum != null ? Convert.ToInt32(insertItem.OperNum) : (int?)null), insertItem.Item, "MAIN", insertItem.Loc, insertItem.Quantity, insertItem.Um, (!String.IsNullOrWhiteSpace(insertItem.Lot)) ? insertItem.Lot.ToString() : null, 1, insertItem.ProcessedBy.PadLeft(7));

                        var dcjm = matContext.Dcjm.Where(i => i.TransNum == dcjmId).FirstOrDefault();

                        if (dcjm.ErrorMessage != null)
                        {
                            errors.Add(dcjm.ErrorMessage);
                        }

                    }
                    else
                    {
                        //The trans num field is not an identity field.  Just using a random number generator for the ID since its only an error processing table.
                        Random random = new Random();
                        int rand_trans_num = random.Next(1, 10000);
                        matContext.Database.ExecuteSqlCommand(@"INSERT INTO dcitem (trans_num, trans_type, stat, trans_date, item, whse, loc, count_qty, u_m, lot, reason_code, emp_num) 
                        VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11})", rand_trans_num, insertItem.Quantity > 0 ? "2" : "3", "U", DateTime.Now, insertItem.Item, "MAIN", insertItem.Loc, insertItem.Quantity, insertItem.Um, (!String.IsNullOrWhiteSpace(insertItem.Lot)) ? insertItem.Lot.ToString() : null, insertItem.Reasoncode.Substring(0, insertItem.Reasoncode.IndexOf("-")).Trim(), insertItem.ProcessedBy.PadLeft(7));

                        var dcitem = matContext.Dcitem.Where(i => i.TransNum == rand_trans_num).FirstOrDefault();
                        if (dcitem?.ErrorMessage != null)
                        {
                            errors.Add(dcitem.ErrorMessage);
                        }

                    }
                    //if any errors have been added to the errors list, return bad request.
                    if (errors.Count > 0)
                    {
                        string errorStr = String.Join("\n", errors);
                        throw new Exception(errorStr);
                    }

                    return 1;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Requisition IssuePart(PartRequest partRequest)
        {
            using (var matContext = new MatAppContext())
            {
                using (var requisitionContext = new WarehouseRequisitionContext())
                {
                    var errors = new List<string>();
                    var requisitionItem = requisitionContext.RequisitionItem.Where(r => r.Id == partRequest.ItemReqId).FirstOrDefault();

                    var requisitionId = requisitionContext.RequisitionItem.Where(r => r.Id == partRequest.ItemReqId).FirstOrDefault().RequisitionId;

                    var requisitionItems = requisitionContext.RequisitionItem.Where(r => r.RequisitionId == requisitionId).ToList();

                    var requisition = requisitionContext.Requisition.Where(r => r.RequisitionItem.Any(ri => ri.Id == partRequest.ItemReqId)).FirstOrDefault();


                    var item = matContext.Item.Where(i => i.Item1 == requisitionItem.Item).FirstOrDefault();

                    if (requisition != null)
                    {
                        if (requisitionItem != null)
                        {
                            if (item != null)
                            {
                                var insertItem = new InsertItem
                                {
                                    Quantity = partRequest.Quantity,
                                    Job = requisition.Job,
                                    OperNum = requisitionItem.Operation,
                                    Item = requisitionItem.Item,
                                    Loc = partRequest.Location,
                                    Um = item.Um,
                                    Lot = partRequest.Lot,
                                    Reasoncode = requisitionItem.ReasonCode,
                                    ProcessedBy = partRequest.ProcessedBy.Split(':')[0]
                                };

                                if (partRequest.Quantity <= 0)
                                {
                                    errors.Add("Quantity must be a positive number");
                                }

                                var result = InsertDcjm(insertItem);

                                if (result == 1)
                                {
                                    RequisitionItemActions requisitionItemActions = new RequisitionItemActions
                                    {
                                        Action = "issue",
                                        RequisitionitemId = requisitionItem.Id,
                                        Quantity = partRequest.Quantity,
                                        ActionBy = partRequest.ProcessedBy,
                                        ActionDate = DateTime.Now
                                    };
                                    requisitionItem.QuantityFilled += partRequest.Quantity;

                                    if (requisitionItem.QuantityFilled == requisitionItem.Quantity)
                                    {
                                        requisitionItem.Filled = true;
                                    }

                                    if ((requisitionItems.Count() == 1) && (requisitionItem.Filled == true))
                                    {

                                        requisition.Filled = true;

                                    }
                                    //if wholeReq.reqItem >= 1;
                                    //if for reqitem in wholeReq, if reqItem.filled ==true, req.filled = true. else, break

                                    ////MAYBE CONVERT TO CASE STATEMENT LATER
                                    if (requisitionItems.Count() > 1)
                                    {
                                        for (int i = 0; i < requisitionItems.Count(); i++)
                                        {

                                            if (requisitionItems[i].Filled == false)
                                            {
                                                requisition.Filled = false;
                                                break;
                                            }
                                            else
                                            {
                                                requisition.Filled = true;
                                            }
                                        }
                                    }
                                    if (errors.Count > 0)
                                    {
                                        string errorStr = String.Join("\n", errors);
                                        throw new Exception(errorStr);
                                    }
                                    try
                                    {
                                        requisitionContext.Update(requisition);
                                        requisitionContext.Update(requisitionItem);
                                        requisitionContext.Update(requisitionItemActions);
                                        requisitionContext.SaveChanges();
                                        return requisitionContext.Requisition.Where(i => i.Id == requisitionItem.RequisitionId).FirstOrDefault();
                                    }
                                    catch (Exception ex)
                                    {
                                        throw ex;
                                    }
                                }
                            }
                        }
                    }

                    throw new Exception("No requisition found with id " + Convert.ToString(partRequest.ItemReqId));
                }
            }
        }

        public bool DeleteReq(string itemReqId)
        {
            using (var requisitionContext = new WarehouseRequisitionContext())
            {
                try
                {
                    var pItemReqId = Convert.ToInt32(itemReqId);
                    SqlParameter param = new SqlParameter("pItemReqId", pItemReqId);
                    var req = requisitionContext.Database.ExecuteSqlCommand("Matric_spDeleteWhseReqByReqId @pItemReqId", param);
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string GetItemDescription(string itemNum)
        {
            using (var matContext = new MatAppContext())
            {
                if (!string.IsNullOrWhiteSpace(itemNum))
                {
                    var item = matContext.Item.Where(i => i.Item1 == itemNum).FirstOrDefault();
                    if (item != null)
                    {
                        var itemDesc = item.Description.ToString();
                        return JsonConvert.SerializeObject(itemDesc);
                    }

                    return null;
                }
                else
                {
                    return null;
                }



            }
        }

        public List<OperationSelectViewModel> GetOperNumByJob(string jobNum)
        {
            using (var matContext = new MatAppContext())
            {
                if (!String.IsNullOrWhiteSpace(jobNum))
                {
                    
                    var operSelect = from jr in matContext.Jobroute
                                  join w in matContext.Wc on new { jr.Wc1 } equals new { w.Wc1 }
                                  where jr.Job.Trim() == jobNum
                                  select new OperationSelectViewModel {
                                     OperString = w.Wc1 + " " + w.Description + " - " + jr.OperNum
                                  };
                   
                    return operSelect.ToList();

                }
                else
                {
                    return null;
                }
                

            }
        }

        public IEnumerable<ItemLotLocViewModel> GetItemLot(int itemReqId)
        {
            using (var requisitionContext = new WarehouseRequisitionContext())
            {

                var requisitionItem = requisitionContext.RequisitionItem.Where(i => i.Id == itemReqId).FirstOrDefault();

                using (var matContext = new MatAppContext())
                {
                    var itemlotloc = matContext.LotLoc.Where(i => i.Item == requisitionItem.Item && i.QtyOnHand > 0).Select(i => new ItemLotLocViewModel
                    {
                        Item = i.Item,
                        Lot = i.Lot,
                        Location = i.Loc,
                        QtyOnHand = i.QtyOnHand
                    });


                    if (itemlotloc.Any(i => i.Item == requisitionItem.Item))
                    {
                        var lotLocList = itemlotloc.ToList();
                        return lotLocList;
                    }
                    else
                    {


                        var itemloc = matContext.Itemloc.Where(i => i.Item == requisitionItem.Item && i.QtyOnHand > 0).Select(i => new ItemLotLocViewModel
                        {
                            Item = i.Item,
                            Lot = null,
                            Location = i.Loc,
                            QtyOnHand = i.QtyOnHand
                        });

                        var locList = itemloc.ToList();
                        return locList;

                    }

                }
            }
        }

        public bool UpdateRequisition(Requisition updatedReq)
        {
            using (var requisitionContext = new WarehouseRequisitionContext())
            {
                SqlConnection conn = null;
                conn = new SqlConnection("Server=SLDB1;DataBase=WarehouseRequisition;User Id=sa;Password=$yt3LinE;");


                SqlCommand cmd = new SqlCommand("Matric_spUpdateRequisition", conn);
                List<SqlParameter> param = new List<SqlParameter>();
                try
                {

                    foreach (var item in updatedReq.RequisitionItem)
                    {

                        conn.Open();
                        cmd.Parameters.Clear();
                        param.Add(new SqlParameter("@pId", SqlDbType.Int) { Value = updatedReq.Id });
                        param.Add(new SqlParameter("@pDepartment", SqlDbType.VarChar) { Value = updatedReq.Department });
                        param.Add(new SqlParameter("@pReqFilled", SqlDbType.Bit) { Value = updatedReq.Filled });
                        param.Add(new SqlParameter("@pJob", SqlDbType.VarChar) { Value = updatedReq.Job });
                        param.Add(new SqlParameter("@pItemFilled", SqlDbType.Bit) { Value = item.Filled });
                        param.Add(new SqlParameter("@pItem", SqlDbType.VarChar) { Value = item.Item });
                        param.Add(new SqlParameter("@pOperation", SqlDbType.VarChar) { Value = item.Operation });
                        param.Add(new SqlParameter("@pQuantityRequested", SqlDbType.Decimal) { Value = item.Quantity });
                        param.Add(new SqlParameter("@pQuantityFilled", SqlDbType.Decimal) { Value = item.QuantityFilled });
                        param.Add(new SqlParameter("@pReasonCode", SqlDbType.VarChar) { Value = item.ReasonCode });
                        param.Add(new SqlParameter("@pItemId", SqlDbType.Int) { Value = item.Id });


                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        //cmd.CommandText = "Matric_spUpdateRequisition";
                        cmd.CommandText = "Matric_spUpdateRequisition";
                        cmd.Parameters.AddRange(param.ToArray());
                        cmd.ExecuteNonQuery();
                        param.Clear();
                        conn.Close();

                    };

                    conn.Dispose();
                    //var update = requisitionContext.Database.ExecuteSqlCommand("Matric_spUpdateRequisition", param);
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public bool RemoveReqItem(int reqId, int reqItemId)
        {

            using (var requisitionContext = new WarehouseRequisitionContext())
            {
                SqlConnection conn = null;
                conn = new SqlConnection("Server=SLDB1;DataBase=WarehouseRequisition;;User Id=sa;Password=$yt3LinE;");


                SqlCommand cmd = new SqlCommand("Matric_spUpdateRequisition", conn);
                List<SqlParameter> param = new List<SqlParameter>();
                try
                {

                    conn.Open();
                    cmd.Parameters.Clear();

                    param.Add(new SqlParameter("@pReqId", SqlDbType.Int) { Value = reqId });
                    param.Add(new SqlParameter("@pReqItemId", SqlDbType.Int) { Value = reqItemId });
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.CommandText = "Matric_spDeleteReqItemByReqIdAndReqItemId";
                    cmd.Parameters.AddRange(param.ToArray());
                    cmd.ExecuteNonQuery();
                    param.Clear();
                    conn.Close();
                    conn.Dispose();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string GetUnitOfMeasure(string itemNum)
        {
            using (var matContext = new MatAppContext())
            {
                if (!string.IsNullOrWhiteSpace(itemNum))
                {
                    var item = matContext.Item.Where(i => i.Item1 == itemNum).FirstOrDefault();
                    if (item != null)
                    {
                        var itemDesc = item.Um.ToString();
                        return JsonConvert.SerializeObject(itemDesc);
                    }

                    return null;
                }
                else
                {
                    return null;
                }

            }
        }
       
    }
}