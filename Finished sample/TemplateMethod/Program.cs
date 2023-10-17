using TemplateMethod;

Console.Title = "Template Method";

ExchangeMailParser exchangeMailParser = new();
Console.WriteLine(exchangeMailParser.ParseMailBody("bf3a298c-9990-4b02-873d-3d3c98ad16d2"));
Console.WriteLine();

ApacheMailParser apacheMailParser = new();
Console.WriteLine(apacheMailParser.ParseMailBody("07b8a8c7-c598-4b6c-9049-ecce9fe4a56b"));
Console.WriteLine();

EudoraMailParser eudoraMailParser = new();
Console.WriteLine(eudoraMailParser.ParseMailBody("789fe935-ced2-4fbd-865b-172909560a93"));

Console.ReadKey();