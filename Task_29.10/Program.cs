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

            Task task1 = new Task("мыть полы");
            Task task2 = new Task("мыть полы x2");
            mainDirector.GiveATask(financeDirector, task1, allWorkers);
        }
    }
}