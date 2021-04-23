using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueTasks
{
    class Dict : Dictionary<int, List<Action>>
    {
        public (List<Action> actions,int? index) Min()
        {
            int? min = null;
            List<Action> action = null;
            foreach (var item in this)
            {
                if (min == null)
                {
                    min = item.Key;
                    action = item.Value;
                }
                if (min > item.Key)
                {
                    min = item.Key;
                    action = item.Value;
                }
            }
            return (action,min);
        }
        public void Add(Action action, int priority)
        {
            if (!this.ContainsKey(priority))
            {
                this.TryAdd(priority, new List<Action>() { action });
                return;
            }
            this[priority].Add(action);
        }

    }
}
