using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publishers
{
    public class accountManager
    {
        public delegate void BankRuptTrigger();

        public event BankRuptTrigger OnBankRupt;

        public int Add(EntidadesBancarias.BankAccount cuenta, int cantidad)
        {
            if (cantidad != 0)
            {
                cuenta.Balance = cuenta.Balance + cantidad;
                
            }
            else
            {
                Console.WriteLine("Error");
            }
            return cuenta.Balance;
        }

        public int Substract(EntidadesBancarias.BankAccount cuenta, int cantidad)
        {
            if (cantidad != 0)
            {
                cuenta.Balance = cuenta.Balance - Math.Abs(cantidad);
                if (cuenta.Balance < 0)
                {
                    OnBankRupt();
                }
            }
            else
            {
                Console.WriteLine("Error");
            }

            return cuenta.Balance;
        }
    }
}
