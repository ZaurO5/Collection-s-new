using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator<T> where T : struct, IComparable, IConvertible, IFormattable
    {
        public T Add(T a, T b)
        {
            return (dynamic)a + (dynamic)b;
        }

        public T Subtract(T a, T b)
        {
            return (dynamic)a - (dynamic)b;
        }

        public T Multiply(T a, T b)
        {
            return (dynamic)a * (dynamic)b;
        }

        public T Divide(T a, T b)
        {
            if ((dynamic)b == 0)
            {
                throw new DivideByZeroException("Can't divide by zero.");
            }
            return (dynamic)a / (dynamic)b;
        }
    }

}
