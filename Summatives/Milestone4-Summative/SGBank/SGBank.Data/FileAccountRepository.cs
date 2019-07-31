using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        string filePath = @"\\Mac\Home\Desktop\Software_Guild\joshua-wakefield-individual-work\04-Milestone\SGBank\SGBank.Data\Accounts.txt";
        List<Account> accounts = new List<Account>();

        public List<Account> getList(List<Account> accounts)
        {
            string[] rows = File.ReadAllLines(filePath);

                using (StreamReader reader = new StreamReader(filePath))
                {
                    reader.ReadLine();
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        Account account = new Account();
                        string[] columns = line.Split(',');

                        account.AccountNumber = columns[0];
                        account.Name = columns[1];
                        account.Balance += Decimal.Parse(columns[2]);
                        switch (columns[3])
                        {
                            case "F":
                                account.Type = AccountType.Free;
                                break;
                            case "B":
                                account.Type = AccountType.Basic;
                                break;
                            case "P":
                                account.Type = AccountType.Premium;
                                break;
                        }
                        accounts.Add(account);
                    }
                }
                return accounts;
        }

        public Account LoadAccount(string AccountNumber)
        {            
            Account account = new Account();
            getList(accounts);

                foreach(var acc in accounts)
                {
                    if (acc.AccountNumber == AccountNumber)
                    {
                        account = acc;
                        break;
                    }
                }

            if(account.AccountNumber != AccountNumber)
            {
                account = null;
            }
            return account;
        }

        public void SaveAccount(Account account)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("AccountNumber,Name,Balance,Type");

                accounts.Add(account);

                string type = ""; 

                foreach (var acc in accounts)
                    {
                    switch (acc.Type)
                    {
                        case AccountType.Free:
                            type = "F";
                            break;
                        case AccountType.Basic:
                            type = "B";
                            break;
                        case AccountType.Premium:
                            type = "P";
                            break;
                    }
                    writer.WriteLine("{0},{1},{2},{3}", acc.AccountNumber, acc.Name, acc.Balance, type);
                    }              
            }
        }
   
    }
}
