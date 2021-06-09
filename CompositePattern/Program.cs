using System;
using System.Collections.Generic;

namespace CompositePattern
{
    class Program
    {
        static LegalEntityComponent legalEntityComponentParent = new LegalEntityParent();
        static void Main(string[] args)
        {
            CreateObject();
            Console.ReadLine();
        }
        static void CreateObject()
        {
            legalEntityComponentParent.LegalEntity = new LegalEntity()
            {
                Id = 1,
                FullName = "Bank Of America",
                ShortName = "Bank Of America"
            };

            LegalEntityComponent legalEntityComponent = new LegalEntityParent();
            legalEntityComponent.LegalEntity = new LegalEntity()
            {
                Id = 1,
                FullName = "Bank Of America London",
                ShortName = "Bank Of America London"
            };
            legalEntityComponentParent.Add(legalEntityComponent);

            legalEntityComponent = new LegalEntityParent();
            legalEntityComponent.LegalEntity = new LegalEntity()
            {
                Id = 1,
                FullName = "Bank Of America UK",
                ShortName = "Bank Of America UK"
            };
            legalEntityComponentParent.Add(legalEntityComponent);
        }
    }
    #region Composite Abstract
    public abstract class LegalEntityComponent
    {
        public LegalEntity LegalEntity { get; set; }
        public abstract void Add(LegalEntityComponent legalEntity);
        public abstract void Remove(LegalEntityComponent legalEntity);
        public abstract List<LegalEntityComponent> GetChild();
    }
    #endregion
    #region Composite Implementation
    public class LegalEntityParent : LegalEntityComponent
    {
        private List<LegalEntityComponent> legalEntityComponents = new List<LegalEntityComponent>();
        public override void Add(LegalEntityComponent legalEntity)
        {
            legalEntityComponents.Add(legalEntity);
        }
        public override void Remove(LegalEntityComponent legalEntity)
        {
            legalEntityComponents.Remove(legalEntity);
        }
        public override List<LegalEntityComponent> GetChild()
        {
            return legalEntityComponents;
        }
    }
    #endregion
    #region Product
    public class LegalEntity
    {
        public int Id { get; set; }
        public String FullName { get; set; }
        public String ShortName { get; set; }
    }
    #endregion
}
