using FactoryMethod;

Console.Title = "Factory Method";

var factories = new List<DiscountFactory> {
    new CodeDiscountFactory(Guid.NewGuid()),
    new CountryDiscountFactory("BE") };

foreach (DiscountFactory factory in factories)
{
    DiscountService discountService = factory.CreateDiscountService();
    Console.WriteLine($"Percentage {discountService.DiscountPercentage} " +
        $"coming from {discountService}");
}

Console.ReadKey();