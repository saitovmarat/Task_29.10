using System;
using System.Collections.Generic;
using System.Text;

namespace Task_29._10
{
    interface IWorker
    {
        public int CountOfTasks { get;}
        public string Name { get; }
        public void GiveATask(IWorker worker, Task task, List<IWorker> allWorkers);
        public void TakeATask();


    }
}
