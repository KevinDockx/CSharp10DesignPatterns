namespace FactoryMethod;

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
    readonly string _countryIdentifier;

    public CountryDiscountService(string countryIdentifier) => _countryIdentifier = countryIdentifier;

    public override int DiscountPercentage => _countryIdentifier switch
    {
        // if you're from Belgium, you get a better discount :)
        "BE" => 20,
        _ => 10,
    };
}

/// <summary>
/// ConcreteProduct
/// </summary>
public class CodeDiscountService : DiscountService
{
    readonly Guid _code;

    public CodeDiscountService(Guid code) => _code = code;

    public override int DiscountPercentage => 15;
}

/// <summary>
/// Creator
/// </summary>
public abstract class DiscountFactory
{
    public abstract DiscountService CreateDiscountService();
}

/// <summary>
/// ConcreteCreator
/// </summary>
public class CountryDiscountFactory : DiscountFactory
{
    readonly string _countryIdentifier;
    public CountryDiscountFactory(string countryIdentifier) => _countryIdentifier = countryIdentifier;

    public override DiscountService CreateDiscountService() => new CountryDiscountService(_countryIdentifier);
}

/// <summary>
/// ConcreteCreator
/// </summary>
public class CodeDiscountFactory : DiscountFactory
{
    readonly Guid _code;

    public CodeDiscountFactory(Guid code) => _code = code;
    public override DiscountService CreateDiscountService() => new CodeDiscountService(_code);
}
