using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Practice.com.generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program : MyClass
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello to C# world...");
            MyClass obj = new MyClass();
            obj.addMethod();

            Rectangle objReact = new Rectangle();
            objReact.Display();

            NumberManipulator n = new NumberManipulator();

            Console.WriteLine("Factorial of 5 is : {0}", n.factorial(5));
            Console.WriteLine("Factorial of 7 is : {0}", n.factorial(7));
            Console.ReadLine();


        }
    }

    class Rectangle
    {

        // member variables
        double length;
        double width;

        public void Acceptdetails()
        {
            length = 4.5;
            width = 3.5;
        }
        public double GetArea()
        {
            return length * width;
        }
        public void Display()
        {
            Console.WriteLine("Length: {0}", length);
            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Area: {0}", GetArea());
        }
    }

    class NumberManipulator
    {

        public int factorial(int num)
        {
            /* local variable declaration */
            int result;
            if (num == 1)
            {
                return 1;
            }
            else
            {
                result = factorial(num - 1) * num;
                return result;
            }
        }

       
    }
}
