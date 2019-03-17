using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public class ProcessData
    {
        public void Process(int x, int y, BizRulesDelegate rulesDelegate)
        {
            var result = rulesDelegate(x, y);
            Console.WriteLine("Process result is: {0}", result);
        }

        public void ProcessAction(int x, int y, Action<int, int> del)
        {
            del(x, y);
            Console.WriteLine("Action has been processed.\n");
        }

        public void ProcessFunc(int x, int y, Func<int, int, int> del)
        {
            var result = del(x, y);
            Console.WriteLine("Process result is: {0}", result);
        }
    }
}
