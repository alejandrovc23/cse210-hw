class Program
{
    static void Main(string[] args)
    {
        // === ORDER 1 ===
        Address address1 = new Address("742 Evergreen Terrace", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("Homer Simpson", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Duff Beer", "A01", 3.50, 10));
        order1.AddProduct(new Product("Donut Box", "B55", 8.99, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}\n");

        // === ORDER 2 ===
        Address address2 = new Address("Av. Javier Prado 1234", "Lima", "Lima", "Peru");
        Customer customer2 = new Customer("Alejandro Valladares", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Laptop Lenovo", "L88", 1200, 1));
        order2.AddProduct(new Product("Mouse Logitech", "M10", 25, 1));
        order2.AddProduct(new Product("USB Kingston 64GB", "U33", 15, 2));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}\n");
    }
}
