using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Data.Factories
{
    public static class DVDRepositoryFactory
    {
        public static IDVDRepository GetRepository()
        {
            return Settings.GetRepositoryType();
        }
    }
}
