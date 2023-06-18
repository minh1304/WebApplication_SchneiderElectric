namespace WebApplication_SchneiderElectric.Utility
{
    public class ConnectionString
    {
        private static string cName = "Data Source = localhost,1433;Initial Catalog =SE; User ID=sa; Password=Password123; TrustServerCertificate=True";
        public static string CName
        {
            get => cName;
        }
    }
}
