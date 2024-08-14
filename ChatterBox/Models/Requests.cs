namespace ChatterBox.Models
{
    public class Requests
    {
        public int RequestId { get; set; }
        public RequestType RequestType { get; set; }
        public User Sender { get; set; }
        public User Reciever { get; set; }
    }

    public enum RequestType
    {
        Friend,
        Chat
    }
}
