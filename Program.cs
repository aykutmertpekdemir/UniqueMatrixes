using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matris
{
    class Program
    {
        public static Dictionary<int, HashSet<int>> matrixDictionary = new Dictionary<int, HashSet<int>>();
        public static Random random = new Random();
        static void Main(string[] args)
        {
            Console.Write("İşlem yapmak istediğiniz matris sayısını giriniz: ");
            int matrixnumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Matrisinizin satır sayısını giriniz: ");
            int rowCount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Matrisinizin sütün sayısını giriniz: ");
            int columnCount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Rastgele sayılar için minimum değeri giriniz: ");
            int minValue = Convert.ToInt32(Console.ReadLine());
            Console.Write("Rastgele sayılar için maksimum değeri giriniz: ");
            int maxValue = Convert.ToInt32(Console.ReadLine());
            int[][,] matrixes = new int[matrixnumber][,];

            for (int i = 1; i <= matrixnumber; i++)
            {
                matrixDictionary[i] = new HashSet<int>();               // will be stored exclude numbers
            }

            for (int i = 0; i < matrixnumber; i++)
            {
                int[,] tempMatrix = new int[rowCount, columnCount];
                for (int j = 0; j < rowCount; j++)
                {
                    for (int k = 0; k < columnCount; k++)
                    {
                        tempMatrix[j, k] = GenerateRandomNumber((i + 1), minValue, maxValue);
                    }

                }
                matrixes[i] = tempMatrix;
            }
            Console.WriteLine();

            for (int i = 0; i < matrixnumber; i++)
            {
                int[,] tempMatrix = matrixes[i];
                Console.WriteLine("{0}. Matris: \n", i + 1);
                for (int j = 0; j < rowCount; j++)
                {
                    for (int k = 0; k < columnCount; k++)
                    {
                        Console.Write(tempMatrix[j, k] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\n**********");
            }
            Console.ReadKey();
        }

        private static int GenerateRandomNumber(int matrixNumber, int minValue, int maxValue)
        {
            int returnValue;
            HashSet<int> excludeNumbers = matrixDictionary[matrixNumber];
            var range = Enumerable.Range(minValue, maxValue).Where(i => !excludeNumbers.Contains(i));

            int index = random.Next(0, (maxValue - minValue) - excludeNumbers.Count);
            returnValue = range.ElementAt(index);
            matrixDictionary[matrixNumber].Add(returnValue);                    // stored this number to exclution HasSet. It wont be generated for this matrix in next tseps.
            return returnValue;
        }

    }
}
