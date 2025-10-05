namespace RoomMates.Models.DBModel
{
    public class UserPageViewModel
    {
        public User User { get; set; }            // For Add User form
        public List<User> Users { get; set; }     // For Users grid
    }
}
