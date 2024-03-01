using System.Configuration;

namespace LBM
{
    public class Settings
    {
        #region Declarations
        private const string dataSource = @"(LocalDB)\MSSQLLocalDB";
        #endregion

        public static string DbConnectionString 
        { 
            get 
            {
                string databasefile = ConfigurationManager.AppSettings["datafile"];
                return $"Data Source={dataSource};AttachDbFilename={databasefile};Integrated Security=True"; 
            } 
        }
    }
}
