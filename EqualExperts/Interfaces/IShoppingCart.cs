namespace EqualExperts;

public interface IShoppingCart
{
    void AddProductToCart(Product product, int quantity);

    IList<CartItem> GetCartItems();

    // decimal Total { get; }
    
    // decimal TaxTotal { get; }

    decimal GetTotalWithTax();

    decimal GetTax();
}