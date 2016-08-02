using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardlyticsTest
{

    public class Triangle<T1, T2, T3>
    {
        private double a;
        private double b;
        private double c;
        //Here type can be genric.. 
        //So user can pass int double and decimal all in one... 
        //we just have to do white listing and check if type is one of them ....


        public Triangle(T1 sideA, T2 sideB, T3 sideC)
        {
            if (!checkType(sideA))
            {
                checkObjectType();
            }
            else
            {
                a = ConvertTodouble(sideA);
            }
            if (!checkType(sideB))
            {
                checkObjectType();
            }
            else
            {
                b = ConvertTodouble(sideB);
            }
            if (!checkType(sideC))
            {
                checkObjectType();
            }
            else
            {
                c = ConvertTodouble(sideC);
            }
        }

        private double ConvertTodouble(Object val)
        {
            return Convert.ToDouble(val);
        }

        private void checkObjectType()
        {
            try
            {
                throw new NotSupportedException("Only int, Decimal, and Double is supported");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("----------------------------------------------------------------------");
                Console.Read();
                Environment.Exit(0);
            }
        }
        private bool checkType(Object type)
        {
            bool intType = type.GetType() == typeof(int);
            bool decimalType = type.GetType() == typeof(decimal);
            bool doubleType = type.GetType() == typeof(double);

            if (intType || decimalType || doubleType)
            {
                return true;
            }
            return false;
        }
        private bool checkInequality()
        {
            return a > b + c || b > a + c || c > a + b;
        }
        private bool checkSide()
        {
            return a <= 0 || b <= 0 || c <= 0;
        }
        private bool checkSidesEqual()
        {
            return a == b && b == c;
        }
        private bool checkTwoSidesEqual()
        {
            return a == b || b == c || c == a;
        }

        public TypeofTriangle triangleType(Triangle<T1, T2, T3> triangle)
        {
            try
            {
                  genralException(triangle.checkSide(), "Side length has to be more then zero");
                  genralException(triangle.checkInequality(), "All side sum has to be larger then remaning sides");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("----------------------------------------------------------------------");
                Console.Read();

                //throw new ApplicationException("Something wrong happened:", ex).Display(); ;
                Environment.Exit(0);
            }

            if (triangle.checkSidesEqual())
            {
                return TypeofTriangle.EQUILATERAL;
            }
            if (triangle.checkTwoSidesEqual())
            {
                return TypeofTriangle.ISOSCELES;
            }
                return TypeofTriangle.SCALENE;
        }

        private void genralException(bool check, string message)
        {
            if (check)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
public enum TypeofTriangle
{
    SCALENE,
    ISOSCELES,
    EQUILATERAL,
    ERROR
}


/*
     *
     * Write a C# application that solves the following problem:
       Take in 3 integer inputs, representing the sides of a triangle, and return the triangle type (Scalene,isosceles, equilateral).
     */

/*
 *  equilateral if all three sides are of equal length,
    isosceles if any two sides are of equal length,
    scalene if no two sides are the same length.
        
Any element of an input set is negative 
Any element of an input set is zero
Any element of an input set is greater than 9
Any element of an input set is an alphabetic letter
Any element of an input set is a character symbol
There are less than three elements of the input set
There are more than three elements of the input set
Any element of an input set is a combination of any of the invalid inputs
 * 
 * 
 */
