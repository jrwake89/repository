using Ordering.Models;
using Ordering.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Data
{
        public class TestRepository : IOrder
        {
           
            private static Order _order = new Order()
            {
                OrderNumber = 1,
                OrderDate = "06012019",
                CustomerName = "Acme, Inc.",
                Area = 250,
                State = "KY",
                TaxRate = 6,
                Type = "Tile",
                LaborCostPerSquareFoot = 4.15M,
                CostPerSquareFoot = 3.50M
            };

            private static List<Order> _orders = new List<Order>()
            {
                _order
            };

            private static Taxes _tax = new Taxes()
            {
                StateAbbreviation = "KY",
                StateName = "Kentucky",
                TaxRate = 6
            };

            private static List<Taxes> _taxes = new List<Taxes>()
            {
                _tax
            };

            private static Products _product = new Products()
            {
                CostPerSquareFoot = 3.50M,
                LaborCostPerSquareFoot = 4.15M,
                ProductType = "tile"
            };

            private static List<Products> _products = new List<Products>()
            {
                _product
            };

            public List<Taxes> GetTaxes()
            {
                return _taxes;
            }
            
            public List<Products> GetProducts()
            {

                return _products;
            }

            public List<Order> GetOrder(string orderDate)
            {
                List<Order> orders = new List<Order>();
                
                foreach(var order in _orders)
                {
                    if(order.OrderDate == orderDate)
                    {
                        orders.Add(order);
                    }
                }           
                
                return orders;
            }
            
            public void SaveOrder(List<Order> order)
            {
                _orders = order;
            }
        }
   }

