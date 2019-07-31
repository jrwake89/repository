using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Ordering.Data;


namespace Ordering.BLL
{
    public class OrderManagerFactory
    {
        public static OrderManager Create()
        {

            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new OrderManager(new TestRepository());
                case "Production":
                    return new OrderManager(new OrderRepository());
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
