using System;

namespace ChainofResposnibility
{
    class Program
    {
        static void Main(string[] args)
        {
            TradeFlow frontOffice = new FrontOffice();
            TradeFlow middleOffice = new MiddleOffice();
            TradeFlow backOffice = new BackOffice();
            frontOffice.SetSuccessor(middleOffice);
            middleOffice.SetSuccessor(backOffice);

            frontOffice.ProcessTrade();

            Console.ReadLine();
        }
    }
    public abstract class TradeFlow
    {
        protected TradeFlow _tradeFlow = null;
        public void SetSuccessor(TradeFlow tradeFlow)
        {
            _tradeFlow = tradeFlow;
        }
        public abstract void ProcessTrade();
    }
    public class BackOffice : TradeFlow
    {
        public override void ProcessTrade()
        {
            Console.WriteLine("Back Office Processed");
            if (_tradeFlow != null)
                _tradeFlow.ProcessTrade();
        }
    }
    public class FrontOffice : TradeFlow
    {
        public override void ProcessTrade()
        {
            Console.WriteLine("Front Office Processed");
            if (_tradeFlow != null)
                _tradeFlow.ProcessTrade();
        }
    }
    public class MiddleOffice : TradeFlow
    {
        public override void ProcessTrade()
        {
            Console.WriteLine("Middle Office Processed");
            if (_tradeFlow != null)
                _tradeFlow.ProcessTrade();
        }
    }
}
