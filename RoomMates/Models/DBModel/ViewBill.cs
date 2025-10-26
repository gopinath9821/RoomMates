using System.ComponentModel;

namespace RoomMates.Models.DBModel
{
    public class ViewBill
    {
        [DisplayName("Month")]
        public string Month { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Pay Rent Amount")]
        public decimal PayAmount { get; set; }

        [DisplayName("User Purchase Amount")]
        public decimal UserPurchaseAmount { get; set; }

        [DisplayName("Pay Total Rent Amount")]
        public decimal PayTotalAmount { get; set; }

        [DisplayName("Advance Pending Amount")]
        public decimal AdvancePending { get; set; }

        [DisplayName("Total Amount Rent + Advance")]
        public decimal TotalAmountRentAdvance { get; set; }
    }
}
