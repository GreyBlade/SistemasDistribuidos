using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrencia
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Primer console" + System.Threading.Thread.CurrentThread.ManagedThreadId);
            List<int> dataList = new List<int>();

            for (int i = 0; i < 500000; i++)
            {
                dataList.Add(i);
            }

            Parallel.ForEach(dataList, (c) =>
            {
                
                Console.WriteLine("data = " + c);
            });
           
         /*   Task tarea = new Task(() => { Console.WriteLine("Primer Task" + System.Threading.Thread.CurrentThread.ManagedThreadId); });
            tarea.Start();
            Task tarea2 = new Task(DoSomthing);
            tarea2.Start();
         */

            Console.WriteLine("Fin" + System.Threading.Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();

        }

        static void DoSomthing()
        {
            Console.WriteLine("Segundo Task" + System.Threading.Thread.CurrentThread.ManagedThreadId);
        }

        static void RunATask()
        {
            Task task = new Task(() => Console.WriteLine("As a Lambda"));
            task.Start();

            Task task2 = new Task(new Action(() => Console.WriteLine("As an action")));
            task2.Start();

            Task.Factory.StartNew(() => { Console.WriteLine("Using task factory"); });
            
        }

        static void ParallelTask()
        {
            Parallel.Invoke(
                RunATask,
                DoSomthing
                );
        }
    }
}
