using System.ComponentModel.DataAnnotations;

namespace RoomMates.Models.DBModel
{
    public class ShopBill
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Bill Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Room Rent is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Enter a valid amount")]
        [Display(Name = "Room Rent")]
        public decimal RoomRent { get; set; }

        [Required(ErrorMessage = "EB Bill is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Enter a valid amount")]
        [Display(Name = "EB Bill")]
        public decimal EBBill { get; set; }

        [Required(ErrorMessage = "Water Bill is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Enter a valid amount")]
        [Display(Name = "Water Bill")]
        public decimal WaterBill { get; set; }

        [Required(ErrorMessage = "Akka Bill is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Enter a valid amount")]
        [Display(Name = "Akka Bill")]
        public decimal AkkaBill { get; set; }

        [Required(ErrorMessage = "WiFi Bill is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Enter a valid amount")]
        [Display(Name = "WiFi Net")]
        public decimal WifiNet { get; set; }
    }
}
