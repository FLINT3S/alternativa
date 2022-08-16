namespace Database
{
    public static class DatabaseConfig
    {
        private static string Host => "127.0.0.1";

        private static string Port => "5432";

        private static string User => "postgres";

        private static string Password => "ebalay228";

        private static string Database => "alt";

        public static string ConnectionString => $"Host={Host};Port={Port};User Id={User};Password={Password};Database={Database}";
    }
}
