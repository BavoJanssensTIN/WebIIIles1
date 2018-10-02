using System;
using System.Collections.Generic;
using System.Text;

namespace Banking2C1.Models.Domain
{
    //als geen visibiliteit gedeclareerd -> default: internal (enkel zichtbaar binnen assembly .dll)
    public class BankAccount
    {
        #region Fields
        //public const decimal WithdrawCost = 0.10M;
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
        public BankAccount(string accountNumber) : this(accountNumber, 0)
        {
            
        }

        public BankAccount(string accountNumber, decimal balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            _transactions = new List<Transaction>();
        }
        #endregion

        #region Methods
        public void Deposit(decimal amount)
        {
            Balance += amount;
            _transactions.Add(new Transaction(amount, TransactionType.Deposit));
        }

        //virtual zorgt ervoor dat deze methode overschreven kan worden in subklassen
        public virtual void Withdraw(decimal amount)
        {
            Balance -= amount;
            _transactions.Add(new Transaction(amount, TransactionType.Withdraw));
        }

        public override string ToString()
        {
            return $"Account number: {AccountNumber} --- Balance: {Balance}";
        }

        public override bool Equals(object obj)
        {
            //casting als het niet lukt geeft het null, geen exception
            BankAccount ba = obj as BankAccount;
            if (ba == null) return false;
            return ba.AccountNumber == this.AccountNumber;
        }

        //GetHashCode() steeds overriden als je Equals override
        public override int GetHashCode()
        {
            //gewoon doorspelen naar AccountNumber
            return AccountNumber.GetHashCode();
        }
        #endregion


    }
}
