using System;
using System.Collections.Generic;
using System.Text;

namespace Tumakov
{
    enum TypeOfBankAccount
    {
        current,
        saving
    }
    class BankAccount
    {
        private static int AccountNumberCounter { get; set; } = 1;
        private int AccountNumber { get; }
        public int AmountOfMoney { get; set; }
        private TypeOfBankAccount Type { get; set; }
        public BankAccount(int amountOfMoney)
        {
            AccountNumber = AccountNumberCounter;
            AmountOfMoney = amountOfMoney;
            AcountNumberIncrement();
        }
        public string Display()
        {
            return $"{AccountNumber} {AmountOfMoney} {Type}";
        }
        private void AcountNumberIncrement()
        {
            AccountNumberCounter++;
        }
        public void TakeMoneyFromAccount()
        {
            Console.WriteLine("Сколько денег вы хотите снять?");
            int i = int.Parse(Console.ReadLine());
            if (AmountOfMoney < i)
            {
                Console.WriteLine("У вас меньше средств на счету чем столько сколько вы просите");
            }
            else
            {
                AmountOfMoney -= i;
            }
        }
        public void PutMoneyOnAccount()
        {
            Console.WriteLine("Сколько денег вы хотите положить?");
            AmountOfMoney += int.Parse(Console.ReadLine());
        }
        public int TransferMoney(BankAccount bankTakeFrom, int money)
        {
            if (bankTakeFrom.AmountOfMoney < money)
            {
                return 0;
            }
            else
            {
                bankTakeFrom.AmountOfMoney = bankTakeFrom.AmountOfMoney - money;
                return money;
            }

        }
    }
}
