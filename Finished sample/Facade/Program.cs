using Facade;
 
var facade = new DiscountFacade();
Console.WriteLine($"Discount percentage for customer with id 1: {facade.CalculateDiscountPercentage(1)}");
Console.WriteLine($"Discount percentage for customer with id 10: {facade.CalculateDiscountPercentage(10)}");

Console.ReadKey();