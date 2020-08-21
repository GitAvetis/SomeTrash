using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Udemy
{
    public interface IBaseCollection
    {
        void Add(object obj);
        void Remove(object obj);
        //void Clear(); не будет работать без доп. реализации 
    }
    public static class BaseCollectionExtension
    {
        public static void AddRange(this IBaseCollection collection, IEnumerable<object> objects)
        {
            foreach (var item in objects)
            {
                collection.Add(item);
            }
        }
    }
    public class BaseList : IBaseCollection
    {
        private object[] items;
        private int count = 0;
        public BaseList(int initialCapacity)
        {
            items = new object[initialCapacity];
        }
        public void Add(object obj)
        {
            items[count] = obj;
            count++;
        }

        public void Remove(object obj)
        {
            items[count] = null;
            count--;
        }
    }
    public abstract class IBaseCollection2
    {
        public abstract void Add2(object obj);
        public abstract void Remove2(object obj);
        public virtual void Clear()
        {
            Console.WriteLine("Default Implementation");
        }
    }
    public class BaseList2 : IBaseCollection2
    {
        private object[] items;
        private int count = 0;
        public BaseList2(int initialCapacity)
        {
            items = new object[initialCapacity];
        }
        public override void Add2(object obj)
        {
            items[count] = obj;
            count++;
        }

        public override void Remove2(object obj)
        {
            items[count] = null;
            count--;
        }
    }


}
