using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DVDLibrary.Data
{
    public class Settings
    {

        private static string _connectionString;

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
                
            return _connectionString;
        }

        public static IDVDRepository GetRepositoryType()
        {
                switch (ConfigurationManager.AppSettings["mode"].ToLower())
                {
                    case "prod":
                        return new DVDRepository();
                    case "test":
                        return new DVDRepositoryMock();
                    default:
                        throw new NotSupportedException();
                }
        }
    }
}
