using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RoomMates.Models.DBModel
{
    public class ShopBill
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        [DisplayName("Bill Date")]

        [Display(Name = "Bill Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Room Rent is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Enter a valid amount")]
        [Display(Name = "Room Rent")]
        [DisplayName("Room Rent")]

        public decimal RoomRent { get; set; }

        [Required(ErrorMessage = "EB Bill is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Enter a valid amount")]
        [Display(Name = "EB Bill")]
        [DisplayName("EB Bill")]

        public decimal EBBill { get; set; }

        [Required(ErrorMessage = "Water Bill is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Enter a valid amount")]
        [Display(Name = "Water Bill")]
        [DisplayName("Water Bill")]

        public decimal WaterBill { get; set; }

        [Required(ErrorMessage = "Cooking Bill is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Enter a valid amount")]
        [Display(Name = "Cooking Bill")]
        [DisplayName("Cooking Bill")]
        public decimal AkkaBill { get; set; }

        [Required(ErrorMessage = "Gas Bill is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Enter a valid amount")]
        [Display(Name = "Gas Bill")]
        [DisplayName("Gas Bill")]
        public decimal GasBill { get; set; }

        [Required(ErrorMessage = "WiFi Bill is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Enter a valid amount")]
        [Display(Name = "WiFi NetWork")]
        [DisplayName("WiFi NetWork")]
        public decimal WifiNetwork { get; set; }


    
    }
}
