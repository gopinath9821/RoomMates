using Microsoft.AspNetCore.Mvc.Rendering;

namespace RoomMates.Models.DBModel
{
    public class BillReportViewModel
    {
        // Dropdown lists
        public List<SelectListItem> Users { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Months { get; set; } = new List<SelectListItem>();

        // Selected filters
        public int? SelectedUserID { get; set; }
        public int? SelectedMonth { get; set; }

        // Bill data
        public IEnumerable<ViewBill> Bills { get; set; } = new List<ViewBill>();
        public IEnumerable<UserBill> UserBill { get; set; } = new List<UserBill>();
        public IEnumerable<TotalBill> TotalBill { get; set; } = new List<TotalBill>();
    }
}