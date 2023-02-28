namespace BookStore.Services
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.Write("[Console Logger]" + " " +  message);
        }
    }
}
