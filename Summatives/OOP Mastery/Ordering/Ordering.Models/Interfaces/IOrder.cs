
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Models.Interfaces
{
    public interface IOrder
    {
        List<Order> GetOrder(string orderDate);
        List<Taxes> GetTaxes();
        List<Products> GetProducts();
        void SaveOrder(List<Order> orders);
    }
}
