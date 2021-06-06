using System;

namespace AbstractFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IBroadBandProviderFactory serviceProviderFactory = new GeoBroadBandProviderFactory();
            var obj = serviceProviderFactory.GetInternetServiceProvider();
            obj.Install();
            obj.Subscribe();

            var obj1 = serviceProviderFactory.GetMobileService();
            obj1.ProvideSimCard();

            Console.ReadLine();
        }
    }

    #region Contracts
    public interface IServiceProvider
    {
        void Install();
        void Subscribe();
    }
    public interface IBackOffice
    {
        void RaiseARequest();
        void AssignRequest();
    }
    public interface IMobileService
    {
        void Recharge();
        void ProvideSimCard();
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
    public class GEO : IServiceProvider
    {
        public void Install()
        {
            Console.WriteLine("Innstallation process/logic for GEO");
        }
        public void Subscribe()
        {
            Console.WriteLine("Subscription process/logic for GEO");
        }
    }
    public class IONBackOffice : IBackOffice
    {
        public void AssignRequest()
        {
            Console.WriteLine("Assign Request process/logic for ION");
        }

        public void RaiseARequest()
        {
            Console.WriteLine("Raise Request process/logic for ION");
        }
    }
    public class HathwayBackOffice : IBackOffice
    {
        public void AssignRequest()
        {
            Console.WriteLine("Assign Request process/logic for Hathway");
        }
        public void RaiseARequest()
        {
            Console.WriteLine("Raise Request process/logic for Hathway");
        }
    }
    public class GEOBackOffice : IBackOffice
    {
        public void AssignRequest()
        {
            Console.WriteLine("Assign Request process/logic for GEO");
        }
        public void RaiseARequest()
        {
            Console.WriteLine("Raise Request process/logic for GEO");
        }
    }
    public class GEOMobile : IMobileService
    {
        public void ProvideSimCard()
        {
            Console.WriteLine("Provide Sim Card GEO");
        }

        public void Recharge()
        {
            Console.WriteLine("Recharge Sim Card GEO");
        }
    }
    #endregion

    #region Abstract Factory Contract
    public interface IServiceProviderFactory
    {
        IServiceProvider GetInternetServiceProvider();
        IBackOffice GetBackOffice();
    }

    #region Abstract Factory Contract extrnsion
    public interface IBroadBandProviderFactory : IServiceProviderFactory
    {
        IMobileService GetMobileService();
    }
    #endregion
    #endregion

    #region Factory Implementation
    public class IONServiceProviderFactory : IServiceProviderFactory
    {
        public IBackOffice GetBackOffice()
        {
             return new IONBackOffice();
        }

        public IServiceProvider GetInternetServiceProvider()
        {
             return new ION();
        }
    }
    public class HathwayServiceProviderFactory : IServiceProviderFactory
    {
        public IBackOffice GetBackOffice()
        {
            return new HathwayBackOffice();
        }

        public IServiceProvider GetInternetServiceProvider()
        {
            return new Hathway();
        }
    }

    public class GeoBroadBandProviderFactory : IBroadBandProviderFactory
    {
        public IBackOffice GetBackOffice()
        {
            return new GEOBackOffice();
        }

        public IServiceProvider GetInternetServiceProvider()
        {
            return new GEO();
        }

        public IMobileService GetMobileService()
        {
            return new GEOMobile();
        }
    }
    #endregion
}
