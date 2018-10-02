using System;
using System.Collections.Generic;
using System.Text;

namespace Banking2C1.Models.Domain
{
    public class Transaction
    {
        //prop typen + 2x tab duwen om snel een property aan te maken
        //enkel get in de properties dus onveranderlijk object
        public DateTime DateOfTransaction { get; }
        public TransactionType TransactionType { get; }
        public decimal Amount { get; }

        public bool IsWithdraw { get { return TransactionType == TransactionType.Withdraw; } }

        public bool IsDeposit { get { return TransactionType == TransactionType.Deposit; } }

        //ctor typen + 2x tab duwen om snel een constructor aan te maken
        public Transaction(decimal amount, TransactionType transactionType)
        {
            Amount = amount;
            TransactionType = transactionType;
            DateOfTransaction = DateTime.Today;
        }
    }
}
