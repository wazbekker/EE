using System;
using System.Linq;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace EqualExperts.Tests;

public class ShoppingCartTests
{
    private IShoppingCart _shoppingCart;
    private Product _doveSoapProduct = new Product("Dove Soap", 39.99m);
    private Product _axeDeoProduct = new Product("Axe Deo", 99.99m);

    public ShoppingCartTests()
    {
    }

    [Fact]
    public void Add_Product_To_Cart_Test()
    {
        _shoppingCart = new ShoppingCart(0m);
        
        _shoppingCart.AddProductToCart(_doveSoapProduct, 5);

        var items = _shoppingCart.GetCartItems();

        items.ShouldAllBe(item => item.Product.Equals(_doveSoapProduct));

        items.ShouldAllBe(items => items.Quantity == 5);

        var total = _shoppingCart.GetTotalWithTax();

        Assert.Equal(199.95m, total);
    }

    [Fact]
    public void Get_Shopping_Cart_Total_Test()
    {
        _shoppingCart = new ShoppingCart(0m);
        
        _shoppingCart.AddProductToCart(_doveSoapProduct, 5);
        _shoppingCart.AddProductToCart(_doveSoapProduct, 3);

        var items = _shoppingCart.GetCartItems();

        items.ShouldAllBe(item => item.Product.Equals(_doveSoapProduct));

        items.ShouldAllBe(items => items.Quantity == 8);

        var total = _shoppingCart.GetTotalWithTax();

        Assert.Equal(319.92m, total);
    }

    [Fact]
    public void Get_Shopping_Cart_Tax_Rate()
    {
        _shoppingCart = new ShoppingCart(12.5m);
        
        _shoppingCart.AddProductToCart(_doveSoapProduct, 2);
        _shoppingCart.AddProductToCart(_axeDeoProduct, 2);

        var items = _shoppingCart.GetCartItems();

        var doveSoapItems = items.Where(x => x.Product.ProductName.Equals(_doveSoapProduct.ProductName)).ToList();
        doveSoapItems.Count.ShouldBe(1);

        doveSoapItems.Single().Quantity.ShouldBe(2);

        var axeDeoItems = items.Where(x => x.Product.ProductName.Equals(_axeDeoProduct.ProductName)).ToList();
        axeDeoItems.Count.ShouldBe(1);
        axeDeoItems.Single().Quantity.ShouldBe(2);

        var total = _shoppingCart.GetTotalWithTax();

        Assert.Equal(314.96m, total);

        var taxTotal = _shoppingCart.GetTax();

        Assert.Equal(35, taxTotal);
    }
}