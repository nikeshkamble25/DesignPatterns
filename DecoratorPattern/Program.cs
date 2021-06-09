using System;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            float ccyAmount = 1000;
            ICalculation calculation = new MTMCalculation();
            SpotPointDecorator spotPointDecorator = new SpotPointDecorator();
            spotPointDecorator.SetDecorator(calculation);
            ForwardPointDecorator fwdPointDecorator = new ForwardPointDecorator();
            fwdPointDecorator.SetDecorator(spotPointDecorator);
            Console.WriteLine("Caclulation "+fwdPointDecorator.Calculate(ccyAmount)); 
            Console.Read();
        }
    }
    public interface ICalculation
    {
        float Calculate(float amount);
    }
    public class MTMCalculation : ICalculation
    {
        public float Calculate(float amount)
        {
            return amount;
        }
    }
    public abstract class CalculationDecorator : ICalculation
    {
        protected ICalculation _calculation;
        public void SetDecorator(ICalculation calculation)
        {
            _calculation = calculation;
        }
        public virtual float Calculate(float amount)
        {
            return _calculation.Calculate(amount);
        }
    }

    public class ForwardPointDecorator : CalculationDecorator
    {
        public override float Calculate(float amount)
        {
            return base.Calculate(amount) + 10;
        }
    }
    public class SpotPointDecorator : CalculationDecorator
    {
        public override float Calculate(float amount)
        {
            return base.Calculate(amount) + 20;
        }
    }
}
