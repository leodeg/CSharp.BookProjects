//using System;
//using System.Text;
//using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesAndEvents
{
    //----------------------------------------------------------------------------------
    // Define a delegates.
    //----------------------------------------------------------------------------------

    public delegate void WorkPerformedHandler(int hours, WorkType workType);

    public delegate int WorkPerformedIntegerHandler(int hours, WorkType workType);

    public delegate int BizRulesDelegate(int x, int y);

    public delegate int OperationsDelegate(int x, int y);

    //----------------------------------------------------------------------------------
    // Start the program.
    //----------------------------------------------------------------------------------

    internal class Program
    {
        private static void Main(string[] args)
        {
            UseCustomer();
        }

        //----------------------------------------------------------------------------------
        // Use Methods
        //----------------------------------------------------------------------------------

        private static void UseDelegateHandler()
        {
            // Create a new delegate handler.
            WorkPerformedHandler delegateOne = new WorkPerformedHandler(WorkPerformedOne);
            WorkPerformedHandler delegateTwo = new WorkPerformedHandler(WorkPerformedTwo);
            WorkPerformedHandler delegateThree = new WorkPerformedHandler(WorkPerformedThree);
            WorkPerformedHandler delegateFour = new WorkPerformedHandler(WorkPerformedFour);

            DisplayDarkYellow("\n-------------------------------\n");
            // Call the method by delegate handler.
            delegateOne(1, WorkType.Golf);
            delegateTwo(5, WorkType.GoToMeetings);

            DisplayDarkYellow("\n-------------------------------\n");
            DoWork(delegateOne);

            System.Console.WriteLine();
        }

        private static void UseDelegateInvocationListHandler()
        {
            WorkPerformedHandler delegateOne = new WorkPerformedHandler(WorkPerformedOne);
            WorkPerformedHandler delegateTwo = new WorkPerformedHandler(WorkPerformedTwo);
            WorkPerformedHandler delegateThree = new WorkPerformedHandler(WorkPerformedThree);

            // Invocation list
            delegateOne += delegateTwo;
            delegateOne += delegateThree;

            // This is will be duplicate all queue of the delegate calls
            //delegateOne += delegateOne;

            // Return delegate Two -> Three.
            //delegateOne = delegateTwo + delegateThree;

            // Return delegate One -> Two -> Three.
            //delegateOne += delegateTwo + delegateThree;

            delegateOne(10, WorkType.GenerateReports); // Generate Delegate parameters

            System.Console.WriteLine();
        }

        private static void UseDelegateReturningAInvocationListValue()
        {
            WorkPerformedIntegerHandler delegateOne = new WorkPerformedIntegerHandler(WorkPerformedIntegerOne);
            WorkPerformedIntegerHandler delegateTwo = new WorkPerformedIntegerHandler(WorkPerformedIntegerTwo);
            WorkPerformedIntegerHandler delegateThree = new WorkPerformedIntegerHandler(WorkPerformedIntegerThree);

            delegateOne += delegateTwo + delegateThree;

            int finalHours = delegateOne(10, WorkType.GenerateReports);
            System.Console.WriteLine(finalHours);

            // Output:
            // 13
            // Because one variable can hold only one value.
            // And in this example the last value will be a returned value of the delegateThree.

            System.Console.WriteLine();
        }

        private static void UseWorker()
        {
            var worker = new Worker();

            // Long signature.
            //worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(worked_WorkPerformed);

            // Add event. Short signature.
            worker.WorkPerformed += Worker_WorkPerformed;
            worker.WorkCompleted += Worker_WorkCompleted;

            // Disable last message about work completion.
            //worker.WorkCompleted -= Worker_WorkCompleted;

            worker.DoWork(8, WorkType.GenerateReports);
        }

        private static void UseWorkerByAnonymousMethods()
        {
            var worker = new Worker();

            worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
            {
                System.Console.WriteLine(e.Hours.ToString() + " hours.");
            };

            worker.WorkCompleted += delegate (object sender, EventArgs e)
            {
                System.Console.WriteLine("Worker is done.");
            };

            worker.DoWork(8, WorkType.GenerateReports);
        }

        private static void UseWorkerByLambdaMethods()
        {
            var worker = new Worker();
            worker.WorkPerformed += (sender, e) => System.Console.WriteLine("Worked: {0} hours. Doing {1}.", e.Hours.ToString(), e.WorkType);
            worker.WorkCompleted += (sender, e) => System.Console.WriteLine("Worker is done.");
            worker.DoWork(6, WorkType.Golf);
        }

        private static void LambdaUsingExample()
        {
            OperationsDelegate addDelegate = (a, b) => a + b;

            int resultOne = addDelegate(1, 1);
            int resultTwo = addDelegate(2, 2);
            int resultThree = addDelegate(3, 3);

            Console.WriteLine(resultOne);
            Console.WriteLine(resultTwo);
            Console.WriteLine(resultThree);
        }

        private static void UseProcessDataRulesDelegate()
        {
            BizRulesDelegate addDelegate = (x, y) => x + y;
            BizRulesDelegate multiplyDelegate = (x, y) => x * y;
            BizRulesDelegate substrDelegate = (x, y) => x - y;
            BizRulesDelegate divideDelegate = (x, y) => x / y;

            var data = new ProcessData();

            data.Process(2, 3, addDelegate);
            data.Process(2, 3, multiplyDelegate);
            data.Process(2, 3, substrDelegate);
            data.Process(2, 3, divideDelegate);
        }

        private static void UseActionOfT()
        {
            var data = new ProcessData();

            Action<int, int> addAction = (x, y) => Console.WriteLine("Addition result is: {0}", x + y);
            Action<int, int> multAction = (x, y) => Console.WriteLine("Multiplication result is: {0}", x * y);
            Action<int, int> substrAction = (x, y) => Console.WriteLine("Subtraction result is: {0}", x - y);
            Action<int, int> divideAction = (x, y) => Console.WriteLine("Division result is: {0}", x / y);

            data.ProcessAction(2, 3, addAction);
            data.ProcessAction(2, 3, multAction);
            data.ProcessAction(2, 3, substrAction);
            data.ProcessAction(2, 3, divideAction);
        }

        private static void UseFuncOfT()
        {
            Func<int, int, int> funcAddDel = (x, y) => x + y;
            Func<int, int, int> funcMultDel = (x, y) => x * y;
            Func<int, int, int> funcSubstrDel = (x, y) => x - y;
            Func<int, int, int> funcDivideDel = (x, y) => x / y;

            var data = new ProcessData();

            data.ProcessFunc(5, 3, funcAddDel);
            data.ProcessFunc(5, 3, funcMultDel);
            data.ProcessFunc(5, 3, funcSubstrDel);
            data.ProcessFunc(5, 3, funcDivideDel);
        }

        private static void UseCustomer()
        {
            //---------------
            // Create a new List for lambda work example.
            //---------------

            var customers = new List<Customer>
            {
                new Customer {City = "Phoenix", FirstName = "John", LastName = "Joshua", ID = 1},
                new Customer {City = "Phoenix", FirstName = "Jane", LastName = "Joshua", ID = 2},
                new Customer {City = "Seattle", FirstName = "Suzuki", LastName = "Ramon", ID = 3},
                new Customer {City = "New York City", FirstName = "Michelle", LastName = "Jackson", ID = 4}
            };

            //---------------
            // Filters.
            //---------------

            var phoenix = customers
                .Where((customer) => customer.City == "Phoenix");

            var phoenixByFirstNameOrder = customers
                .Where((customer) => customer.City == "Phoenix")
                .OrderBy((customer) => customer.FirstName);

            var phoenixByLastNameOrder = customers
                .Where((customer) => customer.City == "Phoenix")
                .OrderBy((customer) => customer.LastName);

            //---------------
            // Display by filters.
            //---------------

            Console.WriteLine("Simple displaying.");
            foreach (var customer in phoenix)
            {
                Console.WriteLine("{0} live in {1}", customer.FirstName, customer.City);
            }

            Console.WriteLine("\nBy FirstName.");
            foreach (var customer in phoenixByFirstNameOrder)
            {
                Console.WriteLine("{0} live in {1}", customer.FirstName, customer.City);
            }

            Console.WriteLine("\nBy LastName.");
            foreach (var customer in phoenixByLastNameOrder)
            {
                Console.WriteLine("{0} {1} live in {2}", customer.FirstName, customer.LastName, customer.City);
            }
        }

        //----------------------------------------------------------------------------------
        // Event helper methods.
        //----------------------------------------------------------------------------------

        private static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            System.Console.WriteLine("Worker is done!");
        }

        private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            System.Console.WriteLine("Hours worked: " + e.Hours + " : " + e.WorkType);
        }

        //----------------------------------------------------------------------------------
        // Return Void Delegate
        //----------------------------------------------------------------------------------

        private static void DoWork(WorkPerformedHandler del)
        {
            del(3, WorkType.GenerateReports);
        }

        private static void WorkPerformedOne(int hours, WorkType workType)
        {
            System.Console.WriteLine("WorkPerformed One is worked");
            System.Console.WriteLine("We will be '{0}' about {1} hour(s)", workType, hours);
            System.Console.WriteLine();
        }

        private static void WorkPerformedTwo(int hours, WorkType workType)
        {
            System.Console.WriteLine("WorkPerformed Two is worked");
            System.Console.WriteLine("We will be '{0}' about {1} hour(s)", workType, hours);
            System.Console.WriteLine();
        }

        private static void WorkPerformedThree(int hours, WorkType workType)
        {
            System.Console.WriteLine("WorkPerformed Three is worked");
            System.Console.WriteLine("We will be '{0}' about {1} hour(s)", workType, hours);
            System.Console.WriteLine();
        }

        private static void WorkPerformedFour(int hours, WorkType workType)
        {
            System.Console.WriteLine("WorkPerformed Four is worked");
            System.Console.WriteLine("We will be '{0}' about {1} hour(s)", workType, hours);
            System.Console.WriteLine();
        }

        //----------------------------------------------------------------------------------
        // Return Integer Delegate
        //----------------------------------------------------------------------------------

        private static int WorkPerformedIntegerOne(int hours, WorkType workType)
        {
            System.Console.WriteLine("WorkPerformedInteger One is working");
            return hours + 1;
        }

        private static int WorkPerformedIntegerTwo(int hours, WorkType workType)
        {
            System.Console.WriteLine("WorkPerformedInteger Two is working");
            return hours + 2;
        }

        private static int WorkPerformedIntegerThree(int hours, WorkType workType)
        {
            System.Console.WriteLine("WorkPerformedInteger Three is working");
            return hours + 3;
        }

        //----------------------------------------------------------------------------------
        // Other Helper Methods
        //----------------------------------------------------------------------------------

        private static void DisplayDarkYellow(string text)
        {
            System.Console.ForegroundColor = System.ConsoleColor.DarkYellow;
            System.Console.WriteLine(text);
            System.Console.ForegroundColor = System.ConsoleColor.DarkGreen;
        }
    }
}