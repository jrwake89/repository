using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Exercise1();
            Console.WriteLine("");
            Exercise2();
            Console.WriteLine("");
            Exercise3();
            Console.WriteLine("");
            Exercise4();
            Console.WriteLine("");
            Exercise5();
            Console.WriteLine("");
            Exercise6();
            Console.WriteLine("");
            Exercise7();
            Console.WriteLine("");
            Exercise8();
            Console.WriteLine("");
            Exercise9();
            Console.WriteLine("");
            Exercise10();
            Console.WriteLine("");
            Exercise11();
            Console.WriteLine("");
            Exercise12();
            Console.WriteLine("");
            Exercise13();
            Console.WriteLine("");
            Exercise14();
            Console.WriteLine("");
            Exercise15();
            Console.WriteLine("");
            Exercise16();
            Console.WriteLine("");
            Exercise17();
            Console.WriteLine("");
            Exercise18();
            Console.WriteLine("");
            Exercise19();
            Console.WriteLine("");
            Exercise20();
            Console.WriteLine("");
            Exercise21();
            Console.WriteLine("");
            Exercise22();
            Console.WriteLine("");
            Exercise23();
            Console.WriteLine("");
            Exercise24();
            Console.WriteLine("");
            Exercise25();
            Console.WriteLine("");
            Exercise26();
            Console.WriteLine("");
            Exercise27();
            Console.WriteLine("");
            Exercise28();
            Console.Write("");
            Exercise29();
            Console.WriteLine("");
            Exercise30();
            Console.WriteLine("");
            Exercise31();
            Console.WriteLine("");
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {

            var Product = DataLoader.LoadProducts();

            var OutofStock = (Product.Where(product => product.UnitsInStock == 0));

            List<string> OutofStockNames = (from product in OutofStock
                                            select product.ProductName).ToList();

            Console.WriteLine("Exercise 1:");

            foreach (string name in OutofStockNames)
            {
                Console.WriteLine(name);
            }
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            var Product = DataLoader.LoadProducts();

            var InStock = (Product.Where(product => product.UnitsInStock > 0));
            List<string> AboveThreeDollars = (from product in InStock
                                              where product.UnitPrice > 3
                                              select product.ProductName).ToList();

            Console.WriteLine("Exercise 2:");

            foreach (string name in AboveThreeDollars)
            {
                Console.WriteLine(name);
            }
        }

        /// <summary>
        /// Print all customers and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            var Customers = DataLoader.LoadCustomers();

            var RegionWA = (from customer in Customers
                            where customer.Region == "WA"
                            select customer).ToList();


            Console.WriteLine("Exercise 3:");
            foreach (var customer in RegionWA)
            {
                Console.WriteLine(customer.CustomerID);

                foreach (var order in customer.Orders)
                {
                    Console.WriteLine(order.OrderID);
                    Console.WriteLine(order.OrderDate);
                    Console.WriteLine(order.Total);
                    Console.WriteLine("");
                }
            }
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            var Products = DataLoader.LoadProducts();

            var ProductNames = (from product in Products
                                select new
                                {
                                    name = product.ProductName
                                }).ToList();

            Console.WriteLine("Exercise 4:");
            foreach (var product in ProductNames)
            {
                Console.WriteLine(product.name);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            var Products = DataLoader.LoadProducts();

            var ProductList = (from product in Products
                               select new
                               {
                                   name = product.ProductName,
                                   ID = product.ProductID,
                                   price = Convert.ToInt32(product.UnitPrice) * 1.25,
                                   stock = product.UnitsInStock,
                                   category = product.Category
                               }).ToList();

            Console.WriteLine("Exercise 5:");

            foreach (var product in ProductList)
            {
                Console.WriteLine(product.category);
                Console.WriteLine(product.ID);
                Console.WriteLine(product.name);
                Console.WriteLine(product.price);
                Console.WriteLine(product.stock);
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            var Products = DataLoader.LoadProducts();

            var nameAndCategory = from products in Products
                                  select new
                                  {
                                      name = products.ProductName.ToUpper(),
                                      category = products.Category.ToUpper()
                                  };

            Console.WriteLine("Exercise 3:");

            foreach (var product in nameAndCategory)
            {
                Console.WriteLine(product.name);
                Console.WriteLine(product.category);
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            var Products = DataLoader.LoadProducts();

            var ProductList = (from product in Products
                               select new
                               {
                                   name = product.ProductName,
                                   ID = product.ProductID,
                                   price = product.UnitPrice,
                                   stock = product.UnitsInStock,
                                   category = product.Category
                               }).ToList();

            bool ReOrder = false;
            Console.WriteLine("Exercise 7:");

            foreach (var product in ProductList)
            {
                Console.WriteLine(product.category);
                Console.WriteLine(product.ID);
                Console.WriteLine(product.name);
                Console.WriteLine(product.price);
                Console.WriteLine(product.stock);
                if (product.stock < 3)
                {
                    ReOrder = true;
                    Console.WriteLine("Reorder {0}", product.name);
                }
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            var Products = DataLoader.LoadProducts();

            var ProductList = (from product in Products
                               select new
                               {
                                   name = product.ProductName,
                                   ID = product.ProductID,
                                   price = Convert.ToInt32(product.UnitPrice),
                                   stock = product.UnitsInStock,
                                   category = product.Category,
                                   StockValue = Convert.ToDecimal(product.UnitsInStock * product.UnitPrice)
                               }).ToList();

            foreach (var product in ProductList)
            {
                Console.WriteLine(product.category);
                Console.WriteLine(product.ID);
                Console.WriteLine(product.name);
                Console.WriteLine(product.price);
                Console.WriteLine(product.stock);
                Console.WriteLine(product.StockValue);
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            var NumbersA = DataLoader.NumbersA;

            var EvenNum = NumbersA.Where(numbers => numbers % 2 == 0);

            foreach (int numbers in EvenNum)
            {
                Console.WriteLine(numbers);
            }
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            var Customers = DataLoader.LoadCustomers();
            foreach (var customer in Customers)
            {
                int total = 0;
                foreach (var order in customer.Orders)
                {
                    total = total + Convert.ToInt32(order.Total);
                }

                if (total < 500)
                {
                    Console.WriteLine(customer.CustomerID);
                }
            }
        }


        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var NumbersC = DataLoader.NumbersC;

            var OddC = NumbersC.Where(n => n % 2 != 0);

            foreach (int numbers in OddC)
            {
                Console.WriteLine(numbers);
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            var NumbersB = DataLoader.NumbersB;

            var BMinusThree = NumbersB.Skip(3);

            foreach (int number in BMinusThree)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            var Customers = DataLoader.LoadCustomers();

            var NameWA = (from customers in Customers
                          where customers.Region == "WA"
                          select customers).ToList();

            foreach (var customer in NameWA)
            {
                Console.WriteLine(customer.CompanyName);
                var orderTimes = DateTime.Today;

                foreach (var order in customer.Orders)
                {
                    if (orderTimes == DateTime.Today)
                    {
                        orderTimes = order.OrderDate;
                    }
                    else if (orderTimes < order.OrderDate)
                    {
                        orderTimes = order.OrderDate;
                    }
                }
                Console.WriteLine(orderTimes);
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            var NumbersC = DataLoader.NumbersC;
            var SixLess = NumbersC.TakeWhile(n => n < 6);

            foreach (var number in NumbersC)
            {
                if (number < 6)
                {
                    Console.WriteLine(number);
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// ***Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            var NumbersC = DataLoader.NumbersC;

            bool div3 = false;

            foreach(var num in NumbersC)
            {
                if(div3 == false)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine(num);
                }

                if(num % 3 == 0 )
                {
                    div3 = true;
                }
            }

        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            var Products = DataLoader.LoadProducts();

            var Alphabetical = (Products.OrderBy(product => product.ProductName)).ToList();

            foreach (var product in Alphabetical)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("");

        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            var Products = DataLoader.LoadProducts();

            var DescendingStocks = (Products.OrderByDescending(product => product.UnitsInStock)).ToList();

            foreach (var product in DescendingStocks)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("");
        }

        /// <summary>
        /// ***Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            var Products = DataLoader.LoadProducts();

            var Category = (from product in Products
                            group product by product.Category
                            into newProducts
                            select new
                            {
                                category = newProducts,
                            }
                           ).ToList();
            var unitCategory = (from product in Category
                                select new
                                {
                                    unitprice = product.category.OrderByDescending(p => p.UnitPrice)
                                }).ToList();

            foreach (var category in unitCategory)
            {
                foreach (var product in category.unitprice)
                {
                    Console.WriteLine(product.ProductName);
                }
            }
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            var NumbersB = DataLoader.NumbersB;

            var ReverseB = (from nums in NumbersB
                            select new
                            {
                                reverse = NumbersB.Reverse()
                            }).ToList();


            foreach (var number in ReverseB)
            {
                foreach (var num in number.reverse)
                {
                    Console.WriteLine(num);
                }
                break;
            }
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            var Products = DataLoader.LoadProducts();

            var Categories = (from product in Products
                              group product by product.Category
                              into newProduct
                              select new
                              {
                                  category = newProduct,
                                  title = newProduct.Key
                              }).ToList();

            foreach (var product in Categories)
            {
                Console.WriteLine(product.title);
                foreach (var item in product.category)
                {
                    Console.WriteLine(item.ProductName);
                }
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// ***Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {
            var Customers = DataLoader.LoadCustomers();

            foreach (var customer in Customers)
            {
                var innerYear = 0;
                Console.WriteLine(customer.CompanyName);
                foreach (var order in customer.Orders)
                {
                    var year = order.OrderDate.Year;

                    if (innerYear == year)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(year);
                        foreach (var orders in customer.Orders)
                        {
                            if (orders.OrderDate.Year == year)
                            {
                                Console.WriteLine("     {0} -  $ {1}", orders.OrderDate.Month, orders.Total);
                                innerYear = year;
                            }

                        }
                    }
                }
                Console.WriteLine("");
            }

        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            var Products = DataLoader.LoadProducts();

            var Unique = (from product in Products
                          group product by product.Category
                          into uniqueProduct
                          select new
                          {
                              categories = uniqueProduct.Key
                          }).ToList();

            foreach (var category in Unique)
            {
                Console.WriteLine(category.categories);
            }
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            var Products = DataLoader.LoadProducts();

            var NumberCheck = (from product in Products
                               select product.ProductID).ToList();

            bool exist = false;
            foreach (var id in NumberCheck)
            {
                if (id == 789)
                {
                    exist = true;
                }
            }

            if (exist == true)
            {
                Console.WriteLine("Product exists");
            }
            else
            {
                Console.WriteLine("Product doesn't exist");
            }
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            var Products = DataLoader.LoadProducts();

            var Stock = (from product in Products
                         where product.UnitsInStock == 0
                         select product.Category).Distinct().ToList();

            foreach (var category in Stock)
            {
                Console.WriteLine(category);
            }
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            var Products = DataLoader.LoadProducts();

            var AllProduct = (from product in Products
                              group product by product.Category
                            into allProduct
                              select new
                              {
                                  category = allProduct.Key,
                                  allstock = allProduct.All(p => p.UnitsInStock != 0)
                              }).ToList();

            foreach (var category in AllProduct)
            {
                if (category.allstock == true)
                {
                    Console.WriteLine(category.category);
                }
            }
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            var NumA = DataLoader.NumbersA;

            var OddNumA = (from nums in NumA
                           where (nums + 1) % 2 == 0
                           select nums).Count();

            Console.WriteLine(OddNumA);
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            var Customers = DataLoader.LoadCustomers();

            var OrdersnID = (from customer in Customers
                             group customer by customer.CustomerID
                             into sortedCustomer
                             select new
                             {
                                 id = sortedCustomer.Key,
                                 ordernum = sortedCustomer.Sum(p => p.Orders.Count())
                             }).ToList();

            foreach (var customer in OrdersnID)
            {
                Console.WriteLine(customer.id);
                Console.WriteLine(customer.ordernum);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            var Products = DataLoader.LoadProducts();

            var Categories = (from product in Products
                              group product by product.Category
                             into sortedProduct
                              select new
                              {
                                  category = sortedProduct.Key,
                                  num = sortedProduct.Count()
                              }).ToList();

            foreach (var product in Categories)
            {
                Console.WriteLine(product.category);
                Console.WriteLine(product.num);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            var Products = DataLoader.LoadProducts();

            var Categories = (from product in Products
                              group product by product.Category
                             into sortedProduct
                              select new
                              {
                                  category = sortedProduct.Key,
                                  num = sortedProduct.Sum(p => p.UnitsInStock)
                              }).ToList();

            foreach (var product in Categories)
            {
                Console.WriteLine(product.category);
                Console.WriteLine(product.num);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            var Products = DataLoader.LoadProducts();

            var Categories = (from product in Products
                              group product by product.Category
                             into sortedProduct
                              select new
                              {
                                  category = sortedProduct.Key,
                                  num = sortedProduct.OrderBy(p => p.UnitPrice)
                              }).ToList();

            foreach (var product in Categories)
            {
                Console.WriteLine(product.category);
               foreach (var item in product.num)
                {
                    Console.WriteLine(item.UnitPrice);
                    break;
                }
            }
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            var Products = DataLoader.LoadProducts();

            var Categories = (from product in Products
                              group product by product.Category
                             into sortedProduct
                              select new
                              {
                                  category = sortedProduct.Key,
                                  num = sortedProduct.Average(p => p.UnitPrice)
                              }).ToList();
            var RankedCategories = Categories.OrderByDescending(product => product.num).Take(3);

            foreach (var product in RankedCategories)
            {
                Console.WriteLine(product.category);
                Console.WriteLine(product.num);
            }
        }
    }
}
