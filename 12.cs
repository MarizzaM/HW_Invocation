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
            Func<string> func = new Func<string>(() => { return "Asynchronous ";   });
            func += () => { return "Programming "; };
            func += () => { return "Model"; };

            string str = "";

            List < Task<string> > strList = new List<Task<string>>();

            foreach (Delegate del in func.GetInvocationList())
            {
                strList.Add(Task.Run<string>(() => { return (string)del.DynamicInvoke(); }));
            }

            Thread.Sleep(500);

            Task.WaitAll(strList.ToArray());
            foreach (Task<string> t in strList)
            {
                str += t.Result;
            }
            Console.WriteLine(str);
        }
    }
}
