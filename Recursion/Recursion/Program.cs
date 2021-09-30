using System;
// Если будем много раз вызывать рекурсивно, будет преполнение стека. В данном случае переполнение
// стека будет при вызове больше чем 10750. 10750 не каждый раз, 10800 точно переполнение.
namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter a Number");

            //read number from user    
            int number = Convert.ToInt32(Console.ReadLine());

            //invoke the static method    
            double factorial = Factorial(number);

            //print the factorial result    
            Console.WriteLine("factorial of" + number + "=" + factorial.ToString());
            Console.ReadKey();

        }
        public static double Factorial(int number)
        {
            if (number == 0)
                return 1;
            return number * Factorial(number - 1);//Recursive call    

        }
    }
}