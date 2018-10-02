using System;
using System.Collections.Generic;
using System.Text;

namespace Banking2C1.Models.Domain
{
    //als geen visibiliteit gedeclareerd -> default: internal (enkel zichtbaar binnen assembly .dll)
    public class BankAccount
    {
        #region Fields
        public const decimal WithdrawCost = 0.10M;
        private decimal _balance;
        //IList is iterable, kan overlopen worden met forEach
        //INumberable zou niet voldoende zijn, daar kan ik niets aan toevoegen
        private IList<Transaction> _transactions;
        #endregion

        #region Properties
        public string AccountNumber { get; set; }

        public decimal Balance
        {
            get { return _balance; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid value for balance");
                }
                _balance = value;
            }
        }

        public IEnumerable<Transaction> Transactions {
            get {
                return _transactions;
            }
        }

        public int NrOfTransactions {
            get {
                return _transactions.Count;
            }
        }
        #endregion

        #region Constructors
        public BankAccount(string accountNumber)
        {
            AccountNumber = accountNumber;
            _transactions = new List<Transaction>();
        }

        public BankAccount(string accountNumber, decimal balance) : this(accountNumber)
        {
            Balance = balance;
        }
        #endregion

        #region Methods
        public void Deposit(decimal amount)
        {
            Balance += amount;
            _transactions.Add(new Transaction(amount, TransactionType.Deposit));
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount + WithdrawCost;
            _transactions.Add(new Transaction(amount, TransactionType.Withdraw));
        } 
        #endregion


    }
}
