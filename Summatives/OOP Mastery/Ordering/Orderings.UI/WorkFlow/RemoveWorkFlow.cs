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
    public class RemoveWorkFlow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            DeleteResponse response = new DeleteResponse();
            ConsoleIO consoleIO = new ConsoleIO();
            BlankCheck check = new BlankCheck();
            Order order = new Order();

            response.Success = false;
            bool second = false;
            string message = "";

            while(response.Success == false)
            {
                Console.Clear();

                Extras.DisplayStarline();

                message = "Enter Order Date (MMDDYYYY):";
                order.OrderDate = check.GetInput(message);

                message = "Enter Order Number:";
                order.OrderNumber = check.GetInputNum(message);

                second = false;
                
                response = manager.Remove(order, second);
                if(response.order != null)
                {
                    break;
                }
                else if (response.Success == false)
                {
                    ConsoleIO.FalseMessageDel(response);
                }
            }

            order = response.order;

            Console.Clear();
            if(order != null)
            {
                ConsoleIO.DisplayOrderInfo(order);
                string answer = consoleIO.YesOrNo();
                ConsoleIO.DetermineRemove(answer, order);        
            }
            else
            {
                RemoveWorkFlow removeWorkFlow = new RemoveWorkFlow();
                removeWorkFlow.Execute();
            }

        }
    }
}
