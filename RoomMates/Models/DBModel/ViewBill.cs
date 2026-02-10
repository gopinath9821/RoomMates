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


    public class UserBill
    {
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Product")]
        public string ProductName { get; set; }

        [DisplayName("Amount")]
        public decimal Price { get; set; }
         
    }

    public class TotalBill
    {
        [DisplayName("Room Rent")]
        public decimal RoomRent { get; set; }

        [DisplayName("EB Bill")]
        public decimal EBBill { get; set; }

        [DisplayName("Water Bill")]
        public decimal WaterBill { get; set; }

        [DisplayName("Cooking Bill")]
        public decimal AkkaBill { get; set; }

        [DisplayName("Gas Bill")]
        public decimal GasBill { get; set; }

        [DisplayName("Wifi Bill")]
        public decimal WifiNetwork { get; set; }

        [DisplayName("Sathish Shop Bill")]

        public decimal SathishShopBill { get; set; }

        [DisplayName("User Purchase Total Amount")]
        public decimal TotalUserAmount { get; set; }

        [DisplayName("Total Amount")]
        public decimal TotalAmount { get; set; }


    }
}
