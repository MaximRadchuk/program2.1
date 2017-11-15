using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Многопоточность1
{
    class SortBoobleThread
    {
        int count = 0;
        int[] mas;
        object locker = new object();
        List<string> res = new List<string>();

        public void BubbleSortWithTreads(int[] mas)
        {
            this.mas = mas;
            Thread[] threads = new Thread[mas.Length-1];
            while (count <= mas.Length)
            {

                for (int i = 0; i + 1 < mas.Length; i += 2)
                {
                        int k = i;
                       //ThreadPool.QueueUserWorkItem((x) => BubbleSortPart(x, k, k + 1));
                        threads[i] = new Thread((x) => BubbleSortPart(x, k, k + 1));
                        threads[i].Start();
                    
                }
             
                count++;
                if (count <= mas.Length)
                {
                    for (int i = 1; i + 1 < mas.Length; i += 2)
                    {
                           int k = i;
                          // ThreadPool.QueueUserWorkItem((x) => BubbleSortPart(x, k, k + 1));
                           threads[i] = new Thread((x) => BubbleSortPart(x, k, k + 1));
                           threads[i].Start();
                    }
 
                    count++;
                }
            }
           // Thread.Sleep(20);
            foreach (Thread t in threads)
            {
                t.Join();
            }

              Console.WriteLine("Многопоточная сортировка: ");
              for (int k = 0; k < res.Count; k++)
              {
                      if(k%2==0)
                      Console.WriteLine(res[k]);
                      else
                      {
                          Console.Write(res[k]);
                          Console.WriteLine();
                      }
                          
              }
        }

        public void BubbleSortPart(object x, int first, int second)
        {
            lock (locker)
            {
                if (mas[first] > mas[second])
                {

                    int tmp = mas[first];
                    mas[first] = mas[second];
                    mas[second] = tmp;
                }
          
                res.Add("Поток поменял элементы "+ mas[first].ToString()+" и "+ mas[second].ToString());
                string s = null;
                foreach (int i in mas)
                {
                  s+=i.ToString() + ' ';
                }
                res.Add(s);
            }
        }
    }
}
