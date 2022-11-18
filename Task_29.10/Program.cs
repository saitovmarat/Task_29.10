using System;
using System.Collections.Generic;
using Task_29._10;
using Task_29._10.Humans;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            #region *Configuration*
            IWorker flag = new Worker("tttt");

            IWorker administrationWorker1 = new Worker("Илья");
            IWorker administrationWorker2 = new Worker("Витя");
            IWorker administrationWorker3 = new Worker("Женя");

            IWorker developmentWorker1 = new Worker("Марат");
            IWorker developmentWorker2 = new Worker("Дина");
            IWorker developmentWorker3 = new Worker("Ильдар");
            IWorker developmentWorker4 = new Worker("Антон");


            IWorker developmentDeputy = new Deputy("Ляйсан", new List<IWorker>() { developmentWorker1, developmentWorker2, developmentWorker3, developmentWorker4 });
            IWorker mainDeveloper = new MainDeveloper("Сергей", new List<IWorker>() { developmentDeputy });
            
            IWorker administrationDeputy = new Deputy("Иваныч", new List<IWorker>() {administrationWorker1, administrationWorker2, administrationWorker3 });
            IWorker mainAdminstrator = new MainAdministrator("Ильшат", new List<IWorker>() {administrationDeputy });

            IWorker itDeputy = new Deputy("Володя", new List<IWorker>() { mainAdminstrator, mainDeveloper });
            IWorker itChief = new Chief("Оркадий", new List<IWorker>() { itDeputy });

            IWorker accountant = new Accountant("Лукас");

            IWorker automaticDirector = new AutomaticDirector("О Ильхам", new List<IWorker> { itChief });
            IWorker financeDirector = new FinanceDirector("Рашид", new List<IWorker> { accountant });
            IWorker mainDirector = new MainDirector("Борис", new List<IWorker> { automaticDirector, financeDirector });


            List<IWorker> allWorkers = new List<IWorker>() 
            {
                administrationWorker1, administrationWorker2, administrationWorker3, administrationDeputy, mainAdminstrator,
                developmentWorker1, developmentWorker2, developmentWorker3, developmentWorker4, developmentDeputy, mainDeveloper,
                itDeputy, itChief, accountant, automaticDirector, financeDirector, mainDirector
            };
            #endregion

            List<Task> tasks = new List<Task>() { new Task("мыть полы"), new Task("мыть посуду"), new Task("делать Тумакова") };

            IWorker whoGivesTask = flag;
            IWorker whoTakesTask = flag;
            int taskIndex = 1000;

            bool flag1 = true;
            bool flag2 = true;
            bool flag3 = true;
            while (flag1 && flag2 && flag3)
            {
                Console.WriteLine($"Кто даст задание, кто будет выполнят задание, какой номер задания(< {tasks.Count-1})    (все ответы пишите через запятую и пробел)");
                string[] information = Console.ReadLine().Split(", ");
                foreach (IWorker human in allWorkers)
                {
                    if (human.Name.ToLower() == information[0].ToLower())
                    {
                        whoGivesTask = human;
                        flag1 = false;
                    }
                }
                if (whoGivesTask == flag)
                {
                    Console.WriteLine($"Человека под именем {information[0]} нет в нашей компании");

                }

                foreach (IWorker human in allWorkers)
                {
                    if (human.Name.ToLower() == information[1].ToLower())
                    {
                        whoTakesTask = human;
                        flag2 = false;
                    }
                }
                if (whoTakesTask == flag)
                {
                    Console.WriteLine($"Человека под именем {information[1]} нет в нашей компании");
                }

                bool a = int.TryParse(information[2], out taskIndex);
                flag3 = false;
                if (a == false || taskIndex > tasks.Count-1)
                {
                    Console.WriteLine($"{information[2]} не является целым числом или больше количества заданий");
                    flag3 = true; 
                }
                if (flag1 != flag2 || flag1!= flag3 || flag2 != flag3)
                {
                    Console.WriteLine("Неправильно введена информация, попробуйте еще раз");
                    flag1 = true;
                    flag2 = true;
                    flag3 = true;
                Console.ReadKey();
                Console.Clear();   
                }
            }

            whoGivesTask.GiveATask(whoTakesTask, tasks[taskIndex], allWorkers);
            Console.ReadKey();
            Console.Clear();
        }
    }
}