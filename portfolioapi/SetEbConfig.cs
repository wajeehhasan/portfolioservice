namespace portfolioapi
{
    public static class Helper
    {
        public static void SetEbConfig()
        {
            Console.WriteLine("SETEBCONFIG");
            var tempConfigBuilder = new ConfigurationBuilder();

            tempConfigBuilder.AddJsonFile(
                @"appsettings.json",
                optional: true,
                reloadOnChange: true
            );

            var configuration = tempConfigBuilder.Build();

            var ebEnv =
                configuration.GetSection("IpstackAccessKey");

            Console.WriteLine("============================================================="+ ebEnv.Value + "================================================================");
        }
    }
}
