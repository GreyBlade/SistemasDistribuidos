using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace DataAccess
{
    public class FileDataRepository : IDataRepository
    {
        public IList<string> GetData(string target)
        {
            List<string> data = File.ReadAllLines(target).ToList();
            return data;
   
        }

        public void WriteData(string target,IList<string> personas)
        {
            File.WriteAllLines(target, personas);
        }
    }
}
