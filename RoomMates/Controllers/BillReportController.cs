using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoomMates.DAL;
using RoomMates.Models.DBModel;
using Rotativa;
using Rotativa.Options;
using System;
using System.Linq;
using Rotativa.AspNetCore;
using System.Data;

namespace RoomMates.Controllers
{
    public class BillReportController : Controller
    {
        private readonly DataAccess _repo;

        public BillReportController(DataAccess repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        // GET: /BillReport/Index
        public IActionResult Index(int? month, int? userId)
        {

            // Initialize ViewModel
            var model = new BillReportViewModel
            {
              
                // Month dropdown 1-12
                Months = Enumerable.Range(1, 12)
                    .Select(i => new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i)
                    })
                    .ToList(),

                // Employee/User dropdown
                Users = _repo.GetUserID()
                    .Select(u => new SelectListItem
                    {
                        Value = u.UserID.ToString(),
                        Text = u.Name
                    })
                    .ToList(),

                SelectedMonth = month,
                SelectedUserID = userId
            }; 
            // Get filtered bills (Month and User only)
            model.Bills = _repo.GetUserBills(
                userId ?? 0, 5    ,  // 0 = all users
                month ?? 0         // 0 = all months
            ) ?? new List<ViewBill>();

            DataTable dt = _repo.GetUserBills_DT(userId ?? 0, 7,0);

            model.TotalBill = _repo.GetUserBilldata(
            userId ?? 0, 7,  // 0 = all users
            month ?? 0         // 0 = all months
        ) ?? new List<TotalBill>();



            model.UserBill = _repo.GetUserBillsDetails(
            userId ?? 0, 6,  // 0 = all users
            month ?? 0         // 0 = all months
        ) ?? new List<UserBill>();
            return View(model);
        }

        //public IActionResult ExportToPdf(int? month, int? userId)
        //{
            //// Load same model as your Index
            //var model = new BillReportViewModel
            //{
            //    Months = Enumerable.Range(1, 12)
            //        .Select(i => new SelectListItem
            //        {
            //            Value = i.ToString(),
            //            Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i)
            //        }).ToList(),

            //    Users = _repo.GetUserID()
            //        .Select(u => new SelectListItem
            //        {
            //            Value = u.UserID.ToString(),
            //            Text = u.Name
            //        }).ToList(),

            //    SelectedMonth = month ?? 0,
            //    SelectedUserID = userId ?? 0,

            //    Bills = _repo.GetUserBills(userId ?? 0,5, month ?? 0) ?? new List<ViewBill>()
            //};

            //// Use the same view for PDF
            //return new Rotativa.AspNetCore.ViewAsPdf("Index", model)
            //{
            //    FileName = "BillReport.pdf",
            //    PageSize = Rotativa.AspNetCore.Options.Size.A4,
            //    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            //};
        //}
    }
}
