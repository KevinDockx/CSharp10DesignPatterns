namespace Singleton
{

    public class Logger
    {
        // Lazy<T>
        private static readonly Lazy<Logger> _lazyLogger
            = new Lazy<Logger>(() => new Logger());

        //private static Logger? _instance;

        public static Logger Instance
        {
            get
            {
                return _lazyLogger.Value;
                //if (_instance == null)
                //    _instance = new Logger();
                //return _instance;
            }
        }

        protected Logger() 
        {
        }

        /// <summary>
        /// SingletonOperation
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message) => Console.WriteLine($"Message to log: {message}");
        
    }
  
}
