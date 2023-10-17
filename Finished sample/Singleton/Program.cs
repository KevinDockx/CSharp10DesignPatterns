using Singleton;

Console.Title = "Singleton";

// call the property getter twice
Logger instance1 = Logger.Instance;
Logger instance2 = Logger.Instance;

if (instance1 == instance2 && instance2 == Logger.Instance)
{
    Console.WriteLine("Instances are the same.");
}

Logger.Log($"Message from {nameof(instance1)}");
// or
Logger.Log($"Message from {nameof(instance2)}");
// or
Logger.Log($"Message from {nameof(Logger.Instance)}");

Console.ReadLine();