using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Многопоточность1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите массив через пробел:");
            string[] str = (Console.ReadLine()).Split(' ');
            int[] arr = BoobleSort.ToInt(str);
            int[] tr = BoobleSort.ToInt(str);
            Console.WriteLine("Сортировка в один поток:");
            BoobleSort.SortB(arr);
            Console.WriteLine();
            SortBoobleThread sbs = new SortBoobleThread();
            sbs.BubbleSortWithTreads(tr);
            Console.ReadKey();
        }
    }
}
