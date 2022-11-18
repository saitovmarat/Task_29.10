using System;
using System.Collections.Generic;
using System.Text;

namespace Task_29._10.Humans
{
    /// <summary>
    /// Бухгалтер
    /// </summary>
    class Accountant : IWorker
    {
        private int tasks;
        public int CountOfTasks => tasks;
        private string name;
        public string Name => name;
        public Accountant(string name)
        {
            this.name = name;
        }
        public void GiveATask(IWorker worker, Task task, List<IWorker> allWorkers)
        {
            Console.WriteLine("Этот работник вообще не может давать задачи");
        }
        public void TakeATask()
        {
            if (tasks > 0)
            {
                Console.WriteLine($"У меня уже {tasks} заданий, куда еще?!");
            }
            tasks++;
        }
    }
}
