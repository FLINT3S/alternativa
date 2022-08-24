namespace Database
{
    public class ContextSingleton
    {
        private static AlternativaContext _instance;

        public static AlternativaContext Instance
        {
            get
            {
                if (_instance == null) return Instance = new AlternativaContext();

                return _instance;
            }

            private set => _instance = value;
        }
    }
}