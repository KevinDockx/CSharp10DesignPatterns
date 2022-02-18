using Adapter;
using Adapter.ClassAdapter;

// adapter example (same code for object & class adapter)
ICityAdapter adapter = new CityAdapter();
var city = adapter.GetCity();

Console.WriteLine($"{city.FullName}, {city.Inhabitants}");
Console.ReadKey(); 