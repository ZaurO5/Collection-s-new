using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Program
    {
        public static void Main()
        {
            Calculator<double> calculator = new Calculator<double>();

            while (true)
            {
                Console.WriteLine("Calculator Menu:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.WriteLine("5. Exit");
                Console.Write("Select an operation: ");
                string choice = Console.ReadLine();

                if (choice == "5")
                {
                    Console.WriteLine("Exit");
                    break;
                }

                Console.Write("Enter the first number: ");
                double num1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter the second number: ");
                double num2 = Convert.ToDouble(Console.ReadLine());

                try
                {
                    double result = 0;

                    switch (choice)
                    {
                        case "1":
                            result = calculator.Add(num1, num2);
                            break;
                        case "2":
                            result = calculator.Subtract(num1, num2);
                            break;
                        case "3":
                            result = calculator.Multiply(num1, num2);
                            break;
                        case "4":
                            result = calculator.Divide(num1, num2);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            continue;
                    }

                    Console.WriteLine($"The result is: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine();
            }
        }
    }
}
