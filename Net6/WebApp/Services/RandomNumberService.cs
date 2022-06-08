namespace WebApp.Services
{
    public class RandomNumberService
    {
        private Random Random { get; }

        public RandomNumberService()
        {
            Random = new Random();
        }

        public int GetInt()
        {
            return Random.Next();
        }
    }
}
