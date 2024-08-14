namespace ChatterBox.Models
{
    public class User
    {
        public int firebaseId { get; set; }

        public List<User> Friends { get; set; }
    }
}
