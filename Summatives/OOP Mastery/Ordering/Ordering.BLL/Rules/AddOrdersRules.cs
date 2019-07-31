using Ordering.Models;
using Ordering.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.BLL.Rules
{
    public class AddOrdersRules
    {
        public AddEditResponse AddOrder(Order order)
        {
            OrderManager manager = OrderManagerFactory.Create();
            AddEditResponse response = new AddEditResponse();
            response.product = manager.GetProd(response);
            response.tax = manager.GetTax(response);
            response.order = order;

            string date = "";
            if(order.OrderDate.Length == 8 )
            {
                
                string month = order.OrderDate.Remove(2);
                string year = order.OrderDate.Substring(4);
                string firstDay = order.OrderDate.Substring(2);
                string day = firstDay.Remove(2);

                date = month + "/" + day + "/" + year;  
            }
            else
            {
                response.Success = false;
                response.Message = $"Make sure that the date is correct";
                return response;
            }

            DateTime orderDate = DateTime.Parse(date);
            DateTime dateToday = DateTime.Today;

            if (orderDate <= dateToday)
            {
                response.Success = false;
                response.Message = $"That date is not in the future.";
                return response;
            }

            bool alphabet = response.order.CustomerName.All(c => Char.IsLetterOrDigit(c));

            if (alphabet == false  && response.order.CustomerName.All(c => c != '.' && c != ','))
            {
                    response.Success = false;
                    response.Message = $"Make sure you've only entered a-z, 0-9, or commas and periods for Customer Name";
                    return response;
            }

            bool productMatch = false;
            foreach (var product in response.product)
            {
                if(product.ProductType.ToLower() == order.Type)
                {
                    productMatch = true;
                    break;
                }

                productMatch = false;
            }

            if(productMatch == false)
            {
                response.Success = false;
                response.Message = $"Enter a product that we carry.";
                return response;
            }

            bool stateMatch = false;
            foreach (var state in response.tax)
            {
                if (state.StateAbbreviation == order.State)
                {
                    stateMatch = true;
                    break;
                }

                stateMatch = false;
            }

            if (stateMatch == false)
            {
                response.Success = false;
                response.Message = $"Enter a state that we service.";
                return response;
            }

            if (response.order.Area < 100)
            {
                    response.Success = false;
                    response.Message = $"Must be more that 100 square ft.";
                    return response;
            }

                response.Success = true;
                return response;
         }
    }
}
