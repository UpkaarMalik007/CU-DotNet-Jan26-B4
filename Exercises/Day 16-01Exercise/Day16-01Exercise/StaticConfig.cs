namespace Day16_01Exercise
{
    class ApplicationConfig
    {
        
        public static string ApplicationName { get; set; }
        public static string Environment { get; set; }
        public static int AccessCount { get; set; }
        public static bool IsInitialized { get; set; }

        
        static ApplicationConfig()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            AccessCount = 0;
            IsInitialized = false;

            Console.WriteLine("Static constructor executed");
        }

        
        public static void Initialize(string appName, string environment)
        {
            ApplicationName = appName;
            Environment = environment;
            IsInitialized = true;
            AccessCount++;
        }

        public static string GetConfigurationSummary()
        {
            AccessCount++;

            return $"Application Name     : {ApplicationName}\n" +
                   $"Environment          : {Environment}\n" +
                   $"Access Count         : {AccessCount}\n" +
                   $"Initialization Status: {IsInitialized}";
        }

        public static void ResetConfiguration()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            IsInitialized = false;
            AccessCount++;
        }
    }
    internal class StaticConfig
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ApplicationConfig.ApplicationName);

            ApplicationConfig.Initialize("StudentPortal", "Production");

            Console.WriteLine(" Configuration Summary:");
            Console.WriteLine(ApplicationConfig.GetConfigurationSummary());

            ApplicationConfig.ResetConfiguration();

            Console.WriteLine("Configuration Summary After Reset ");
            Console.WriteLine(ApplicationConfig.GetConfigurationSummary());
        }
    }
}
