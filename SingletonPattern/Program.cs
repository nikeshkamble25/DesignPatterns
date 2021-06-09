using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Instance.Log();
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }

    public class Logger
    {
        private static Logger _logger;
        private Logger()
        {

        }
        public static Logger Instance {
            get {
                if (_logger != null)
                    return _logger;
                else
                    return new Logger();
            }
        }
        public void Log()
        {

        }
        public void ABC()
        {

        }
    }
}
