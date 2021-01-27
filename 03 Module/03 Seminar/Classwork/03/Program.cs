using System;

namespace _03
{
    public delegate void CurrentAccount(string s, int change, int sum);
    class Account
    {
        public event CurrentAccount OnCurrentAccount;
        public int Sum { get; private set; }
        public Account(int sum)
        {
            Sum = sum;
        }

        public void Put(int sum)
        {
            OnCurrentAccount?.Invoke("Положили", sum, Sum += sum);
        }

        public void Take(int sum)
        {
            if (Sum >= sum)
                OnCurrentAccount?.Invoke("Сняли", sum, Sum -= sum);
            else
                OnCurrentAccount?.Invoke("Пытались снять (но не смогли)", sum, Sum);
        }
    }

    class Program
    {
        static void Message(string s, int change, int sum)
        {
            Console.WriteLine($"{s} {change} деняк. Баланс: {sum}");
        }

        static void Main()
        {
            Account acc = new Account(100);
            acc.OnCurrentAccount += Message;
            acc.Put(20);
            acc.Take(70);
            acc.Take(180);
        }
    }
}
