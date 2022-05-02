//
// Richard Nesbitt May 1, 2022
// CIS126DL - Spring 2022
// Class 18907
//

using System;
namespace MyATMMachine
{
    public class Transaction
    {
        private int transactions = 0;
        private double[] transactionsEntered = new double[5];
        private double transactionTotal = 0;

        public Transaction()
        {
        }

        public void ClearTransactions()
        {
            transactions = 0;
            transactionsEntered = new double[5];
            transactionTotal = 0;
        }

        public Array GetTransactionsEntered()
        {
            return transactionsEntered;
        }

        private void SetTransactionsEntered()
        {
            // increment the counter
            ++this.transactions;
        }

        private void StoreTransactionTotal(double amt)
        {
            this.transactionTotal += amt;
        }

        private void StoreTransaction(double amt)
        {
            this.transactionsEntered[transactions] = amt;
        }
    }
}
