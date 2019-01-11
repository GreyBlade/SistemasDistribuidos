using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrencia
{
    public class DataParallelism
    {


        private List<double[,]> CreateRandomList(int n, int m, int size)

        {

            var listMatri = new List<double[,]>();

            var random = new Random();

            for (int count = 0; count < size; count++)

            {

                var array = new double[n, m];

                for (int i = 0; i < n; ++i)

                    for (int j = 0; j < m; ++j)

                        array[i, j] = random.Next();

                listMatri.Add(array);

            }

            return listMatri;

        }

        public void SumarLista(List<double[,]> arrays)
        {

            Console.WriteLine("iniciando");
            double counter = 0;
            foreach (var matrix in arrays)
            {
                counter += Sum(matrix);
            }
            Console.WriteLine("suma lineal " + counter);
            Console.ReadKey();
       
        }

        private void SumarParalelo(List<double[,]> array)
        {
            double total = 0;
            object sync = new object();
            Parallel.ForEach(array, matrix => {

                lock (sync)
                {
                    total += Sum(matrix);

                }
            });

            Console.WriteLine("total paralela" + total);
        }

        public double Sum(double[,] arr)
        {
            double count = 0;

            foreach (var item in arr)
            {
                count += item;
            }
            return count;
        }

        public void proccess()
        {
            var lista = CreateRandomList(2,2,2);



        }
    }
}
