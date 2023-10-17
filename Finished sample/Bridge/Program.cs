using Bridge;

Console.Title = "Bridge";

var noCoupon = new NoCoupon();
var oneEuroCoupon = new OneEuroCoupon();

var meatBasedMenu = new MeatBasedMenu(noCoupon);
Console.WriteLine($"Meat based menu, no coupon: {meatBasedMenu.CalculatePrice()} euro.");

meatBasedMenu = new MeatBasedMenu(oneEuroCoupon);
Console.WriteLine($"Meat based menu, one euro coupon: {meatBasedMenu.CalculatePrice()} euro.");

var vegetarianMenu = new VegetarianMenu(noCoupon);
Console.WriteLine($"Vegetarian menu, no coupon: {vegetarianMenu.CalculatePrice()} euro.");

vegetarianMenu = new VegetarianMenu(oneEuroCoupon);
Console.WriteLine($"Vegetarian menu, one euro coupon: {vegetarianMenu.CalculatePrice()} euro.");

Console.ReadKey();