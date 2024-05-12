namespace WebApplication1.Models
{
    public class CoffeeResponse
    {
        public string Message { get; set; }
        public string Prepared { get; set; }

        public CoffeeResponse(string message, string prepared)
        {
            Message = message;
            Prepared = prepared;
        }
    }
}
