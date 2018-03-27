using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary
{
    class Program
    {
        public static int BinarySearch(int[] array, int value)
        {
            if (array.Length == 0) return -1;
            for (int i = 0; i < array.Length; i++)
            { array[i] = Math.Abs(array[i]); }
            value = Math.Abs(value);
            var left = 0;
            var right = array.Length - 1;
            while (left < right)
            {
                var middle = (right + left) / 2;
                if (value >= array[middle])
                    right = middle;
                else left = middle + 1;
            }
            if (array[left] == value)
                return left;
            return -1;
        }

        static void Main(string[] args)
        {
            TestArray();
            TestRepetition();
            TestNegativeNumbers();
            TestNonExistentElement();
            TestEmptyArray();
            TestBigArray();
            Console.ReadKey();
        }

        private static void TestBigArray()
        {
            int[] numbers= new int[100001];
            for (int i = 0; i < 100001; i++)
                numbers[i] = 5;
            numbers[0] = 6;
            if (BinarySearch(numbers, 6) == 0)
                Console.WriteLine("Поиск  массиве из 100001 элементов работает корректно");
            else
                Console.WriteLine("Поиск не нашел числа 6 в массиве из 100001 элемента");
        }

        private static void TestEmptyArray()
        {
            int[] numbers = { };
            if (BinarySearch(numbers, 3) == -1)
                Console.WriteLine("Поиск в пустом массиве работает корректно");
            else
                Console.WriteLine("! Поиск нашел в пустом массиве число 3");
        }

        private static void TestRepetition()
        {
            int[] numbers = new[] { 5, 4, 3, 3, 2};
            if (BinarySearch(numbers, 3) != 2)
                Console.WriteLine("! Поиск не нашёл число 3 среди чисел {5, 4, 3, 3, 2}");
            else
                Console.WriteLine("Поиск среди положительных чисел с повторениями работает корректно");
        }

        private static void TestArray()
        {
            int[] positiveNumbers = new[] { 5, 4, 3, 2, 1};
            if (BinarySearch(positiveNumbers, 3) != 2)
                Console.WriteLine("! Поиск не нашёл число 3 среди чисел {5, 4, 3, 2, 1}");
            else
                Console.WriteLine("Поиск среди положительных чисел работает корректно");
        }

        private static void TestNegativeNumbers()
        {
            //Тестирование поиска в отрицательных числах
            int[] negativeNumbers = new[] { -5, -4, -3, -2};
            if (BinarySearch(negativeNumbers, -3) != 2)
                Console.WriteLine("! Поиск не нашёл число -3 среди чисел {-5, -4, -3, -2}");
            else
                Console.WriteLine("Поиск среди отрицательных чисел работает корректно");
        }

        private static void TestNonExistentElement()
        {
            //Тестирование поиска отсутствующего элемента
            int[] negativeNumbers = new[] { -5, -4, -3, -2 };
            if (BinarySearch(negativeNumbers, -1) >= 0)
                Console.WriteLine("! Поиск нашёл число -1 среди чисел {-5, -4, -3, -2}");
            else
                Console.WriteLine("Поиск отсутствующего элемента вернул корректный результат работает корректно");
        }
    }
}
