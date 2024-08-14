namespace ChatterBox.Models
{
    public class User
    {
        public int FirebaseId { get; set; }

        public List<User> Friends { get; set; }

        public List<Message> Messages { get; set; }

        public List<Chat> Chats { get; set; }
    }
}
