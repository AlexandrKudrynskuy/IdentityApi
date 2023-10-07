namespace Store_Identity_API.Models
{
    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }

        public Response(string status, string message)
        {
            Status = status;
            Message = message;
        }

        public override bool Equals(object? obj)
        {
            return obj is Response other &&
                   Status == other.Status &&
                   Message == other.Message;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Status, Message);
        }
    }
}
