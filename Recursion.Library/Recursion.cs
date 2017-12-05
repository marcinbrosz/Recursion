using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * In mathematics, the factorial of a non-negative integer n, denoted by n!, is the product of all positive integers less than or equal to n. For example,

5! = 5 * 4 * 3 * 2 * 1 = 120.*/
namespace Recursion.Library
{
    public class Recursion
    {
        public static ulong Factorial(ulong n)
        {
            checked
            {
                if (n == 0)
                    return 1;

                return n * Factorial(n - 1);
            }
        }
    }
}
