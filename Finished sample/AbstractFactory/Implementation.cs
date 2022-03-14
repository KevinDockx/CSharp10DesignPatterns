using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    /// <summary>
    /// AbstractFactory
    /// </summary>
    public interface IShoppingCartPurchaseFactory
    {
        IDiscountService CreateDiscountService();
        IShippingCostsService CreateShippingCostsService();
    }

    /// <summary>
    ///  AbstractProduct
    /// </summary>
    public interface IDiscountService
    {
        int DiscountPercentage { get; }
    }

    /// <summary>
    /// ConcreteProduct
    /// </summary>
    public class BelgiumDiscountService : IDiscountService
    {
        public int DiscountPercentage => 20;
    }

    /// <summary>
    /// ConcreteProduct
    /// </summary>
    public class FranceDiscountService : IDiscountService
    {
        public int DiscountPercentage => 10;
    }

    /// <summary>
    ///  AbstractProduct
    /// </summary>
    public interface IShippingCostsService
    {
        decimal ShippingCosts { get; }
    }

    /// <summary>
    /// ConcreteProduct
    /// </summary>
    public class BelgiumShippingCostsService : IShippingCostsService
    {
        public decimal ShippingCosts => 20;
    }

    /// <summary>
    /// ConcreteProduct
    /// </summary>
    public class FranceShippingCostsService : IShippingCostsService
    {
        public decimal ShippingCosts => 25;
    }


    public class BelgiumShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new BelgiumDiscountService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new BelgiumShippingCostsService();
        }
    }


    public class FranceShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new FranceDiscountService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new FranceShippingCostsService();
        }
    }


    /// <summary>
    /// Client class 
    /// </summary>
    public class ShoppingCart
    {
        private readonly IDiscountService _discountService;
        private readonly IShippingCostsService _shippingCostsService;
        private int _orderCosts;

        // Constructor
        public ShoppingCart(IShoppingCartPurchaseFactory factory)
        {
            _discountService = factory.CreateDiscountService();
            _shippingCostsService = factory.CreateShippingCostsService();
            // assume that the total cost of all the items we ordered = 200 euro
            _orderCosts = 200;
        }

        public void CalculateCosts()
        {
            Console.WriteLine($"Total costs = {_orderCosts - (_orderCosts / 100 * _discountService.DiscountPercentage) + _shippingCostsService.ShippingCosts }");
        }
    } 
}
