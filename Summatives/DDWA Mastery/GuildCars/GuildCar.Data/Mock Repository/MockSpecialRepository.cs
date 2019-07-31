using GuildCar.Data.Interfaces;
using GuildCars.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCar.Data.Mock_Repository
{
    public class MockSpecialRepository : ISpecialRepository
    {

        private static List<Special> _specials = new List<Special>()
        {
            new Special {SpecialId = 1, SpecialTitle = "Memorial Day Sale", SpecialDesc = "Memorial Day sale is offering 0% interest on your car payments for the next few years" },
            new Special {SpecialId = 2, SpecialTitle = "Christmas Sale", SpecialDesc = "Our Christmas Sale will allow you 1000 extra dollars on your car if you trade in" },
            new Special {SpecialId = 3, SpecialTitle = "Labor Day Sale", SpecialDesc = "Our Labor Day Sale is on of our best offers all year. Come in to learn more about how you can get one of the best deals all year!" }

        };

        public void ResetSpecials()
        {
            _specials = new List<Special>()
            {
            new Special {SpecialId = 1, SpecialTitle = "Memorial Day Sale", SpecialDesc = "Memorial Day sale is offering 0% interest on your car payments for the next few years" },
            new Special {SpecialId = 2, SpecialTitle = "Christmas Sale", SpecialDesc = "Our Christmas Sale will allow you 1000 extra dollars on your car if you trade in" },
            new Special {SpecialId = 3, SpecialTitle = "Labor Day Sale", SpecialDesc = "Our Labor Day Sale is on of our best offers all year. Come in to learn more about how you can get one of the best deals all year!" }
            };
        }
        
        public void DeleteSpecials(int specialId)
        {
            _specials.RemoveAll(s => s.SpecialId == specialId);
        }

        public IEnumerable<Special> GetSpecials()
        {
            return _specials;
        }

        public void InsertSpecial(Special special)
        {
            special.SpecialId = _specials.Count() + 1;
            _specials.Add(special);
        }
    }
}
