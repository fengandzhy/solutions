namespace WebApplication1.Exceptions
{
    public class CoffeeDepletedException : Exception
    {
        public CoffeeDepletedException(string message) : base(message) { }
    }
}
