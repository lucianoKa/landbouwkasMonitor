using System.Configuration;
using System.IO;
using System.Windows.Forms;

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
                string databasefile = Path.Combine(Application.StartupPath, "Data", ConfigurationManager.AppSettings["datafile"]);
                return $"Data Source={dataSource};AttachDbFilename={databasefile};Integrated Security=True"; 
            } 
        }
    }
}
