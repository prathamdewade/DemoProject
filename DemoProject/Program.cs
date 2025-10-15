

using DemoProject.Linq;
using DemoProject.Services;

class Program
{
   public  class A
    {
       public int value;
       public A(int val)
        {
            this.value = val;
        }
        public static A operator+ (A a, A b)
        {
            return new A(a.value +b.value);
        }
        public static A operator-(A a, A b)
        {
            return new A(a.value - b.value );
        }
        public static A operator*(A a, A b)
        {
            return new A(a.value * b.value);
        }

    }
     public static void Main(string[] a)
    {
        //BankApplication.App();
        A a1 = new A(10);
        A a2 = new A(20);
          A a3= a1 + a2;
        Console.WriteLine(a3.value);
        A a4 = a2 - a1;
        Console.WriteLine(a4.value);
    }
}