using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvocationHW
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double> func = new Func<double>(() => { return Math.PI; });

            Task<double> result;

            result = Task.Run<double>(() => { return (double)func.DynamicInvoke(); });

            Console.WriteLine($"PI = {result.Result}");

        }
    }
}
