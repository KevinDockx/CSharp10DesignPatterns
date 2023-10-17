using AbstractFactory;

Console.Title = "Abstract Factory";

var belgiumShoppingCartPurchaseFactory = new BelgiumShoppingCartPurchaseFactory();
var shoppingCartForBelgium = new ShoppingCart(belgiumShoppingCartPurchaseFactory);
shoppingCartForBelgium.CalculateCosts();

var franceShoppingCartPurchaseFactory = new FranceShoppingCartPurchaseFactory();
var shoppingCartForFrance = new ShoppingCart(franceShoppingCartPurchaseFactory);
shoppingCartForFrance.CalculateCosts();

Console.ReadKey();