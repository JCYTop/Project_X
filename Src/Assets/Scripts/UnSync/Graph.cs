////无向图
//
//using System;
//using System.Collections.Generic;
//
//public class Graph
//{
//    private int v; //顶点的个数
//    private List<List<int>> adj; //邻接表
//
//    public Graph(int v)
//    {
//        this.v = v;
//        adj = new List<List<int>>();
//        for (int i = 0; i < v; i++)
//        {
//            adj[i] = new List<int>();
//        }
//    }
//
//    public void AddEdge(int s, int t)
//    {
//        adj[s].Add(t);
//        adj[t].Add(s);
//    }
//
//    public void BFS(int s, int t)
//    {
//        if (s == t) return; //目标点与起始点相同
//        var queue = new List<int>();
//        queue.Add(s);
//        var prev = new int[v];
//        for (int i = 0; i < v; i++)
//        {
//            prev[i] = -1;
//        }
//
//        var visited = new bool[v];
//        while (queue.Count > 0)
//        {
//            var w = queue.Dequeue();
//            for (int i = 0; i < adj[w].Count; i++)
//            {
//                var q = adj[w][i];
//                if (!visited[q])
//                {
//                    prev[q] = w;
//                    //找到目标
//                    if (q == t)
//                    {
//                        Print(prev, s, t);
//                        return;
//                    }
//
//                    visited[q] = true;
//                    queue.Add(q);
//                }
//            }
//        }
//    }
//
//    public void Print(int[] prev, int s, int t)
//    {
//        if (prev[t] != -1 && t != s)
//        {
//            Print(prev, s, prev[t]);
//        }
//
//        Console.Write(t + " ");
//    }
//
//    bool found = false;
//
//    public void DFS()
//    {
//        found = false;
//        var visited = new bool[v];
//        var prev = new int[v];
//        for (int i = 0; i < v; i++)
//        {
//            prev[i] = -1;
//        }
//
//        RecurDFS(s, t, visited, prev);
//        Print(prev, s, t);
//    }
//
//    private void RecurDFS(int w, int t, bool[] visited, int[] prev)
//    {
//        if (found) return;
//        visited[w] = true;
//        if (w == t)
//        {
//            found = true;
//            return;
//        }
//
//        for (int i = 0; i < adj[w].Length; i++)
//        {
//            var q = adj[w][i];
//            if (!visited[q])
//            {
//                prev[q] = w;
//                RecurDFS(q, t, visited, prev); //TODO 用递归的地方都可以用堆栈
//            }
//        }
//    }
//}