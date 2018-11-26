using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDataRepository
    {
        IList<string> GetData(string target);
        void WriteData(string target,IList<string> datos);
    }
}
