using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Services
{

    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string msg) : base(msg) { }

    }
    public class NegetiveAmountException : Exception
    {
        public NegetiveAmountException(string msg) : base(msg) { }
    }

    public class BankApplication
    {
        
      
        public static void App()
        {
            Console.WriteLine("Hi I am App Function");

            decimal bal = 2000;
            decimal amount;
            Console.WriteLine("Enter Your Amount for Withrow");
            amount=Convert.ToDecimal(Console.ReadLine());
            if (amount < 1)
            {
                throw new NegetiveAmountException("plz enter Positive Amount  , u r enter amount like =>" + amount);
            }else if (amount > bal)

            {
                throw new InsufficientBalanceException("u r balnce is insufficieant " + bal + " amount " + amount);
            }
            else
            {
                bal-=amount;
                Console.WriteLine("Amout is withrow");
            }
         
                Console.WriteLine("byyy");


        }
    }
}
