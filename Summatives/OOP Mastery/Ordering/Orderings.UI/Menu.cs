using Orderings.UI;
using Orderings.UI.WorkFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.UI
{
    public class Menu
    {
            public static void Start()
            {
                while (true)
                {
                    Console.Clear();
                    Extras.DisplayStarline();
                    Console.WriteLine("* Flooring Program");
                    Console.WriteLine("*");
                    Console.WriteLine("*1. Display Order");
                    Console.WriteLine("*2. Add an Order");
                    Console.WriteLine("*3. Edit an Order");
                    Console.WriteLine("*4. Remove an Order");
                    Console.WriteLine("*5. Quit");
                    Console.WriteLine("*");
                    Extras.DisplayStarline();

                    Console.WriteLine("Enter Selection: ");
                    string userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            LookUpWorkflow displayOrder = new LookUpWorkflow();
                            displayOrder.Execute();
                            break;
                        case "2":
                            AddWorkFlow addWorkFlow = new AddWorkFlow();
                            addWorkFlow.Execute();
                            break;
                        case "3":
                            EditWorkFlow editWorkFlow = new EditWorkFlow();
                            editWorkFlow.Execute();
                            break;
                        case "4":
                            RemoveWorkFlow removeWorkFlow = new RemoveWorkFlow();
                            removeWorkFlow.Execute();
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("That is not an option...Try again");
                        Console.ReadKey();
                            continue;

                    }

                }
            }
        }
    }

