using System;
using System.Collections;
using System.Collections.Generic;
namespace minDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            int nodes =6;
            Graph minDistance = new Graph(nodes);
            minDistance.AddEdges(0,1);
            minDistance.AddEdges(0,3);
            minDistance.AddEdges(1,2);
            minDistance.AddEdges(2,4);
            minDistance.AddEdges(3,4);
            minDistance.AddEdges(4,5);

            Console.Write(minDistance.findMinDistanceFrom(0,5));

        }
    }

    class Graph{
        private bool [] isVisted;
        private List<List<int>> edges;
        private int distance;
        private int sizeOfTheQ;
        private Queue<int> visistedNode;
    public Graph(int nodes){
        isVisted = new bool[nodes];
        edges= new List<List<int>>();
        distance=0;
        sizeOfTheQ=0;
        visistedNode= new Queue<int>();
        for (int i = 0; i < nodes; i++)
        {

            edges.Insert(i,new List<int>());

        }
    }

    public void AddEdges(int start, int end){
        edges[start].Add(end);
        edges[end].Add(start);
    }

    public int findMinDistanceFrom(int source, int destination){
        if (source == destination)
        {
          return 0;  
        }
        isVisted[source]= true;
        visistedNode.Enqueue(source);
        while(visistedNode.Count!=0){

             sizeOfTheQ= visistedNode.Count;

            while (sizeOfTheQ>0)
            {
            int firstOnTheQ = visistedNode.Dequeue();
            List<int> connectedNodes = edges[firstOnTheQ];
            foreach (var node in connectedNodes)
            {
                if (node == destination)
                {
                  return distance+=1;  
                }
                if (isVisted[node]!=true)
                {
                   isVisted[node]=true;
                   visistedNode.Enqueue(node);
                }
            }
            sizeOfTheQ--;
            }
            distance+=1;

        }
        return -1; // when graph is not connected
    }
    }
}
