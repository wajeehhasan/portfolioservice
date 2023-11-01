namespace portfolioapi
{
    public static class Helper
    {
        static List<String> keys = new List<String>() { "IpstackAccessKey", "IpStackUrl", "JayrideChallengeApi" };
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

            foreach (var item in keys)
            {
                
                var keyValue =configuration.GetSection(item).Value;
                Console.WriteLine("Key: "+item+", Value: "+ keyValue);

                Environment.SetEnvironmentVariable(item, keyValue);
            
            }


        }
    }
}
