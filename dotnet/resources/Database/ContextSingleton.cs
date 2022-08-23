namespace Database
{
    public class ContextSingleton : AlternativaContext
    {
        public static ContextSingleton Instance { get; } = new ContextSingleton();

        private ContextSingleton()
        {
        }
    }
}