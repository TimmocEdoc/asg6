using System;
using System.Collections.Generic;
using System.Threading;

namespace asg6
{
    class Program
    {
        public int n = 377;
        public List<int> FiboList = new List<int>();
        public int fiboIndex;
        public static int mode;
        public static void Main(string[] args)
        {
            mode = 0;
            Thread t1 = new Thread(new Program().Fibo);
            Thread t2 = new Thread(new Program().Number);
            t1.Start();
            t2.Start();
        }

        public void Number()
        {
            int second = 0;
            int minute = 0;
            while (mode == 0)
            {
                second++;
                if (second > 59)
                {
                    second = 0;
                    minute++;
                }
                Console.WriteLine("Timer: "+minute.ToString("D2")+":"+second.ToString("D2"));
                Thread.Sleep(1000);
            }
            Console.WriteLine("Final result: "+minute.ToString("D2")+":"+second.ToString("D2"));
        }

        public void Fibo()
        {
            for (int i = 1; i <= n; i++)
            {
                if (isFibo(i))
                {
                    FiboList.Add(i);
                    Console.WriteLine("Fibonaci: " + i);
                    Thread.Sleep(100);
                }
            }
            fiboIndex = FiboList.Count - 1;
            Console.WriteLine("Final result: " + FiboList[fiboIndex]);
            mode = 1;
        }
        
        public bool isFibo(int number)
        {
            if (number == 1 || number == 2)
            {
                return true;
            }
            else
            {
                int x1 = 1, x2 = 1, x3 = 2;
                while (x3 <= number)
                {
                    x1 = x2;
                    x2 = x3;
                    x3 = x1 + x2;
                    if (number == x3)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}