using Ordering.Models;
using Ordering.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.BLL.Rules
{
    public class EditOrderRules
    {
        public AddEditResponse EditOrder(Order order)
        {
            AddEditResponse response = new AddEditResponse();
            AddEditResponse responseOrg = new AddEditResponse();
            OrderManager manager = OrderManagerFactory.Create();
            response.product = manager.GetProd(response);
            response.tax = manager.GetTax(response);
            response.order = order;
            bool second = false;

            responseOrg = manager.Edit(order, second);


            bool alphabet = response.order.CustomerName.All(c => Char.IsLetterOrDigit(c) || response.order.CustomerName == "");

            if (response.order.CustomerName == "")
            {
                order.CustomerName = responseOrg.order.CustomerName;
            }
            else if (alphabet == false && response.order.CustomerName.All(c => c != '.' && c != ','))
            {
                response.Success = false;
                response.Message = $"Make sure you've only entered a-z, 0-9, or commas and periods for Customer Name";
                return response;
            }

            bool productMatch = false;

            if (response.order.Type == "")
            {
                order.Type = responseOrg.order.CustomerName;
                productMatch = true;
            }
            else
            {
                foreach (var product in response.product)
                {
                    if (product.ProductType.ToLower() == order.Type.ToLower())
                    {
                        productMatch = true;
                        break;
                    }
                    else if (product.ProductType == "")
                    {
                        productMatch = true;
                        break;
                    }

                    productMatch = false;
                }
            }
            
            if (productMatch == false)
            {
                response.Success = false;
                response.Message = $"Enter a product that we carry.";
                return response;
            }

            bool stateMatch = false;

            if (response.order.State == "")
            {
                order.State = responseOrg.order.State;
                stateMatch = true;
            }
            else
            {
                foreach (var state in response.tax)
                {
                    if (state.StateAbbreviation == order.State.ToUpper())
                    {
                        stateMatch = true;
                        break;
                    }
                    else if (order.State == "")
                    {
                        stateMatch = true;
                        break;
                    }

                    stateMatch = false;
                }
            }

            if (stateMatch == false)
            {
                response.Success = false;
                response.Message = $"Enter a state that we service.";
                return response;
            }

            if (response.order.Area == 0)
            {
                order.State = responseOrg.order.State;
            }
            else if (response.order.Area < 100)
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

