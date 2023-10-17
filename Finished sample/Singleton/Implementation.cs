namespace Singleton;

/// <summary>
/// Singleton
/// </summary>
public class Logger
{
    // Lazy<T>
    static readonly Lazy<Logger> _lazyLogger
        = new(() => new Logger());

    // static Logger? _instance;

    /// <summary>
    /// Instance
    /// </summary>
    public static Logger Instance => _lazyLogger.Value;//if (_instance == null)//{//    _instance = new Logger();//}//return _instance;

    protected Logger()
    {
    }

    /// <summary>
    /// SingletonOperation
    /// </summary>
    public static void Log(string message) => Console.WriteLine($"Message to log: {message}");
}
