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
    public class UsersFactory
    {
        public static IUsersRepository GetUsersRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "prod":
                    return new UsersRepository();
                case "QA":
                    return new MockUsersRepository();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}

