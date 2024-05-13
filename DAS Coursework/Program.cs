namespace DAS_Coursework;

using BenchmarkDotNet.Running;
using controller;
using DAS_Coursework.utils;

class Program
{
    static void Main(string[] args)
    {
        //MainController.Init();

        //MainController.GetMainMain();

        var summary = BenchmarkRunner.Run<DijkstraBenchmark>(new CustomConfig());


        //string source = "WEMBLEY PARK";
        //string destination = "PADDINGTON (H&C)";

        //Dijkstra.ShortestPath(graph, graph.FindVertexByName("WEMBLEY PARK"), graph.FindVertexByName("LONDON BRIDGE"));
    }

}

