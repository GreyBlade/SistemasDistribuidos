using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Entities;

namespace DivisaSolution.DataAccess
{
    public class XmlFileRepository : IRepository
    {
        XmlDocument doc = new XmlDocument();

        public List<Currency> GetAllCurrencies()
        {
            doc.Load("C:\\Users\\Jaime\\source\\repos\\DivisaSolution\\DivisaSolution.DataAccess\\currency.xml");
            XmlNodeList elemList = doc.GetElementsByTagName("rate");
            List<Currency> divisas = new List<Currency>();
            for (int i = 0; i < elemList.Count; i++)
            {
                Console.WriteLine(elemList[i].Attributes["from"].Value);
                divisas.Add(new Currency
                {
                    From = elemList[i].Attributes["from"].Value,
                    Rate = (elemList[i].Attributes["rate"].Value),
                    To = elemList[i].Attributes["to"].Value
                });
            }
            return divisas;
        }
    }
}
