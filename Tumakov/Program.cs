using System;
using System.Collections.Generic;
using System.IO;

namespace Tumakov
{
    class Program
    {
        static void Reverse(string str)
        {
            for (int i = str.Length-1; i > -1; i--)
            {
                Console.Write(str[i]);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 8.1");
            List<BankAccount> banks = new List<BankAccount>();
            banks.Add(new BankAccount(1000));
            banks.Add(new BankAccount(2000));
            foreach (var bank in banks)
            {
                Console.WriteLine(bank.Display());
            }
            banks[0].AmountOfMoney += banks[0].TransferMoney(banks[1], 1000);
            foreach (var bank in banks)
            {
                Console.WriteLine(bank.Display());
            }
            Console.ReadKey();
            Console.Clear();



            Console.WriteLine("Упражнение 8.2");
            Reverse("Я марат");
            Console.ReadKey();
            Console.Clear();


            Console.WriteLine("Упражнение 8.3");
            Console.WriteLine("Напиши имя файла.");
            //C:\Users\Пользователь\Desktop\a.txt
            string a = Console.ReadLine();
            if (File.Exists(a))
            {
                StreamReader file = new StreamReader(a);

                StreamWriter newFile = new StreamWriter(@"C:\Users\Пользователь\Desktop\b.txt");
                string str;
                while ((str = file.ReadLine()) != null)
                {
                    newFile.Write(str.ToUpper());
                }
            }
            else
            {
                Console.WriteLine("Такой файл не существует");
            }
            Console.ReadKey();
            Console.Clear();







        }
    }
}
