using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Linq
{
    class Generic<T>
    {
        public static void Display(T[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write($"Roll No {i+1}  Marks ==> [");
                for(int j=0;j< arr.GetLength(1); j++)
                {
                    Console.Write(arr[i,j]+" ");
                }
                Console.WriteLine("]");
                
            }
        }

        public static void Show(T[,] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(" "+item);
            }
        }
    }

    public class App
    {

        public static int[] SumOfMarks(int[,] arr)
        {
            int[] sum = new int[arr.GetLength(0)];
            for (int i = 0; i < arr.GetLength(0); i++)
            {

                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    sum[i] += arr[i, j];
                }
            }
            return sum;
        }
        public static void M1()
        {

            int[,] sm = new int[3, 3] {
                { 44,22,33 },
                {11,55,40},
                {31,41,21 }

            };
           

          int[] sum= SumOfMarks(sm);
            foreach (var item in sm)
            {
                Console.WriteLine("Sum Of => "+item);
            }

            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            foreach (var item in sum)
            {
                Console.WriteLine("Sum Of => " + item);
            }
            //for (int i = 0; i < sm.GetLength(0); i++)
            //{
            //    Console.Write($"Roll No {i + 1} wnter u Marks  Marks ==> [");
            //    for (int j = 0; j < sm.GetLength(1); j++)
            //    {
            //        sm[i, j] = Convert.ToInt32(Console.ReadLine());
            //    }
            //}
            Generic<int>.Display(sm);

        }
        }
    }

 