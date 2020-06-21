using System;

namespace IndianCensusAnalyser
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To The Indian State Census Analyser");
            CensusAnalyserManager.LoadIndiaCensusData(@"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateCensusData.csv");
          //  CensusAnalyserManager.LoadIndiaStateCode(@"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateCode.csv");
        }
    }
}
