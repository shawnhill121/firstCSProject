using System;
using System.Collections.Generic;

namespace classes
{ 
    public class BankAccount
    {
	    public string Number { get; }

        public string Owner { get; set; }

        public decimal Balance {

            get {

                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }

        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of depoist must be positive.");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawl(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawl must be positive.");

            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("You do not have sufficent funds for this withdrawl.");
            }

            var withdrawl = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawl);
        }

        private static int accountNumberSeed = 1234567890;

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            this.Balance = initialBalance;
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        private List<Transaction> allTransactions = new List<Transaction>();

    }
}