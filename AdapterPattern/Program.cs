using System;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            DerivativeTrade trade = new DerivativeTrade()
            {
                Amount = 10,
                CCY = "USD",
                MTMRate = 1000,
                FWDMarketRate = 20,
                SpotMarketRate = 81
            };
            //FX Trade 
            IFXTrade derivativeAdapter = new DerivativeAdapter(trade);
            Console.WriteLine(derivativeAdapter.MTMRate);
            Console.ReadLine();
        }
    }

    public interface IFXTrade
    {
        string CCY1 { get; set; }
        string CCY2 { get; set; }
        double Amount1 { get; set; }
        double Amount2 { get; set; }
        double MTMRate { get; set; }
    }
    public interface IDerivativeTrade
    {
        string CCY { get; set; }
        double Amount { get; set; }
        double MTMRate { get; set; }
        double SpotMarketRate { get; set; }
        double FWDMarketRate { get; set; }
    }

    public class FXTrade : IFXTrade
    {
        public string CCY1 { get; set; }
        public string CCY2 { get; set; }
        public double Amount1 { get; set; }
        public double Amount2 { get; set; }
        public double MTMRate { get; set; }
    }
    public class DerivativeTrade : IDerivativeTrade
    {
        public string CCY { get; set; }
        public double Amount { get; set; }
        public double MTMRate { get; set; }
        public double SpotMarketRate { get; set; }
        public double FWDMarketRate { get; set; }
    }
    public class DerivativeAdapter : IFXTrade
    {
        private readonly DerivativeTrade trade;

        public DerivativeAdapter(DerivativeTrade trade)
        {
            this.trade = trade;
        }
        public string CCY1
        {
            get
            {
                return this.trade.CCY;
            }
            set
            {
                CCY1 = value;
            }
        }
        public string CCY2
        {
            get
            {
                return this.trade.CCY;
            }
            set
            {
                CCY2 = value;
            }
        }
        public double Amount1
        {
            get
            {
                return this.trade.Amount;
            }
            set
            {
                Amount1 = value;
            }
        }
        public double Amount2
        {
            get
            {
                return this.trade.Amount;
            }
            set
            {
                Amount2 = value;
            }
        }
        public double MTMRate
        {
            get
            {
                return trade.SpotMarketRate + trade.FWDMarketRate + trade.MTMRate;
            }
            set
            {
                MTMRate = value;
            }
        }
    }
}