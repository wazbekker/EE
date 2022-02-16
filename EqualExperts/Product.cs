namespace EqualExperts;

public class Product
{
    // public Guid ProductId { get; private set; }
    
    public string ProductName { get; private set; }

    public decimal Price { get; set; }

    public Product(string productName, decimal price)
    {
        // ProductId = productId;
        ProductName = productName;
        Price = price;
    }
}