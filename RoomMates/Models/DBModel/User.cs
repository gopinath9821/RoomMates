using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomMates.Models.DBModel
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime? DOB { get; set; }

        public byte[]? Photo { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [StringLength(20)]
        public string MobileNo { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of Joining is required")]
        public DateTime? DOJ { get; set; }

        [Required(ErrorMessage = "Room Advance is required")]
        [Range(0, 999999, ErrorMessage = "Invalid amount")]
        public decimal RoomAdvance { get; set; }
    }
}
