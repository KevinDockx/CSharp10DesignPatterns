using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    /// <summary>
    /// Product
    /// </summary>
    public abstract class DiscountService
    {
        public abstract int DiscountPercentage { get; }

        public override string ToString() => GetType().Name;
    }

    /// <summary>
    /// ConcreteProduct
    /// </summary>
    public class CountryDiscountService : DiscountService
    {
        private readonly string _countryIdentifier;

        public CountryDiscountService(string countryIdentifier)
        {
            _countryIdentifier = countryIdentifier;
        }

        public override int DiscountPercentage
        {
            get
            {
                switch (_countryIdentifier)
                {
                    // if you're from Belgium, you get a better discount :)
                    case "BE":
                        return 20;
                    default:
                        return 10;
                }
            }
        }
    }

    /// <summary>
    /// ConcreteProduct
    /// </summary>
    public class CodeDiscountService : DiscountService
    {
        private readonly Guid _code;

        public CodeDiscountService(Guid code)
        {
            _code = code;
        }

        public override int DiscountPercentage
        {
            // each code returns the same fixed percentage, but a code is only 
            // valid once - include a check to so whether the code's been used before
            // ... 
            get => 15;
        }
    }

    /// <summary>
    /// Creator
    /// </summary>
    public abstract class DiscountFactory
    {
        public abstract DiscountService CreateDiscountService();
    }

    /// <summary>
    /// ConcretCreator
    /// </summary>
    public class CountryDiscountFactory : DiscountFactory
    {
        private readonly string _countryIdentifier;
        public CountryDiscountFactory(string countryIdentifier)
        {
            _countryIdentifier = countryIdentifier;
        }

        public override DiscountService CreateDiscountService()
        {
            return new CountryDiscountService(_countryIdentifier);
        }
    }

    /// <summary>
    /// ConcreteCreator
    /// </summary>
    public class CodeDiscountFactory : DiscountFactory
    {
        private readonly Guid _code;

        public CodeDiscountFactory(Guid code)
        {
            _code = code;
        }
        public override DiscountService CreateDiscountService()
        {
            return new CodeDiscountService(_code);
        }
    } 
}
