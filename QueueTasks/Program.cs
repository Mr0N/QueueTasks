using System;
using System.Threading.Tasks;

namespace QueueTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueMethod queue = new QueueMethod();
            queue.Add(() => Console.WriteLine("2"), 2);
            queue.Add(() => Console.WriteLine("0=>1"), 0);
            queue.Add(() => Console.WriteLine("0=>2"), 0);
            queue.Add(() => Console.WriteLine("0=>3"), 0);
            queue.Add(() => Console.WriteLine("3"), 3);
            queue.Add(() => Console.WriteLine("1"), 1);
            queue.Add(() => Console.WriteLine("5"), 5);
            queue.ParallelStart();
            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}
