using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace HillClimberString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput = Console.ReadLine();
            Random rand = new Random();
            string genString = "";
            StringBuilder sb = new StringBuilder();

            int printableMin = 32;
            int printableMax = 126;

            double minError = 0;

            for (int i = 0; i < userInput.Length; i++)
            { 

                sb.Append(((char)rand.Next(printableMin, printableMax)));
                //genString += ((char)rand.Next(printableMin, printableMax));
            }

            genString = sb.ToString();
            char[] arrString = genString.ToCharArray();

            minError = MAECalc(userInput, arrString);
            int randIndex;
            while (minError != 0)
            {
                Console.WriteLine(genString);
                randIndex = rand.Next(userInput.Length);
                int cVal = genString[randIndex];

                arrString[randIndex] = (char)Math.Clamp((cVal+(int)Math.Pow(-1,rand.Next(2))), printableMin, printableMax);


                double currError = MAECalc(userInput, arrString);

                if (currError < minError)
                {
                    minError = currError;
                    genString = new string(arrString);
                }else
                {
                    arrString = genString.ToArray();
                }

            }

            Console.WriteLine(genString);
        }

        public static double MAECalc(string s, char[] rand)
        {
            double meanAbsError = 0;
            int sLen = s.Length;
            for (int i = 0; i < sLen; i++)
            {
                meanAbsError += Math.Abs(s[i] - rand[i]);
            }

            return meanAbsError / sLen;
        }

        
    }
}
