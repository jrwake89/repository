using GuildCars.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCar.Data.Interfaces
{
    public interface ISpecialRepository
    {
        IEnumerable<Special> GetSpecials();

        void InsertSpecial(Special special);
        void DeleteSpecials(int specialId);
    }
}
