using System;
using System.Text;

namespace Lesson03
{
    class Program
    {
        private class myPoint
        {
            private int x;
            private int y;
            private int z;

            public myPoint(int _x, int _y, int _z)
            {
                this.x = _x;
                this.y = _y;
                this.z = _z;
            }

            public double distance(myPoint anotherPoint)
            {
                double distance = 0.0;
                distance = Math.Sqrt(Math.Pow((anotherPoint.x - this.x), 2) + Math.Pow((anotherPoint.y - this.y), 2) + Math.Pow((anotherPoint.z - this.z), 2));
                return distance;
            }

            public override String ToString()
            {
                return String.Format("({0, 3}, {1, 3}, {2, 3})", this.x, this.y, this.z);
            }
        }

        static private int findDigitNumber(int _number)
        {
            int count = 0;
            int localNumber = _number;
            do
            {
                localNumber /= 10;
                count++;
            } while (localNumber > 0);
            return count;
        }

        static private bool checkPalindrom(int _number)
        {
            bool isPalindrom = false;
            int equalsCount = 0;
            int localNumber = _number;
            int rightNumber, leftNumber;
            int count = findDigitNumber(_number); // TODO: надо определить разрядность числа
            int digit = 10;
            while (count > 1)
            {
                leftNumber = (int)(localNumber / Math.Pow(digit, count - 1));
                rightNumber = (int)(localNumber % Math.Pow(digit, 1));
                if (leftNumber == rightNumber)
                {
                    equalsCount++;
                }
                localNumber = (int)((int)(localNumber / Math.Pow(digit, 1)) % Math.Pow(digit, count - 1 - 1));
                count -= 2;
            }
            if (equalsCount == (int)(findDigitNumber(_number) / 2))
            {
                isPalindrom = true;
            }
            else
            {
                isPalindrom = false;
            }
            return isPalindrom;
        }

        static private void printQubeTable(int N)
        {
            StringBuilder strBuild = new StringBuilder();
            strBuild.Append(N + " -> ");
            for (int i = 1; i <= N; i++)
            {
                strBuild.Append(Math.Pow(i, 3));
                if (i != N)
                {
                    strBuild.Append(", ");
                }
            }
            Console.WriteLine(strBuild.ToString());
            strBuild.Clear();
        }

        static void Main(string[] args)
        {
            /*
             * Задача 19
             * Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.
             * 14212 -> нет
             * 12821 -> да
             * 23432 -> да
             */
            Console.WriteLine("\nЗадача 19");
            Console.WriteLine("---------");
            int[] array = { 14212, 12821, 23432, 24641, 456654, 1345423 };
            foreach (int item in array)
            {
                if (checkPalindrom(item))
                {
                    Console.WriteLine("{0} - да", item);
                }
                else
                {
                    Console.WriteLine("{0} - нет", item);
                }
            }
            Console.WriteLine("=======================================================================");
            /* Задача 21
            * Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.
            * A (3,6,8); B (2,1,-7), -> 15.84
            * A (7,-5, 0); B (1,-1,9) -> 11.53
            */
            Console.WriteLine("\nЗадача 21");
            Console.WriteLine("---------");
            myPoint pointA = new myPoint(3, 6, 8);
            myPoint pointB = new myPoint(2, 1, -7);
            Console.WriteLine("A {0} B {1} -> {2:f2}", pointA.ToString(), pointB.ToString(), pointA.distance(pointB));
            pointA = new myPoint(7, -5, 0);
            pointB = new myPoint(1, -1, 9);
            Console.WriteLine("A {0} B {1} -> {2:f2}", pointA.ToString(), pointB.ToString(), pointA.distance(pointB));
            Console.WriteLine("=======================================================================");
            /* Задача 23
            * Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.
            * 3 -> 1, 8, 27
            * 5 -> 1, 8, 27, 64, 125             * 
            */
            Console.WriteLine("\nЗадача 23");
            Console.WriteLine("---------");
            printQubeTable(3);
            printQubeTable(5);

            Console.ReadKey();
        }
    }
}
