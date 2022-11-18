using System;
using System.Collections.Generic;
using System.Text;

namespace Task_29._10.Humans
{
    /// <summary>
    /// Директор по автоматизации
    /// </summary>
    class AutomaticDirector : IWorker
    {
        private int tasks;
        public int CountOfTasks => tasks;
        private string name;
        public string Name => name;
        private List<IWorker> workers;
        public AutomaticDirector(string name, List<IWorker> workers)
        {
            this.name = name;
            this.workers = workers;
        }
        public void GiveATask(IWorker worker, Task task, List<IWorker> allWorkers)
        {
            if (!ContainWorker(worker))
            {
                Console.WriteLine("Данному человеку нельзя дать задачу");
                return;
            }
            Console.WriteLine($"Вопрос к работнику {worker.Name} будешь ли ты {task.Name} / да / нет");
            if (Console.ReadLine().ToLower().Equals("да"))
            {
                Console.WriteLine($"Он будет {task.Name}");
                worker.TakeATask();
            }
            else
            {
                Console.WriteLine($"{worker}, кому хочешь передать задачу");
                bool flag = false;
                int index = 0;
                while (!flag)
                {
                    if (index != 0)
                    {
                        Console.WriteLine("Нет такого человека в компании \nПопробуйте еще раз.");
                        Console.WriteLine($"{worker.Name}, кому хочешь передать задачу");
                    }

                    string nextWorker = Console.ReadLine();
                    foreach (IWorker human in allWorkers)
                    {
                        if (human.Name.ToLower() == nextWorker.ToLower())
                        {
                            worker.GiveATask(human, task, allWorkers);
                            flag = true;
                        }
                    }
                    index = 1;
                }
            }
        }
        public bool ContainWorker(IWorker worker)
        {
            foreach (IWorker item in workers)
            {
                if (worker == item)
                {
                    return true;

                }

            }
            return false;
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
