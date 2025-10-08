using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RoomMates.Models.DBModel
{
    public class UserShop
    {
        [Key]
        [DisplayName("S.No")]

        public int ID { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string? Name { get; set; } = "";

        [Required(ErrorMessage = "Item Name is required")]
        [StringLength(500)]
        public string ProductName { get; set; } = "";

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Enter valid price")]
        public decimal Price { get; set; }
    }
}
