using System;
using composition3.Entities.Enum;
using composition3.Entities;
using System.Globalization;

namespace composition3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Client Data:");
            Console.Write("Name: ");
            string clientName = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter order data: ");          

            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client client = new Client(clientName, email, birthDate);
            Order order = new Order(birthDate, status, client);

            Console.Write("How many items to this order? ");
            int nItems = int.Parse(Console.ReadLine());

            for (int i = 1; i <= nItems; i++)
            {
                Console.WriteLine("Enter #{0} item data:",i);
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Product product = new Product(productName, productPrice);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                OrderItem orderItem = new OrderItem(quantity, productPrice, product);
                order.AddItem(orderItem);
            }
            Console.WriteLine();
            Console.WriteLine("Order Summary:");
            Console.WriteLine(order);

        }
    }
}
