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
    public static class VehicleFactory
    {
        public static IVehicleRepository GetVehicleRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "prod":
                    return new VehicleRepository();
                case "QA":
                    return new MockVehicleRepository();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value");
            }
        }
    }
}
