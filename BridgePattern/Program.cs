using System;

namespace BridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            DerivativeCalypsoReports derivativeCalypsoReports = new DerivativeCalypsoReports();
            derivativeCalypsoReports.Implementation = new ExcelReport();
            derivativeCalypsoReports.LoadReport();
            derivativeCalypsoReports.ExtractData();
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
    #region Abstraction
    public class CalypsoReports
    {
        protected IReport _implementation;

        public IReport Implementation
        {
            get { return _implementation; }
            set { _implementation = value; }
        }
        public string Name { get; set; }
        public virtual void LoadReport()
        {
            Console.WriteLine("Base Report Load Logic");
        }
        public virtual void ExtractData()
        {
            Console.WriteLine("Base Report Extract Logic");
        }
    }
    #endregion
    #region RedefinedAbstraction
    public class DerivativeCalypsoReports : CalypsoReports
    {
        public override void LoadReport()
        {
            Console.WriteLine("Derivative Report Load Logic");
        }
        public override void ExtractData()
        {
            _implementation.ExtractData();
        }
    }
    public class FXCalypsoReports : CalypsoReports
    {
        public override void LoadReport()
        {
            Console.WriteLine("FX Report Load Logic");
        }
        public override void ExtractData()
        {
            _implementation.ExtractData();
        }
    }
    #endregion
    #region Implementation Contract
    public interface IReport
    {
        void ExtractData();
    }
    #endregion
    #region Implementation
    public class ExcelReport : IReport
    {
        public void ExtractData()
        {
            Console.WriteLine("Logic for Export to Excel");
        }
    }
    public class PDFReport : IReport
    {
        public void ExtractData()
        {
            Console.WriteLine("Logic for Export to Excel");
        }
    }
    #endregion
}
