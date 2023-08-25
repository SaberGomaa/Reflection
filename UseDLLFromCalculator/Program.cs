using Calculator;
using System.Reflection;

namespace UseDLLFromCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.LoadFrom("E:\\c#\\NDM\\Calculator\\Calculator\\bin\\Debug\\net6.0\\Calculator.dll");

            var className = "Calculator.";
            Console.WriteLine("Enter Class Name ");
            className += Console.ReadLine();

            var methodName = "";
            Console.WriteLine("Enter Function Name ");
            methodName = Console.ReadLine();

            var classType = assembly.GetType(className);

            var instance = Activator.CreateInstance(classType);

            int size;
            Console.WriteLine("Enter Number Of Parameter : ");

            size = int.Parse(Console.ReadLine());
            
            object[] arr = new object[size];

            Console.WriteLine($"Enter {size} Parameters : ");

            for (int i = 0; i < size; i++)
            {
                arr[i] = int.Parse(Console.ReadLine()) ;
            }

            var methodInfo = classType.GetMethod(methodName);

            var result = methodInfo.Invoke(instance, arr);
            Console.WriteLine(result);
        }
    }
}