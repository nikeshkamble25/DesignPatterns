using System;

namespace FacadeDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var FXTradeDto = new FXTradeDto()
            {
                Amount1 = 100,
                Amount2 = 200,
                CCY1 = "USD",
                CCY2 = "CAD",
                Rate1 = "1.000",
                Rate2 = "2.000",
                SDI1 = "2.000",
                SDI2 = "2.000"
            };
            IPO ipo = new IPO();
            ipo.Save(FXTradeDto);
        }
    }
    public class FXTradeDto
    {
        public double Amount1 { get; set; }
        public double Amount2 { get; set; }
        public String CCY1 { get; set; }
        public String CCY2 { get; set; }
        public String SDI1 { get; set; }
        public String SDI2 { get; set; }
        public String Rate1 { get; set; }
        public String Rate2 { get; set; }
    }
    public class IPO
    {
        private Trade trade;
        private SDI sdi;
        private Rates rate;
        public IPO()
        {
            trade = new Trade();
            sdi = new SDI();
            rate = new Rates();
        }
        public void Save(FXTradeDto fXTrade)
        {
            trade.SaveTrade(fXTrade);
            sdi.SaveSDI(fXTrade);
            rate.SaveRates(fXTrade);
        }
    }
    public class Trade
    {
        public void SaveTrade(FXTradeDto fXTrade)
        {
            Validation();
            Console.WriteLine("Trade related data saved");
        }
        private void Validation()
        {
            Console.WriteLine("Some Sort of Validation");
        }
    }
    public class SDI
    {
        public void SaveSDI(FXTradeDto fXTrade)
        {
            Validation();
            Console.WriteLine("Trade related data saved on SDI");
        }
        private void Validation()
        {
            Console.WriteLine("Some Sort of Validation On SDI");
        }
    }
    public class Rates
    {
        public void SaveRates(FXTradeDto fXTrade)
        {
            Validation();
            Console.WriteLine("Trade related data saved on Rates");
        }
        private void Validation()
        {
            Console.WriteLine("Some Sort of Validation On Rates");
        }
    }
}
