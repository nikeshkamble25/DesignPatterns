using System;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            InternetFactory.GetInternetProvider(ISPS.ION).Assemble();

            Console.ReadLine();
        }
    }

    #region Contracts
    interface IInternetProvider
    {
        void Assemble();
        void Subscribe();
    }
    #endregion

    #region Factory 
    class InternetFactory
    {
        public static IInternetProvider GetInternetProvider(ISPS iSPS)
        {
            if (iSPS == ISPS.ION)
                return new ION();
            if (iSPS == ISPS.Hathway)
                return new Hathway();
            return null;
        }
    }
    #endregion

    #region Implementation
    class ION : IInternetProvider
    {
        public void Assemble()
        {
            Console.WriteLine("Logic for ION Assembly");
        }

        public void Subscribe()
        {
            Console.WriteLine("Logic for ION Subscription");
        }
    }

    class Hathway : IInternetProvider
    {
        public void Assemble()
        {
            Console.WriteLine("Logic for Hathway Assembly");
        }

        public void Subscribe()
        {
            Console.WriteLine("Logic for Hathway Subscription");
        }
    }
    #endregion

    #region Support
    enum ISPS
    {
        ION,
        Hathway
    }
    #endregion
}
