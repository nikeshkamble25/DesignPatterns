using System;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLConstructor constructor = new XMLConstructor();
            FPMLBuilder fpml = new ForwardDTCCFPML();
            constructor.Construct(fpml);
            Console.WriteLine(fpml.GetDTCCFPML().Request);
            Console.ReadLine();
        }
    }

    #region Product
    class DTCCFPML
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }
        public string Request
        {
            get
            {
                return Header + Body + Footer;
            }
        }
    }
    #endregion

    #region Builder
    #region Builder Abstract
    abstract class FPMLBuilder
    {
        protected DTCCFPML _fpml = null;
        public FPMLBuilder()
        {
            _fpml = new DTCCFPML();
        }
        public DTCCFPML GetDTCCFPML()
        {
            return _fpml;
        }
        public abstract void ConstructHeader();
        public abstract void ConstructBody();
        public abstract void ConstructFooter();
    }
    #endregion
    #region Builder Implementation
    class ForwardDTCCFPML : FPMLBuilder
    {
        public override void ConstructBody()
        {
            this._fpml.Body = "<Body>Foward FPML Contruct</Body>";
        }
        public override void ConstructFooter()
        {
            this._fpml.Footer = "<footer>Foward FPML Contruct</footer>";
        }
        public override void ConstructHeader()
        {
            this._fpml.Footer = "<footer>Foward FPML Contruct</footer>";
        }
    }
    class SpotDTCCFPML : FPMLBuilder
    {
        public override void ConstructBody()
        {
            this._fpml.Body = "<Body>Spot FPML Contruct</Body>";
        }
        public override void ConstructFooter()
        {
            this._fpml.Footer = "<footer>Spot FPML Contruct</footer>";
        }
        public override void ConstructHeader()
        {
            this._fpml.Footer = "<footer>Spot FPML Contruct</footer>";
        }
    }
    class XMLConstructor
    {
        public void Construct(FPMLBuilder fpml)
        {
            fpml.ConstructHeader();
            fpml.ConstructBody();
            fpml.ConstructFooter();
        }
    }
    #endregion
    #endregion
}
