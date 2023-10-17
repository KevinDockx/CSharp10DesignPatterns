namespace Facade;

/// <summary>
/// Subsystem class
/// </summary>
public class OrderService
{
    public static bool HasEnoughOrders(int customerId) =>
        // does the customer have enough orders?  
        // fake calculation for demo purposes
        customerId > 5;
}

/// <summary>
/// Subsystem class
/// </summary>
public class CustomerDiscountBaseService
{
    public double CalculateDiscountBase(int customerId) =>
        // fake calculation for demo purposes
        (customerId > 8) ? 10 : 20;
}

/// <summary>
/// Subsystem class
/// </summary>
public static class DayOfTheWeekFactorService
{
    public static double CalculateDayOfTheWeekFactor() =>
        // fake calculation for demo purposes
        DateTime.UtcNow.DayOfWeek switch
        {
            DayOfWeek.Saturday or DayOfWeek.Sunday => 0.8,
            _ => 1.2,
        };
}

/// <summary>
/// Facade
/// </summary>
public class DiscountFacade
{
    //readonly OrderService _orderService = new();
    readonly CustomerDiscountBaseService _customerDiscountBaseService = new();
    //readonly DayOfTheWeekFactorService _dayOfTheWeekFactorService = new();

    public double CalculateDiscountPercentage(int customerId) => OrderService.HasEnoughOrders(customerId)
            ? _customerDiscountBaseService.CalculateDiscountBase(customerId)
                * DayOfTheWeekFactorService.CalculateDayOfTheWeekFactor()
            : 0;
}
