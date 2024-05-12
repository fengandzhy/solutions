namespace WebApplication1.src.Utils.Impls
{
    public class SystemTime : ISystemTime
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
