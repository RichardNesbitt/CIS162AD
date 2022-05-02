//
// Richard Nesbitt May 1, 2022
// CIS126DL - Spring 2022
// Class 18907
//

using System;
using System.Linq;

namespace MyATMMachine
{
    public class Account
    {
        Transaction acctTransactions = new Transaction();
        double balance;
        string name;
        public string username;
        public string pin;
        string address;
        string state;
        string zip;

        public Account(double acctBalance, string acctName, string acctUsername,
            string acctPin, string acctAddress, string acctState, string acctZip)
        {
            balance = acctBalance;
            name = acctName;
            username = acctUsername;
            pin = acctPin;
            address = acctAddress;
            state = acctState;
            zip = acctZip;
        }

        public void ClearHistory()
        {
            acctTransactions.ClearTransactions();
        }

        public string GetAccountAddress()
        {
            return address;
        }


        public double GetAccountBalance()
        {
            return balance;
        }

        public string GetAccountName()
        {
            return name;
        }

        public string GetAccountPin()
        {
            return pin;
        }

        public string ProcessDeposit(double amt)
        {
            balance += amt;
            return $"Deposit successful. Your new balance is {balance}";
        }

        public int ProcessWithdrawal(double amt)
        {
            if ( amt < balance )
            {
                if ( amt < 0 ) //MyATMMachine.Menu.)
                {
                    balance -= amt;

                    //success message
                    return 0;
                }
                else
                {
                    // error code for insufficience ATM funds
                    return 1;
                }
            }
            else
            {
                // error code for insufficient account balance
                return 2;
            }
        }

        public void ProcessTransaction()
        {

        }

        public void SetAccountAddress()
        {

        }

        public void SetAccountBalance()
        {

        }

        public void SetAccountCount()
        {

        }

        public void SetAccountName()
        {

        }

        public void SetAccountPin(string value)
        {
            if( ValidatePin(value))
            {
                pin = value;
            }
        }

        public void SetAccountState()
        {

        }
        public void SetAccountUserName()
        {

        }
        public void SetAccountZip(string input)
        {

        }
        public void ShowTransactions()
        {

        }
        public void UpdCustAddress(string input)
        {

        }
        private void UpdCustBalance(double change)
        {
            balance += change;
        }
        private void UpdCustCount()
        {

        }
        public void UpdCustName(string input)
        {

        }
        public void UpdCustPin(string input)
        {
            
        }
        public void UpdCustState(string input)
        {

        }
        public void UpdCustUserName(string input)
        {
            if( ValidateName(input) )
            {
                name = input;
            }
        }
        public void UpdCustZip()
        {

        }
        public void UpdateCustomerInfo()
        {

        }
        private bool ValidateAmount(string input)
        {
            try
            {
                Double.Parse(input);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool ValidateHouseNumber(string input)
        {
            if( input.All(char.IsNumber) )
            {
                return true;
            }
            else 
            {
                Console.WriteLine("The house number may only contain digits");
                return false;
            }
        }

        public bool ValidateName(string input)
        {
            if( input.All(char.IsLetter))
            {
                return true;
            }
            else
            {
                Console.WriteLine("The value entered must consist of only letters.");
                return false;
            }
        }
        public bool ValidatePin(string value)
        {
            bool setNewPin = true;
            if (value.Length == 4)
            {
                // check whether each char is a digit
                foreach (char c in value)
                {
                    if (c < '0' || c > '9')
                    {
                        setNewPin = false;
                    }
                }
                if (setNewPin)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Your new PIN may only contain digits 0-9. Please try again.");
                    return false;
                }
            }
            else // if PIN is <> 4 digits long
            {
                Console.WriteLine("Your new PIN must be exactly 4 digits long. Please try again.");
                return false;
            }
        }

        public bool ValidateState()
        {
            return true;
        }

        public bool ValidateStreetAvenue()
        {
            return true;
        }

        public bool ValidateStreetDirection()
        {
            return true;
        }

        public bool ValidateUserName()
        {
            return true;
        }

        public bool ValidateZip()
        {
            return true;
        }
    }
}
