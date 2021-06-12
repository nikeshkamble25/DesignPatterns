using System;
using System.Collections.Generic;

namespace IteratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberCollection collection = new NumberCollection();
            for (int i = 0; i < 10; i++)
                collection[i] = i;
            IIterator iterator = collection.CreateIterator();
            Console.WriteLine(iterator.Next());
            Console.WriteLine(iterator.Next());
            Console.WriteLine(iterator.Next());
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
    public interface IIterator
    {
        int First();
        int Next();
        int CurrentValue();
        int Steps();
    }
    public interface ICollection
    {
        IIterator CreateIterator();
    }
    public class NumberCollection : ICollection
    {
        private List<int> collection = new List<int>();
        public IIterator CreateIterator()
        {
            return new PrimeNumberIterator(this);
        }
        public int Count
        {
            get { return collection.Count; }
        }
        public int this[int index]
        {
            get { return collection[index]; }
            set { collection.Insert(index, value); }
        }
    }
    public class PrimeNumberIterator : IIterator
    {
        private NumberCollection _numberCollection;
        private int _current = 0;
        public PrimeNumberIterator(NumberCollection collection)
        {
            _numberCollection = collection;
        }
        public int CurrentValue()
        {
            return _numberCollection[_current];
        }
        public int First()
        {
            return _numberCollection[0];
        }
        public int Last()
        {
            return _numberCollection[_numberCollection.Count];
        }
        public int Next()
        {
            _current = _current + 2;
            return _numberCollection[_current];
        }
        public int Steps()
        {
            return _numberCollection.Count / 2;
        }
    }
}
