using GuildCar.Data.ADO;
using GuildCar.Data.Interfaces;
using GuildCar.Data.Mock_Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCar.Data
{
    public class Settings
    {
        private static string _connectionString;
        private static string _repositoryType;

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
                return _connectionString;
        }

        public static string GetRepositoryType()
        {
            if (string.IsNullOrEmpty(_repositoryType))
            {
                _repositoryType = ConfigurationManager.AppSettings["mode"].ToString();
            }
            return _repositoryType;
        }



        public static ISalesRepository GetSalesRepositoryType()
        {
            switch (_repositoryType)
            {
                case "prod":
                    return new SalesRepository();
                case "QA":
                    return new MockSalesRepository();
                default:
                    throw new NotSupportedException();
            }
        }

        public static ISpecialRepository GetSpecialRepositoryType()
        {
            switch (_repositoryType)
            {
                case "prod":
                    return new SpecialRepository();
                case "QA":
                    return new MockSpecialRepository();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
