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
            Func<double> func = new Func<double>(() =>
            {
                Console.WriteLine($"PI = {Math.PI}");
                return Math.PI;
            });

            Task.Run<double>(() => { return (double)func.DynamicInvoke(); }).Wait();

        }
    }
}
