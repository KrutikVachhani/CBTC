namespace EventPlanner360.DAL
{
    public class DAL_Helper
    {
        public static string connectionstr = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("myConnectionString");
    }
}
