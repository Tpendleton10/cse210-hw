using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // First Order (US Customer)
        Address address1 = new Address("123 Elm St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Book", "B001", 12.99, 2));
        order1.AddProduct(new Product("Pen", "P001", 1.5, 5));

        // Second Order (International Customer)
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Notebook", "N001", 5.99, 3));
        order2.AddProduct(new Product("Backpack", "BP001", 29.99, 1));

        // Display Results
        DisplayOrder(order1);
        Console.WriteLine("--------------------------");
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalCost():F2}");
    }
}

// ------------------ Product Class ------------------

class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }

    public string GetName()
    {
        return name;
    }

    public string GetProductId()
    {
        return productId;
    }
}

// ------------------ Address Class ------------------

class Address
{
    private string street;
    private string city;
    private string stateProvince;
    private string country;

    public Address(string street, string city, string stateProvince, string country)
    {
        this.street = street;
        this.city = city;
        this.stateProvince = stateProvince;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.Trim().ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {stateProvince}\n{country}";
    }
}

// ------------------ Customer Class ------------------

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string GetName()
    {
        return name;
    }

    public Address GetAddress()
    {
        return address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }
}

// ------------------ Order Class ------------------

class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (Product product in products)
        {
            total += product.GetTotalCost();
        }

        // Shipping cost
        total += customer.IsInUSA() ? 5 : 35;

        return total;
    }

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        foreach (Product product in products)
        {
            sb.AppendLine($"{product.GetName()} ({product.GetProductId()})");
        }
        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        return $"{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
    }
}
