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
    public static class SpecialFactory
    {
        public static ISpecialRepository GetSpecialRepository()
        {
            switch (Settings.GetRepositoryType())
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
