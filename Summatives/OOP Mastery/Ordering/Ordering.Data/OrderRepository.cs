using Ordering.Models;
using Ordering.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Data
{
    public class OrderRepository : IOrder
    {
            
            string dirName = Directory.GetCurrentDirectory();
            
            string filePathOrder = "";
            List<Order> orders = new List<Order>();
            
            public List<Order> GetOrder(string orderDate)
            {
                string dirNameEdit = dirName.Remove(dirName.Length-14);
                string[] files = Directory.GetFiles(dirNameEdit + ".Data\\SampleData");

                foreach (string file in files)
                {
                    if (file.Contains(orderDate))
                    {
                        filePathOrder = file;
                    }
                }
            
                if (filePathOrder != "")
                {
                        using (StreamReader reader = new StreamReader(filePathOrder))
                        {
                            reader.ReadLine();
                            string line;
                        

                            while ((line = reader.ReadLine()) != null)
                            {
                                Order order = new Order();
                                string[] columns = line.Split(',');
                                int length = filePathOrder.Length;
                                string firstDate = filePathOrder.Substring((length - 12));
                                order.OrderDate = firstDate.Remove((firstDate.Length) - 4);
                                order.OrderNumber = Convert.ToInt32(columns[0]);
                                order.CustomerName = columns[1];
                                order.State = columns[2];
                                order.TaxRate = Convert.ToDecimal(columns[3]);
                                order.Type = columns[4];
                                order.Area = Convert.ToDecimal(columns[5]);
                                order.CostPerSquareFoot = Convert.ToDecimal(columns[6]);
                                order.LaborCostPerSquareFoot = Convert.ToDecimal(columns[7]);
                                order.MaterialCost = Convert.ToDecimal(columns[8]);
                                order.LaborCost = Convert.ToDecimal(columns[9]);
                                order.Tax = Convert.ToDecimal(columns[10]);
                                order.Total = Convert.ToDecimal(columns[11]);

                                if(orders.Count() == 0 )
                                {
                                    orders.Add(order);
                                }
                                else
                                {
                                    bool contains = false;
                                    foreach(var ord in orders)
                                    {
                                        if(order.OrderNumber == ord.OrderNumber)
                                        {
                                            contains = true;
                                        }
                                    }

                                    if(contains == false)
                                    {
                                        orders.Add(order);
                                    }
                                }
                                
                            }
                        }
                }
                
                return orders;
            }

        public List<Taxes> taxes = new List<Taxes>();
        string filePathTax = "";

        public List<Taxes> GetTaxes()
        {
            string dirNameEdit = dirName.Remove(dirName.Length - 14);
            string[] files = Directory.GetFiles(dirNameEdit + ".Data\\SampleData");

            foreach (string file in files)
            {
                if (file.Contains("Taxes"))
                {
                    filePathTax = file;
                }
            }
            string[] rows = File.ReadAllLines(filePathTax);

            using (StreamReader reader = new StreamReader(filePathTax))
            {
                reader.ReadLine();
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    Taxes tax = new Taxes();
                    string[] columns = line.Split(',');

                    tax.StateAbbreviation = columns[0];
                    tax.StateName = columns[1];
                    tax.TaxRate = Convert.ToDecimal(columns[2]);

                    if (taxes.Contains(tax) == false)
                    {
                        taxes.Add(tax);
                    }
                }
            }
            return taxes;
        }

        public List<Products> products = new List<Products>();
        string filePathProducts = "";
        public List<Products> GetProducts()
        {
            string dirNameEdit = dirName.Remove(dirName.Length - 14);
            string[] files = Directory.GetFiles(dirNameEdit + ".Data\\SampleData");
            foreach (string file in files)
            {
                if (file.Contains("Products"))
                {
                    filePathProducts = file;
                }
            }
            string[] rows = File.ReadAllLines(filePathProducts);

            using (StreamReader reader = new StreamReader(filePathProducts))
            {
                reader.ReadLine();
                string line;
                
                while ((line = reader.ReadLine()) != null)
                {
                    Products product = new Products();
                    string[] columns = line.Split(',');

                    product.ProductType = columns[0];
                    product.CostPerSquareFoot = Convert.ToDecimal(columns[1]);
                    product.LaborCostPerSquareFoot = Convert.ToDecimal(columns[2]);

                    if (products.Contains(product) == false)
                    {
                        products.Add(product);
                    }
                }
                
            }
            return products;
        }

        public void SaveOrder(List<Order> order)
        {
            orders = order;
                     
            if(orders.Count() == 0)
            {
                File.Delete(filePathOrder);
            }
            else
            {
                string dirNameEdit = dirName.Remove(dirName.Length - 14);
                filePathOrder = (dirNameEdit + ".Data\\SampleData\\Orders_" + orders[0].OrderDate + ".txt");

                using (StreamWriter writer = new StreamWriter(filePathOrder))
                {
                    writer.WriteLine("OrderNumber, CustomerName, State, TaxRate, ProductType, Area, CostPerSquareFoot, LaborCostPerSquareFoot, MaterialCost, LaborCost, Tax, Total");

                    foreach (var ord in orders)
                    {
                        writer.WriteLine("{0},{1},{2},{3},{4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}", ord.OrderNumber, ord.CustomerName, ord.State, ord.TaxRate, ord.Type, ord.Area, ord.CostPerSquareFoot, ord.LaborCostPerSquareFoot, ord.MaterialCost, ord.LaborCost, ord.Tax, ord.Total);
                    }
                }
            }
            
        }
    }
}

