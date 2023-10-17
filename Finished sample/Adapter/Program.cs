using ClassAdapter;

Console.Title = "Adapter";

// adapter example (same code for object & class adapter)
ICityAdapter adapter = new CityAdapter();
City city = adapter.GetCity();

Console.WriteLine($"{city.FullName}, {city.Inhabitants}");
Console.ReadKey();