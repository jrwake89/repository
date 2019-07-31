using Ordering.BLL;
using Ordering.Models;
using Ordering.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderings.UI
{
    public class ConsoleIO
    {
        public static void DisplayOrderInfo(Order order)
        {
            Console.WriteLine($"{order.OrderNumber} | {order.OrderDate}");
            Console.WriteLine($"{order.CustomerName}");
            Console.WriteLine($"{order.State}");
            Console.WriteLine($"Product: {order.Type}");
            Console.WriteLine($"Materials: {order.MaterialCost:c}");
            Console.WriteLine($"Labor Cost: {order.LaborCost:c}");
            Console.WriteLine($"Tax: {order.Tax:c}");
            Console.WriteLine($"Total: {order.Total:c}");
        }

        public static void DisplayProductInfo(AddEditResponse response)
        {
            int j = 0;
            foreach (var info in response.product)
            {
                Console.WriteLine($"Type: {response.product[j].ProductType}, Cost Per Squarefoot: {response.product[j].CostPerSquareFoot}, Labor Cost Per Squarefoot: {response.product[j].LaborCostPerSquareFoot}");
                j++;
            }
        }

        public static void FalseMessageAE(AddEditResponse response)
        {
                Console.WriteLine($"Error:{response.Message}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
        }

        public static void FalseMessageDel(DeleteResponse response)
        {
            Console.WriteLine($"Error:{response.Message}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public static void FalseMessageLookUp(LookUpResponse response)
        {
            Console.WriteLine($"Error:{response.Message}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public string YesOrNo()
        {
            bool keepGoing = true;
            string answer = "";

            while (keepGoing == true)
            {
                Console.WriteLine("Would you like to place this order (Y/N)?");
                answer = Console.ReadLine().ToUpper();

                if (answer == "Y" || answer == "N")
                {
                    break;
                }
            }

            return answer;
        }

        public static void DetermineRemove(string answer, Order order)
        {
            OrderManager manager = OrderManagerFactory.Create();

            switch (answer)
            {
                case "Y":
                    bool second = true;
                    manager.Remove(order, second);
                    break;
                case "N":
                    break;
                default:
                    Console.WriteLine("That was not yes or no...please try again");
                    break;
            }
        }

        public static void DetermineAdd(string answer, Order order)
        {
            OrderManager manager = OrderManagerFactory.Create();

            switch (answer)
            {
                case "Y":
                    bool second = true;
                    manager.Add(order, second);
                    break;
                case "N":
                    break;
                default:
                    Console.WriteLine("That was not yes or no...please try again");
                    break;
            }
        }

        public static void DetermineEdit(string answer, Order order)
        {
            OrderManager manager = OrderManagerFactory.Create();

            switch (answer)
            {
                case "Y":
                    bool second = true;
                    manager.Edit(order, second);
                    break;
                case "N":
                    break;
                default:
                    Console.WriteLine("That was not yes or no...please try again");
                    break;
            }
        }

    }
           
}
