using Ordering.BLL;
using Ordering.Models;
using Ordering.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderings.UI.WorkFlow
{
    public class LookUpWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            LookUpResponse response = new LookUpResponse();
            Calculation calculations = new Calculation();

            response.Success = false;

            while(response.Success == false)
            {
                Console.Clear();
                Console.WriteLine("Look up order");

                Extras.DisplayStarline();

                Console.WriteLine("Enter Order Date (MMDDYYYY):");
                string date = Console.ReadLine();

                response = manager.LookUp(date);
                if(response.Success == false)
                {
                    ConsoleIO.FalseMessageLookUp(response);
                }
            }
            
                Console.Clear();
                foreach(var order in response.order)
                {
                    Extras.DisplayStarline();
                    calculations.Calculate(order);
                    ConsoleIO.DisplayOrderInfo(order);
                    Extras.DisplayStarline();
                }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
