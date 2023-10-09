using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string inputFilePath = "INPUT.txt";
        string outputFilePath = "output.txt";

        try
        {
            string input = File.ReadAllText(inputFilePath);
            int N = Convert.ToInt32(input.Trim());

            if (N < 3)
            {
                Console.WriteLine("Количество приборов должно быть не менее 3.");
            }
            else
            {
                int[] devices = Enumerable.Range(1, N).ToArray();
                int iterations = 1;

                while (devices.Length > 3)
                {
                    if (devices.Length % 2 == 0)
                    {
                        devices = devices.Where((x, index) => index % 2 != 0).ToArray();
                    }
                    else
                    {
                        devices = devices.Where((x, index) => index % 2 == 0).ToArray();
                    }
                    iterations++;
                }

                Console.WriteLine("Количество способов выбора приборов: " + iterations);

                // Записываем количество способов выбора в файл output.txt
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    writer.WriteLine("Количество способов выбора приборов: " + iterations);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл INPUT.txt не найден.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Некорректный формат данных в файле INPUT.txt.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }

        Console.ReadLine();
    }
}
