using Ordering.BLL.Rules;
using Ordering.Models;
using Ordering.Models.Interfaces;
using Ordering.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.BLL
{
    public class OrderManager
    {
        private IOrder _orderRepository;

        public OrderManager(IOrder orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public LookUpResponse LookUp(string orderDate)
        {
            LookUpResponse response = new LookUpResponse();

            List<Order> orders = _orderRepository.GetOrder(orderDate);
            List<Order> ordersToDisplay = new List<Order>();

            foreach(var order in orders)
            {
                if(order.OrderDate == orderDate)
                {
                    ordersToDisplay.Add(order);
                }
            }

            response.order = ordersToDisplay;

            if (response.order.Count() == 0)
            {
                response.Success = false;
                response.Message = $"{orderDate} is not valid";
            }
            else
            { 
                    response.Success = true;
            }

            return response;
        }

        public AddEditResponse Add(Order order, bool second)
        {
            AddOrdersRules rules = new AddOrdersRules();
            AddEditResponse response = new AddEditResponse();
            response.order = order;
            response = rules.AddOrder(response.order);

            if(response.Success == false)
            {
                return response;               
            }

            if(second == true)
            {
                List<Order> orders = _orderRepository.GetOrder(response.order.OrderDate);
                response.order.OrderNumber = (orders.Count + 1);
                orders.Add(response.order);
                _orderRepository.SaveOrder(orders);
            }
                 
            return response;
        }


        public AddEditResponse Edit(Order order, bool second)
        {

            AddEditResponse response = new AddEditResponse();
            EditOrderRules rules = new EditOrderRules();
            List<Order> orders = _orderRepository.GetOrder(order.OrderDate);
            bool notEmpty = false;

            foreach (var ord in orders)
            {              
                if (order.OrderDate == ord.OrderDate)
                    {
                        if (order.OrderNumber == order.OrderNumber)
                        {
                            order = ord;
                            notEmpty = true;
                        }
                }
            }

            if (second == true)
            {
                    response = rules.EditOrder(order);

                    if(response.Success == false)
                    {
                        Console.WriteLine($"Error: {response.Message}");
                        
                        return response;
                    }

                    orders[(order.OrderNumber - 1)] = response.order;
                    _orderRepository.SaveOrder(orders);
            }
            if(notEmpty == false)
            {
                response.order = null;
                response.Message = "Enter a valid date & number";
            }
            else
            {
                response.order = order;
            }
            return response;
        }

        public DeleteResponse Remove(Order order, bool second)
        {
            DeleteResponse response = new DeleteResponse();
            List<Order> orders = _orderRepository.GetOrder(order.OrderDate);
            bool notEmpty = false;

            foreach (var ord in orders)
            {
                    if (order.OrderNumber == ord.OrderNumber)
                    {
                        order = ord;
                        notEmpty = true;
                    }
            }

            if(second == true)
            {
                int num = order.OrderNumber;
                orders.Remove(order);
                
                _orderRepository.SaveOrder(orders);
                response.Success = true;
            }

            if(notEmpty == false)
            {
                response.order = null;
                response.Message = "Enter a correct data & order number";
            }
            else
            {
                response.order = order;
            }

            return response;
        }

        public List<Products> GetProd(AddEditResponse response)
        {
            response.product = _orderRepository.GetProducts();

            return response.product;
        }

        public List<Taxes> GetTax(AddEditResponse response)
        {
            response.tax = _orderRepository.GetTaxes();
            return response.tax;
        }

        public int GetNumber(Order order)
        {
            int i = (_orderRepository.GetOrder(order.OrderDate).Count()) + 1;

            return i;
        }
    }
}
