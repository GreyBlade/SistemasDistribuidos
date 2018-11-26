using DataAccess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepositoryTests
{
    public class DataRepositoryTest
    {
        [Test]
        public void DataRepository_GetDataTest()
        {
            FileDataRepository testReader = new FileDataRepository();
            IList<string> testList = new List<string>();
            testList = testReader.GetData("C:\\Users\\Jaime\\Desktop\\personas.txt");
            Assert.IsTrue(testList.Count > 0);
        }

        [Test]
        public void DataRepository_WriteDataTest()
        {
            FileDataRepository testWritter = new FileDataRepository();
            IList<string> test = new List<String> { "test1", "test2" };
            testWritter.WriteData("C:\\Users\\Jaime\\Desktop\\testWritter.txt", test);
            // Assert.IsTrue(testWritter.GetData("C:\\Users\\Jaime\\Desktop\\testWritter.txt").Count > 0);
            Assert.AreEqual(testWritter.GetData("C:\\Users\\Jaime\\Desktop\\testWritter.txt").Contains("test2"),true);
        }
    }
}
