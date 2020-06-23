using IndianCensusAnalyser.Model;
using System;
using System.Collections.Generic;

namespace IndianCensusAnalyser
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To The Indian State Census Analyser");
             Dictionary<string, StateCensusData>  allStatesData= CensusAnalyserManager.LoadIndiaCensusStatesData(@"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateCensusData.csv");
             foreach (KeyValuePair<string, StateCensusData> data in allStatesData)
            {
                Console.WriteLine($"=======>{data.Key}, {data.Value}");
            }
            //  CensusAnalyserManager.LoadIndiaStateCode(@"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateCode.csv");
            //CensusAnalyserManager.SortStatesByAlphabeticalOrder(@"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateCensusData.csv");
            CensusAnalyserManager.SortedStatePopulation(@"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateCensusData.csv");
        }
    }
}
