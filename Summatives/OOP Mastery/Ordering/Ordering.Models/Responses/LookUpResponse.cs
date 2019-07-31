using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Models.Responses
{
    public class LookUpResponse : Response
    {
        public List<Order> order { get; set; }
    }
}
