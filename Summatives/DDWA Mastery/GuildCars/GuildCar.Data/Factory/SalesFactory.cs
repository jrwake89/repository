using GuildCar.Data.ADO;
using GuildCar.Data.Interfaces;
using GuildCar.Data.Mock_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCar.Data.Factory
{
    public class SalesFactory
    {
        public static ISalesRepository GetSalesRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "prod":
                    return new SalesRepository();
                case "QA":
                    return new MockSalesRepository();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
