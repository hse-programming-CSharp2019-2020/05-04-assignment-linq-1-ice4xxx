using System;
using System.Linq;

/*
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * На основе полученных чисел получить новое по формуле: 5 + a[0] - a[1] + a[2] - a[3] + ...
 * Это необходимо сделать двумя способами:
 * 1) с помощью встроенного LINQ метода Aggregate
 * 2) с помощью своего метода MyAggregate, сигнатура которого дана в классе MyClass
 * Вывести полученные результаты на экран (естесственно, они должны быть одинаковыми)
 * 
 * Пример входных данных:
 * 1 2 3 4 5
 * 
 * Пример выходных:
 * 8
 * 8
 * 
 * Пояснение:
 * 5 + 1 - 2 + 3 - 4 + 5 = 8
 * 
 * 
 * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 */

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk04();
        }

        public static void RunTesk04()
        {
            int[] arr = new int[1];
            try
            {
                // Попробуйте осуществить считывание целочисленного массива, записав это ОДНИМ ВЫРАЖЕНИЕМ.
                arr = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(i => int.Parse(i)).ToArray();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("ArgumentException");
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException");
            }

            bool t = false;
            int arrAggregate = 0;
            int arrMyAggregate = 0;

            try
            {
                // использовать синтаксис методов! SQL-подобные запросы не писать!
                checked
                {


                    arrAggregate = arr.Aggregate(5, (x, y) =>
                    {
                        t ^= true;
                        return x + y * (t ? 1 : -1);
                    });

                    arrMyAggregate = MyClass.MyAggregate(arr);

                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("ArgumentException");
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException");
            }


            Console.WriteLine(arrAggregate);
                Console.WriteLine(arrMyAggregate);

                Console.ReadKey();

        }
    }

    static class MyClass
    {
        public static int MyAggregate(int[] arr)
        {
            bool t = false;
            return arr.Aggregate(5, (x, y) =>
            {
                t ^= true;
                return x + y * (t ? 1 : -1);
            });
        }
    }
}
