//
// Richard Nesbitt May 1, 2022
// CIS126DL - Spring 2022
// Class 18907
//

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace MyATMMachine
{
    class Menu
    {
        static double ATMBalance = 50000;
        static string adminUser = "adm1";
        static string adminPass = "9999";

        static List<Account> accounts = new List<Account>();
        

        static void Main(string[] args)
        {
            accounts.Add(new Account(0.00, "Guest Account", "guest", "0000", "100 N Central Ave", "MT", "90000"));
            accounts.Add(new Account(50.00, "User One", "user1", "1234", "1234 E User1 St", "AZ", "85000"));
            accounts.Add(new Account(50000.00, "User Two", "user2", "4321", "4321 W User2 St", "CA", "85001"));

            showLogin();
        }

        static void showLogin()
        {
            ScreenReset("BankApplication");
            Console.WriteLine("\n\n\n");
            Console.Write("Enter Username: ");
            string UserName = Console.ReadLine();
            Console.Write("Enter Pin Number: ");
            string UserPin = RequestPIN();
            Account CurrentAccount;

            if ( (UserName == adminUser) && (UserPin == adminPass) )
            {
                DisplayAdminMenu(adminUser);
            }
            else
            {
                try
                {
                    /*
                    * I googled this part. Not 100% sure how it works
                    * but I know that it looks throug the `accounts` list to find
                    * the one with a matching username
                    * 
                    * basically: foreach a in accounts, find where a.username == UserName && a.pin == UserPin
                    */

                    CurrentAccount = accounts.FirstOrDefault(a => (a.username == UserName && a.pin == UserPin));
                    DisplayCustomerMenu(CurrentAccount);
                }
                catch
                {
                    Console.WriteLine("Invalid username/password combination. Please try again.");
                    PromptNPause();
                    showLogin();
                }
            }
        }

        static bool CheckLogin(string username, string password)
        {
            return true;
        }

        private bool checkPassword(string user, string password, bool isAdmin)
        {
            if (isAdmin && password == adminPass)
            {
                return true;
            }
            /* 
             * elseif user_object.password == password
             * {
             *     return true;
             * }
             */
            else
            {
                return false;
            }

        }

        public static void DisplayAdminMenu(string user)
        {
            ScreenReset("Bank Application");
            Console.WriteLine($"Welcome {user}!\n\n");
            Console.WriteLine("1) Return to Login");
            Console.WriteLine("2) Exit Application");

            // if I get to the extra credit
            Console.WriteLine("3) Create New Customer Account");

            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                showLogin();
            }
            else if (userInput == "2")
            {
                ScreenReset("The application will close in 5 seconds...");
                System.Threading.Thread.Sleep(1000);
                ScreenReset("The application will close in 4 seconds...");
                System.Threading.Thread.Sleep(1000);
                ScreenReset("The application will close in 3 seconds...");
                System.Threading.Thread.Sleep(1000);
                ScreenReset("The application will close in 2 seconds...");
                System.Threading.Thread.Sleep(1000);
                ScreenReset("The application will close in 1 second...");
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(0);
            }
            else if ( userInput == "3")
            {
                Console.WriteLine("This option hasn't been built yet.");
                PromptNPause();
                DisplayAdminMenu(user);
            }
            else
            {
                // if they enter anything else, redisplay the menu after a keypress.
                Console.WriteLine("Invalid input received, press any key to continue...");
                Console.ReadKey();
                DisplayAdminMenu(user);
            }
        }

        static void ScreenReset(string Header)
        {
            Console.Clear();
            Console.WriteLine(Header);
        }

        static void PromptNPause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static string RequestPIN()
        {
            StringBuilder sb = new StringBuilder();
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);

                if (!char.IsControl(keyInfo.KeyChar))
                {
                    sb.Append(keyInfo.KeyChar);
                    Console.Write("*");
                }
            } while (keyInfo.Key != ConsoleKey.Enter);
            {
                return sb.ToString();
            }
        }

        static void DisplayCustomerMenu(Account account)
        {
            ScreenReset("Bank Application");
            Console.WriteLine($"Welcome {account.username}!\n");
            Console.WriteLine("1) Get Balance");
            Console.WriteLine("2) Deposit to Account");
            Console.WriteLine("3) Withdraw from Account");
            Console.WriteLine("4) Modify Customer Information");
            Console.WriteLine("5) Display Current Transactions");
            Console.WriteLine("6) Quit\n");

            string Selection = Console.ReadLine();
            if (Selection == "1") {
                Console.WriteLine($"Your account balance is: {account.GetAccountBalance()}");
                PromptNPause();
                DisplayCustomerMenu(account);
            }
            else if (Selection == "2") {
                Console.Write("Enter the amount of your deposit: ");
                var depamt = Double.Parse(Console.ReadLine());
                var newbal = account.ProcessDeposit(depamt);
                Console.WriteLine($"Your deposit of {depamt} has been processed.");
                Console.WriteLine($"Your new balance is: {depamt}");
                PromptNPause();
                DisplayCustomerMenu(account);
            }
            else if (Selection == "3") {
                Console.WriteLine($"\nYour Balance is: ${account.GetAccountBalance()}");
                Console.WriteLine($"Bank Balance: ${ATMBalance}");
                Console.Write("Enter transaction amount > 0.00 or ENTER to return to menu: ");
                try
                {
                    double withdrawalAmt = Double.Parse(Console.ReadLine());

                    if (withdrawalAmt < ATMBalance)
                    {
                        if (withdrawalAmt < account.GetAccountBalance())
                        {
                            account.ProcessWithdrawal(withdrawalAmt);
                            account.ProcessTransaction();
                        }
                        else
                        {
                            Console.WriteLine("Your account balance is insufficient. Please try another transaction.");
                            PromptNPause();
                            DisplayCustomerMenu(account);
                        }
                    }
                    else
                    {
                        Console.WriteLine("The bank doesn't have that much money. Please try another transaction.");
                        PromptNPause();
                        DisplayCustomerMenu(account);
                    }
                }
                catch
                {
                    Console.WriteLine("You have entered an invalid amount. Please try another transaction.");
                    PromptNPause();
                    DisplayCustomerMenu(account);
                }
            }
            else if (Selection == "4") {
                Console.WriteLine("This option hasn't been built yet.");
                PromptNPause();
                DisplayCustomerMenu(account);
            }
            else if (Selection == "5") {
                Console.WriteLine("This option hasn't been built yet.");
                PromptNPause();
                DisplayCustomerMenu(account);
            }
            else if (Selection == "6") {
                showLogin();
            }
        }
    }
}
