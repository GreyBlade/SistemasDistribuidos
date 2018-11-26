using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using DivisaSolution.DataAccess;
using Entities;
namespace DivisaSolution.Service
{
    public class DivisaService : IDivisaService
    {

        public Container _container = new Container(c => { c.AddRegistry<DivisaSolution.DataAccess.Bootstrap>(); });
        public string DivisaExist(string divisa)
        {
            var divisas = _container.GetInstance<XmlFileRepository>().GetAllCurrencies();
            string answer = "";
            foreach (Currency value in divisas)
            {
                if (value.To.Equals(divisa))
                {
                    answer = (value.Rate);
                    break;
                }
                else
                {
                    answer = "-1";
                }
            }
            return answer;
        }
    }
}
