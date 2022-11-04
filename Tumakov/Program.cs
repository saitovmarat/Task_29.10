using System;
using System.Collections.Generic;

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


            Console.WriteLine("Упражнение 8.2");
            Reverse("Я марат");




        }
    }
}
