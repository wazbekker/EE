namespace EqualExperts;

public class ShoppingCart : IShoppingCart
{
    private decimal Total { get;  set; }
    private decimal TaxTotal { get; set; }
    
    private IList<CartItem> _items = new List<CartItem>();

    public decimal TaxRate { get; private set; }

    public ShoppingCart(decimal taxRate)
    {
        TaxRate = taxRate;
        Total = 0;
        TaxTotal = 0;
    }

    public void AddProductToCart(Product product, int quantity)
    {
        if (!ProductExistsInCart(product))
        {
            var cartItem = new CartItem(product, quantity);

            _items.Add(cartItem);
        }
        else
        {
            var cartItem = _items.SingleOrDefault(x =>
                x.Product.ProductName.Equals(product.ProductName));

            if (cartItem != null)
            {
                cartItem.IncreaseQuantity(quantity);
            }
        }

        var temp = product.Price * quantity;
        
        Total += Math.Round(temp, 2);
        
        TaxTotal += Math.Round(temp * (TaxRate / 100), 2);
    }

    public IList<CartItem> GetCartItems()
    {
        return _items;
    }

    private bool ProductExistsInCart(Product product)
    {
        return _items.Any(x => x.Product.ProductName.Equals(product.ProductName));
    }
    
    public decimal GetTotalWithTax()
    {
        return TaxTotal + Total;
    }

    public decimal GetTax()
    {
        return TaxTotal;
    }
}