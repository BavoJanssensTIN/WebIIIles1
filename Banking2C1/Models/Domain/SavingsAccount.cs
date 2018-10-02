using System;
using System.Collections.Generic;
using System.Text;

namespace Banking2C1.Models.Domain
{
    //deze klasse erft van BankAccount
    public class SavingsAccount : BankAccount
    {
        private const decimal WithdrawCost = 0.10M;

        public decimal InterestRate { get; private set; }

        //:base voor aanroep van de constructor van de baseklasse
        public SavingsAccount(string accountNumber, decimal interestRate) : base(accountNumber)
        {
            InterestRate = interestRate;
        }

        //base hier cfr. super() van in Java
        public override void Withdraw(decimal amount)
        {
            base.Withdraw(amount + WithdrawCost);
        }
    }
}
