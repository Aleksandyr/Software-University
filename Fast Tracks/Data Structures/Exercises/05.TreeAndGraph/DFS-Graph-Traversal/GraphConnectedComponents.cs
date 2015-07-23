using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    public static void Main()
    {
        graph = ReadGraph();
        FindGraphConnectedComponents();
    }

    static new List<int>[] graph = new List<int>[]
    {
        new List<int>(){3, 6}, 
        new List<int>(){3, 4, 5, 6}, 
        new List<int>(){8}, 
        new List<int>(){0, 1, 5}, 
        new List<int>(){1, 6}, 
        new List<int>(){1, 3}, 
        new List<int>(){0, 1, 4}, 
        new List<int>(){}, 
        new List<int>(){2}, 
    };

    private static bool[] visited;

    static void DFS(int node)
    {
        if (!visited[node])
        {
            visited[node] = true;
            foreach (var childNode in graph[node])
            {
                DFS(childNode);
            }
            Console.Write(" " + node);
        }
    }

    static void FindGraphConnectedComponents()
    {
        visited = new bool[graph.Length];
        for (int startNode = 0; startNode < graph.Length; startNode++)
        {
            if (!visited[startNode])
            {
                Console.Write("Connected component:");
                DFS(startNode);
                Console.WriteLine();
            }           
        }
    }

    static List<int>[] ReadGraph()
    {
        int n = int.Parse(Console.ReadLine());
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = Console.ReadLine().Split(new char[] {' '},
                StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        }

        return graph;
    }
}
