using System;

namespace FactoryMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IServiceProviderFactory serviceProviderFactory = new IONServiceProviderFactory();
            var obj = serviceProviderFactory.InternetServiceProviderFactory();
            obj.Install();
            obj.Subscribe();
            Console.Read();
        }
    }

    #region Contracts
    public interface IServiceProvider
    {
        void Install();
        void Subscribe();
    }
    #endregion

    #region Implementation
    public class ION : IServiceProvider
    {
        public void Install()
        {
            Console.WriteLine("Innstallation process/logic for ION");
        }
        public void Subscribe()
        {
            Console.WriteLine("Subscription process/logic for ION");
        }
    }
    public class Hathway : IServiceProvider
    {
        public void Install()
        {
            Console.WriteLine("Innstallation process/logic for Hathway");
        }
        public void Subscribe()
        {
            Console.WriteLine("Subscription process/logic for Hathway");
        }
    }
    #endregion

    #region FactoryContract
    public interface IServiceProviderFactory
    {
        IServiceProvider InternetServiceProviderFactory();
    }
    #endregion

    #region Factory Implementation
    public class IONServiceProviderFactory : IServiceProviderFactory
    {
        public IServiceProvider InternetServiceProviderFactory()
        {
            return new ION();
        }
    }
    public class HathwayServiceProviderFactory : IServiceProviderFactory
    {
        public IServiceProvider InternetServiceProviderFactory()
        {
            return new Hathway();
        }
    }
    #endregion
}
