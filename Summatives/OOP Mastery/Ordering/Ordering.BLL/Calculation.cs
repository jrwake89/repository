using Ordering.Models;
using Ordering.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.BLL
{
    public class Calculation
    {
        public Order GetCosts(AddEditResponse response)
        {
            foreach (var item in response.product)
            {
                if (Convert.ToString(item.ProductType).ToLower() == response.order.Type)
                {
                    response.order.LaborCostPerSquareFoot = item.LaborCostPerSquareFoot;
                    response.order.CostPerSquareFoot = item.CostPerSquareFoot;
                }
            }

            return response.order;
        }

        public Order Calculate(Order order)
        {
            order.MaterialCost = (order.Area * order.CostPerSquareFoot);
            order.LaborCost = (order.Area * order.LaborCostPerSquareFoot);
            order.Tax = ((order.MaterialCost + order.LaborCost) * (order.TaxRate / 100));
            order.Total = (order.MaterialCost + order.LaborCost + order.Tax);

            return order;
        }

        public Order GetTaxes(AddEditResponse response)
        {
            Order order = response.order;

            foreach (var item in response.tax)
            {
                if (Convert.ToString(item.StateAbbreviation) == order.State)
                {
                    order.TaxRate = item.TaxRate;
                }
            }

            response.order = order;
            return response.order;

        }
    }
}

