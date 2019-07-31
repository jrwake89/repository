using Ordering.BLL;
using Ordering.BLL.Rules;
using Ordering.BLL.Verify;
using Ordering.Models;
using Ordering.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderings.UI.WorkFlow
{
    public class AddWorkFlow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            AddEditResponse response = new AddEditResponse();
            BlankCheck check = new BlankCheck();
            Order order = new Order();
            Calculation calculations = new Calculation();
            ConsoleIO consoleIO = new ConsoleIO();

            response.product = manager.GetProd(response);
            response.tax = manager.GetTax(response);

            Console.Clear();

            response.Success = false;
            bool second = false;

            while (response.Success == false)
            {
                Extras.DisplayStarline();
                string message = "Enter Order Date (MMDDYYYY):";
                order.OrderDate = check.GetInput(message);

                message = "Enter the Customer's Name:";
                order.CustomerName = check.GetInput(message);

                message = "Enter State (Ex: KY):";
                order.State = check.GetInput(message).ToUpper();

                ConsoleIO.DisplayProductInfo(response);
                message = "Enter Product Type:";
                order.Type = check.GetInput(message).ToLower();

                message = "Enter Area (square feet):";
                order.Area = check.GetInputNum(message);

                Console.Clear();
                
                response.order = order;
                order.OrderNumber = manager.GetNumber(order);
                order = calculations.GetTaxes(response);
                order = calculations.GetCosts(response);
                calculations.Calculate(order);

                response = manager.Add(order, second);
                if(response.Success == false)
                {
                    ConsoleIO.FalseMessageAE(response);
                }
            }

            response.order = order;
            Console.WriteLine();

                ConsoleIO.DisplayOrderInfo(order);
                string answer = consoleIO.YesOrNo();
            ConsoleIO.DetermineAdd(answer, response.order);   
        }
    }
}
