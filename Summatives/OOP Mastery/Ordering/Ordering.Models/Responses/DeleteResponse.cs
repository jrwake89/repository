using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Models.Responses
{
    public class DeleteResponse : Response
    {
        public Order order { get; set; }
    }
}
