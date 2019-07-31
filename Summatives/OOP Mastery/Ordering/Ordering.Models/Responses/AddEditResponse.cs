using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Models.Responses
{
    public class AddEditResponse : Response
    {
        public Order order { get; set; }
        public List<Taxes> tax { get; set; }
        public List<Products> product { get; set; }

    }
}
