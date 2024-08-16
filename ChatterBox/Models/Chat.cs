namespace ChatterBox.Models
{
    public class Chat
    {
        public int ChatId { get; set; }
        public string ChatName { get; set; }

        public List<User> Users { get; set; }
        public List<Message> Messages { get; set; }
        public DateTime CreationTimeStamp { get; set; }
    }
}
