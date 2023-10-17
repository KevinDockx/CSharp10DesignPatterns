using Strategy;

Console.Title = "Strategy";

var order = new Order("Marvin Software", 5, "Visual Studio License");
order.Export(new CSVExportService());
order.Export(new JsonExportService());

Console.ReadKey();