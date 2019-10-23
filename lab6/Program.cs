using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicList < string > ArrStr= new DynamicList<string>();
            bool IsEnd = false;
            
            do
            {
                Console.WriteLine("\nНажмите 1, чтобы добавить элемент;\n" +
                "Нажмите 2, чтобы удалить элемент с конца;\n" +
                "Нажмите 3, чтобы удалить определенный элемент;\n" +
                "Нажмите 4, чтобы вывести количество элементовм;\n" +
                "Нажмите 5, чтобы заменить определенный элемент;\n" +
                "Нажмите 6, для очистки массива;\n" +
                "Нажмите 7, чтобы вывести весь массив;\n" +
                "Нажмите 8, чтобы выйти.\n");
            string Choice = Console.ReadLine();
                switch (Choice)
                {
                    case "1":
                        Console.WriteLine("Введите элемент");
                       string addStr = Console.ReadLine();
                        ArrStr.Add(addStr);
                        break;
                    case "2":
                        ArrStr.Remove();
                        break;
                    case "3":
                        int index;
                        Console.WriteLine("Введите индекс элемента");
                        if  (int.TryParse(Console.ReadLine(),out index))
                            ArrStr.RemoveAt(index);
                        break;
                    case "4":
                        Console.WriteLine("Количество = " + ArrStr.count);
                        break;
                    case "5":
                        string elem;
                        Console.WriteLine("Введите индекс и новый элемент");
                        if (int.TryParse(Console.ReadLine(), out index))
                        {
                            elem = Console.ReadLine();
                            ArrStr[index] = elem;
                        }
                        break;
                    case "6":                       
                        ArrStr.Clear();
                        Console.WriteLine("Массив очищен");
                        break;
                    case "7":
                        Console.WriteLine("Ваш массив");
                        foreach (string i in ArrStr)
                            Console.WriteLine(i);
                        break;
                    case "8":
                        IsEnd = true;
                        break;
                }
                    
            } while (!IsEnd);
            Console.ReadKey();
        }
    }


    class DynamicList<T> : IEnumerable, IEnumerator
    {
        private T[] Arr;
        private int Count = 0;
        private int Length = 0;

        public int count// Количество элементов
        {
            get
            {
                return Count;
            }
        }
        public T this[int index]//Доступ к элементам по индексу
        {
            get
            {
                return Arr[index];
            }
            set
            {
                Arr[index] = value;
            }
        }
        public void Add(T elem)//Добавление
        {
            if (Count + 1 > Length)
            {
                Array.Resize(ref Arr, Length + 10);
                Length += 10;                
            }
            Arr[Count++] = elem;
        }
        public void Remove()//Удаление
        {
            if (Count > 0)
            { 
            if (Count - 1 < Length-10)
            {
                Array.Resize(ref Arr, Length - 5);
                Length -= 5;
            }
            Count--;
            }
        }
        public void RemoveAt(int index)//Удаление по индексу
        {
            if (Count > 0)
            {
                for (int i = index; i < Count - 1; i++)
                    Arr[i] = Arr[i + 1];
                if (Count - 1 < Length - 10)
                {
                    Array.Resize(ref Arr, Length - 5);
                    Length -= 5;
                }
                Count--;
            }
        }
        public void Clear()//Удаление всех элементов
        {
             Array.Resize(ref Arr, 0);
            Length =0;
            Count = 0;
        }

        //реализация интерфейса IEnumerable
        int ind = -1;
        public IEnumerator GetEnumerator()
        {
            return this;
        }
        public bool MoveNext()
        {
            if (ind == Count - 1)
            {
                Reset();
                return false;
            }

            ind++;
            return true;
        }

        public void Reset()
        {
            ind = -1;
        }

        public object Current
        {
            get
            {
                return Arr[ind];
            }
        }


    }
}
