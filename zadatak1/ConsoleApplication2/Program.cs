using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    public class IntegerList : IIntegerList
    {
        private static int maxInd = 0;
        public int[] internalStorage;
        public int Count
        {
            get
            {
                int m = -1;
                for (int i = 0; i < internalStorage.Count(n => n != 0); i++)
                {
                    m++;
                }
                return m + 1;
            }
        }
        public IntegerList()
        {
            this.internalStorage = new int[4];
        }
        public IntegerList(int storage)
        {
            this.internalStorage = new int[storage];
        }
        public int IndexOf(int x)
        {
            for (int i = 0; i < internalStorage.Length; i++)
            {
                if (internalStorage[i] == x) return i;
            }
            return -1;
        }
        public void Add(int x)
        {
            maxInd = internalStorage.Count(n => n != 0);
            if (maxInd == internalStorage.Length - 1)
            {
                int length = internalStorage.Length;
                int[] lista = new int[length * 2];
                Array.Copy(internalStorage, 0, lista, 0, length);
                lista[internalStorage.Length] = x;
                this.internalStorage = new int[length * 2];
                Array.Copy(lista, 0, internalStorage, 0, length + 1);
            }
            else internalStorage[internalStorage.Length] = x;
        }
        public bool RemoveAt(int index)
        {
            for (int i = 0; i < internalStorage.Count(x => x != 0); i++)
            {
                if (i == index)
                {
                    internalStorage[i] = 0;
                    return true;
                }
            }
            return false;
        }
        public bool Remove(int x)
        {
            for (int i = 0; i < internalStorage.Count(n => n != 0); i++)
            {
                if (internalStorage[i] == x) return RemoveAt(i);
            }
            return false;
        }
        public int GetElement(int index)
        {
            for (int i = 0; i < internalStorage.Length; i++)
            {
                if (i == index) return internalStorage[i];
            }
            throw new IndexOutOfRangeException("That shit too big");
        }
        public bool Contains(int x)
        {
            for (int i = 0; i < internalStorage.Length; i++)
            {
                if (internalStorage[i] == x) return true;
            }
            return false;
        }
        public void Clear()
        {
            for (int i = 0; i < internalStorage.Length; i++)
            {
                internalStorage[i] = 0;
            }
        }
    }
    public interface IIntegerList
    {
        int Count { get; }
        void Add(int x);
        bool Remove(int x);
        bool RemoveAt(int index);
        int IndexOf(int x);
        void Clear();
        int GetElement(int index);
        bool Contains(int x);
    }
}