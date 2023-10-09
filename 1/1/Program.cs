using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Чтение входных данных из файла
        string inputFilePath = "INPUT.TXT";
        string outputFilePath = "OUTPUT.TXT";

        using (StreamReader reader = new StreamReader(inputFilePath))
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                int N = int.Parse(line);
                int numberOfSalads = (int)Math.Pow(2, N) - N-1;
                writer.WriteLine(numberOfSalads);
            }
        }
    }
}
