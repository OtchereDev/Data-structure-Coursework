namespace DAS_Coursework;

using BenchmarkDotNet.Running;
using controller;
using DAS_Coursework.utils;

class Program
{
    static void Main(string[] args)
    {

        var summary = BenchmarkRunner.Run<DijkstraBenchmark>(new CustomConfig());
    }

}

