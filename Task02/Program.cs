using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

/* В задаче не использовать циклы for, while. Все действия по обработке данных выполнять с использованием LINQ
 * 
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * Необходимо оставить только те элементы коллекции, которые предшествуют нулю, или все, если нуля нет.
 * Дважды вывести среднее арифметическое квадратов элементов новой последовательности.
 * Вывести элементы коллекции через пробел.
 * Остальные указания см. непосредственно в коде.
 * 
 * Пример входных данных:
 * 1 2 0 4 5
 * 
 * Пример выходных:
 * 2,500
 * 2,500
 * 1 2
 * 
 * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 * В случае возникновения иных нештатных ситуаций (например, в случае попытки итерирования по пустой коллекции) 
 * выбрасывайте InvalidOperationException!
 */
namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk02();
        }

        public static void RunTesk02()
        {
            int[] arr = new int[1];
            try
            {
                // Попробуйте осуществить считывание целочисленного массива, записав это ОДНИМ ВЫРАЖЕНИЕМ.
                arr = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(i => int.Parse(i)).ToArray();
            }
            catch(OverflowException)
            {
                Console.WriteLine("OverflowException");
            }


            var filteredCollection = arr.TakeWhile(i => i != 0).ToList();

            try
            {

                // использовать статическую форму вызова метода подсчета среднего
                double averageUsingStaticForm = Enumerable.Average(filteredCollection.Select(i => i * i));
                // использовать объектную форму вызова метода подсчета среднего
                double averageUsingInstanceForm = filteredCollection.Select(i => i * i).Average();

                Console.WriteLine($"{averageUsingStaticForm:f3}");
                Console.WriteLine($"{averageUsingInstanceForm:f3}");

                // вывести элементы коллекции в одну строку
                filteredCollection.ForEach(t => Console.Write(t + " "));
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("InvalidOperationException");
            }

            Console.ReadKey();
        }
        
    }
}
