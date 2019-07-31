using Ordering.BLL;
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
    public class EditWorkFlow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            AddEditResponse response = new AddEditResponse();
            Order order = new Order();
            Calculation calculations = new Calculation();
            ConsoleIO consoleIO = new ConsoleIO();
            BlankCheck check = new BlankCheck();

            response.Success = false;
            response.order = null;
            string message = "";
            bool success = false;
            bool second = false;

            while(response.order == null)
            {
                Console.Clear();

                Extras.DisplayStarline();

                message = "Enter Order Date (MMDDYYYY):";
                order.OrderDate = check.GetInput(message);

                message = "Enter Order Number:";
                order.Area = check.GetInputNum(message);

                response = manager.Edit(order, second);
                if(response.order != null)
                {
                    break;
                }
                else if(response.Success == false)
                {
                    ConsoleIO.FalseMessageAE(response);
                }
            }
          
                while(response.Success == false)
                {
                    response.product = manager.GetProd(response);
                    response.tax = manager.GetTax(response);
                    order = response.order;
                
                    message = "Enter the Customer's Name:";
                    order.CustomerName = check.GetInput(message);

                    message = "Enter State (Ex: KY):";
                    order.State = check.GetInput(message).ToUpper();

                    ConsoleIO.DisplayProductInfo(response);
                    message = "Enter Product Type:";
                    order.Type = check.GetInput(message).ToLower();

                    message = "Enter Area (square feet):";
                    order.Area = check.GetInputNum(message);

                    second = true;
                    response = manager.Edit(order, second);

                    if (response.Success == false)
                    {
                        ConsoleIO.FalseMessageAE(response);
                    }
                }
                           
                Console.Clear();

                response.order = order;
                response.order = calculations.GetCosts(response);
                response.order = calculations.GetTaxes(response);
                calculations.Calculate(response.order);

                Console.WriteLine();

                ConsoleIO.DisplayOrderInfo(response.order);
                string answer = consoleIO.YesOrNo();
            ConsoleIO.DetermineEdit(answer, response.order);

            if(response.Success == false)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                EditWorkFlow editWorkFlow = new EditWorkFlow();
                editWorkFlow.Execute();
            }
        }
    }
}
