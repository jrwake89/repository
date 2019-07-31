using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using Ordering.BLL;
using Ordering.Models;
using Ordering.Models.Responses;
using Ordering.Data;

namespace Ordering.Tests
{
    [TestFixture]
    public class RepositoryTests
    {    
        [SetUp]
        public void Setup()
        {
            TestRepository repo = new TestRepository();

            List<Order> orders = new List<Order>();
            repo.SaveOrder(orders);
            Order order = new Order();
            order.OrderNumber = 1;
            order.OrderDate = "06012019";
            order.CustomerName = "Acme, Inc.";
            order.Area = 250;
            order.State = "KY";
            order.TaxRate = 6;
            order.Type = "Tile";
            order.LaborCostPerSquareFoot = 4.15M;
            order.CostPerSquareFoot = 3.50M;

            orders.Add(order);
            repo.SaveOrder(orders);
        }
        [Test]
        public void CanLoadTest()
        {
            OrderManager manager = OrderManagerFactory.Create();
            TestRepository repo = new TestRepository();

            LookUpResponse response = manager.LookUp("06012019");

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("KY", response.order[0].State);
        }

        [Test]
        public void CanAddTest()
        {
            TestRepository repo = new TestRepository();
            OrderManager manager = OrderManagerFactory.Create();
            AddEditResponse response = new AddEditResponse();

            Order order = new Order();
            order.OrderDate = "06012019";
            List<Order> orders = repo.GetOrder(order.OrderDate);
        

            order.OrderNumber = 1;
            order.CustomerName = "Tim";
            order.State = "KY";
            order.Type = "tile";
            order.Area = 150;
            order.MaterialCost = 100M;
            order.LaborCost = 150M;
            order.Tax = 40M;
            order.Total = 290M;

            response.product = manager.GetProd(response);
            response.tax = manager.GetTax(response);
            bool second = true;

            response = manager.Add(order, second);
            orders = repo.GetOrder(order.OrderDate);

            Assert.AreEqual(2, orders.Count);
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
        }

        [Test]
        [TestCase("06012019",2, "Tim", "CO", "tile", 150, 100, 150, 40, 290)]
        [TestCase("06012019", 2, "Tim!", "KY", "tile", 150, 100, 150, 40, 290)]
        [TestCase("06012019", 2, "Tim", "KY", "tile", 99, 100, 150, 40, 290)]
        [TestCase("06012019", 2, "Tim", "KY", "lint", 150, 100, 150, 40, 290)]
        public void CanAddTestRules(string orderDate, int orderNum, string custName, string abbr, string product, decimal area, decimal matCost, decimal laborCost, decimal tax, decimal total)
        {
            TestRepository repo = new TestRepository();
            OrderManager manager = OrderManagerFactory.Create();
            AddEditResponse response = new AddEditResponse();

            Order order = new Order();
            order.OrderDate = orderDate;
            List<Order> orders = repo.GetOrder(order.OrderDate);


            order.OrderNumber = orderNum;
            order.CustomerName = custName;
            order.State = abbr;
            order.Type = product;
            order.Area = area;
            order.MaterialCost = matCost;
            order.LaborCost = laborCost;
            order.Tax = tax;
            order.Total = total;

            response.product = manager.GetProd(response);
            response.tax = manager.GetTax(response);
            response.order = order;
            bool second = true;

            response = manager.Add(order, true);

            Assert.AreEqual(1, orders.Count);
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Success);
        }

        [Test]
        [TestCase("06012019", "Tim", "CO", "", 150, false)]
        [TestCase("06012019", "Tim", "", "", 150, true)]
        [TestCase("06012019", "Tim", "", "", 99, false)]
        [TestCase("06012019", "Tim", "", "lint", 150, false)]
        public void CanEditTest(string orderDate, string custName, string abbr, string product, decimal area, bool expectedSuccess)
        {
            TestRepository repo = new TestRepository();
            OrderManager manager = OrderManagerFactory.Create();
            AddEditResponse response = new AddEditResponse();

            Order order = new Order();
            order.OrderDate = orderDate;
            List<Order> orders = repo.GetOrder(order.OrderDate);

            Order editOrder = orders[0];
            editOrder.CustomerName = custName;
            editOrder.Type = product;
            editOrder.Area = area;
            editOrder.State = abbr;
            bool second = true;

            response = manager.Edit(editOrder, second);
            response.product = manager.GetProd(response);
            response.tax = manager.GetTax(response);

            orders = repo.GetOrder(order.OrderDate);

            Assert.AreEqual(1, orders.Count);
            Assert.AreEqual("Tim", orders[0].CustomerName);
            Assert.IsNotNull(response);
            Assert.AreEqual(expectedSuccess, response.Success);
        }

        [Test]
        public void CanRemoveTest()
        {
            TestRepository repo = new TestRepository();
            OrderManager manager = OrderManagerFactory.Create();
            DeleteResponse response = new DeleteResponse();

            AddEditResponse responseAdd = new AddEditResponse();

            Order order = new Order();
            order.OrderDate = "06012019";
            List<Order> orders = repo.GetOrder(order.OrderDate);

            order.OrderNumber = 2;
            order.CustomerName = "Tim";
            order.State = "KY";
            order.Type = "tile";
            order.Area = 150;
            order.MaterialCost = 100M;
            order.LaborCost = 150M;
            order.Tax = 40M;
            order.Total = 290M;

            responseAdd.product = manager.GetProd(responseAdd);
            responseAdd.tax = manager.GetTax(responseAdd);
            responseAdd.order = order;
            bool second = true;
            responseAdd = manager.Add(order, second);

            response = manager.Remove(order, second);
            orders = repo.GetOrder(responseAdd.order.OrderDate);

            Assert.AreEqual(1, orders.Count);
            Assert.IsTrue(response.Success);
        }
    }
}
