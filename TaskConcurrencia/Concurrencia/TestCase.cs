using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrencia
{
    class TestCase
    {
        [Test]
        public void Sum()
        {
            var test = new DataParallelism();

            test.proccess();

        }
    }
}
