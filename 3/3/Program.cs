using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        // Чтение входных данных из файла
        string[] inputLines = File.ReadAllLines("INPUT.TXT");
        int N = int.Parse(inputLines[0]);
        int[,] adjacencyMatrix = new int[N, N];
        for (int i = 0; i < N; i++)
        {
            string[] row = inputLines[i + 1].Split(' ');
            for (int j = 0; j < N; j++)
            {
                adjacencyMatrix[i, j] = int.Parse(row[j]);
            }
        }
        string[] vertices = inputLines[N + 1].Split(' ');
        int start = int.Parse(vertices[0]) - 1;
        int end = int.Parse(vertices[1]) - 1;

        // Вызов функции для нахождения длины кратчайшего пути
        int shortestPathLength = FindShortestPath(adjacencyMatrix, start, end);

        // Запись результата в выходной файл
        File.WriteAllText("OUTPUT.TXT", shortestPathLength.ToString());
    }

    static int FindShortestPath(int[,] graph, int start, int end)
    {
        int N = graph.GetLength(0);
        bool[] visited = new bool[N];
        int[] distances = new int[N];
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(start);
        visited[start] = true;
        distances[start] = 0;

        while (queue.Count > 0)
        {
            int currentVertex = queue.Dequeue();

            for (int i = 0; i < N; i++)
            {
                if (graph[currentVertex, i] == 1 && !visited[i])
                {
                    queue.Enqueue(i);
                    visited[i] = true;
                    distances[i] = distances[currentVertex] + 1;

                    if (i == end)
                    {
                        return distances[i];
                    }
                }
            }
        }

        // Путь не существует
        return -1;
    }
}
