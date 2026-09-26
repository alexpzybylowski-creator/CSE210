using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "123 Main Street",
            "New York",
            "NY",
            "USA"
        );

        Customer customer1 = new Customer(
            "John Smith",
            address1
        );

        Product product1 = new Product(
            "Keyboard",
            "K100",
            50.00,
            1
        );

        Product product2 = new Product(
            "Mouse",
            "M200",
            25.00,
            2
        );

        Order order1 = new Order(customer1);

        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Address address2 = new Address(
            "Rua das Flores, 100",
            "Curitiba",
            "Parana",
            "Brazil"
        );

        Customer customer2 = new Customer(
            "Alex",
            address2
        );

        Product product3 = new Product(
            "Monitor",
            "MN300",
            200.00,
            1
        );

        Product product4 = new Product(
            "Headset",
            "H400",
            80.00,
            2
        );

        Product product5 = new Product(
            "Webcam",
            "W500",
            60.00,
            1
        );

        Order order2 = new Order(customer2);

        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        Console.WriteLine("ORDER 1");
        Console.WriteLine("--------------------");

        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}");

        Console.WriteLine();

        Console.WriteLine("ORDER 2");
        Console.WriteLine("--------------------");

        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
    }
}