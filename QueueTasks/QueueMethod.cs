using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueTasks
{

    class QueueMethod : IMethod
    {
        Dict actions;
        public void Add(Action action, int priority)
        {
            this.actions.Add(action, priority);
        }
        public void Start()
        {
            while (this.actions.Count > 0)
            {
                var min = this.actions.Min();
                foreach (var item in min.actions)
                    item.Invoke();
                if (min.index != null)this.actions.Remove(min.index.Value);
            }
        }
        public void ParallelStart()
        {
            List<Task> ls = new List<Task>();
            while (this.actions.Count > 0)
            {
                var min = this.actions.Min();
                foreach (var item in min.actions)
                    ls.Add(Task.Run(() => item.Invoke()));
                Task.WaitAll(ls.ToArray());
                if (min.index != null) this.actions.Remove(min.index.Value);
            }
        }
        public QueueMethod()
        {
            this.actions = new Dict();
        }
    }
}
