using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea1ParalelaBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            var cuenta1 = new EntidadesBancarias.BankAccount();
            var acctManager = new Publishers.accountManager();
            var EmailBankRuptService = new Subscribers.EmailBankRuptService();
            var DBBankRuptService = new Subscribers.DBBankRuptService();


            acctManager.OnBankRupt += EmailBankRuptService.SendEmailHandler;
            acctManager.OnBankRupt += DBBankRuptService.DBMessage;
            List<int> listaDeAcciones = new List<int> { 2, 20, -10,-1000,1000,200,-1000 };

            foreach (var item in listaDeAcciones)
            {
                int leftOver;
                if (item > 0)
                {
                    acctManager.Add(cuenta1, item);
                }
                if (item < 0)
                {
                    leftOver = acctManager.Substract(cuenta1, item);
                }

            }
            
        } 
    }
}
