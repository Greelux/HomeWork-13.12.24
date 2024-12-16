using System;

public class BankAccount
{
    private decimal balance;

    public decimal Balance
    {
        get { return balance; }
        private set
        {
            if (value < 0)
                throw new InvalidOperationException("Баланс не може бути від'ємним.");
            balance = value;
        }
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сума депозиту повинна бути більше нуля.");

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сума зняття повинна бути більше нуля.");

        if (amount > Balance)
            throw new InvalidOperationException("Недостатньо коштів на рахунку.");

        Balance -= amount;
    }

    public override string ToString()
    {
        return $"Баланс: {Balance} грн";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var account = new BankAccount();

        while (true)
        {
            Console.WriteLine("Виберіть дію: 1 - Депозит, 2 - Зняття, 3 - Вихід");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введіть суму для депозиту: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                    {
                        try
                        {
                            account.Deposit(depositAmount);
                            Console.WriteLine("Депозит успішний. " + account);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Помилка: " + ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Невірне значення. Спробуйте ще раз.");
                    }
                    break;

                case "2":
                    Console.Write("Введіть суму для зняття: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                    {
                        try
                        {
                            account.Withdraw(withdrawAmount);
                            Console.WriteLine("Зняття успішне. " + account);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Помилка: " + ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Невірне значення. Спробуйте ще раз.");
                    }
                    break;

                case "3":
                    Console.WriteLine("Дякуємо, що скористались нашими послугами!");
                    return;

                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }
}