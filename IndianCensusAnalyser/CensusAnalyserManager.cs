using IndianCensusAnalyser.Interface;
using IndianCensusAnalyser.Model;
using IndianCensusAnalyser.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndianCensusAnalyser
{
    public class CensusAnalyserManager
    {
        public static int LoadIndiaCensusData(string indianCensusCSVFilePath)
        {
            ICSABuilder csvBuilder = CSVBuilderFactory.CreateCSVBuilder();
            List<IndiaStateCensusData> indianCensusData = csvBuilder.LoadCensusStateData(indianCensusCSVFilePath);
            Dictionary<string, IndiaStateCensusData> dictionaryIndianCensus = indianCensusData.ToDictionary(m => m.State);
            return dictionaryIndianCensus.Count;
        }

        public static int LoadIndiaStateCode(string indianStateCensusCSVFilePath)
        {
            ICSABuilder csvBuilder = CSVBuilderFactory.CreateCSVBuilder();
            List<IndiaStatesCodeData> csvDataTable = csvBuilder.LoadStateCSVData(indianStateCensusCSVFilePath);
            Dictionary<string, IndiaStatesCodeData> dicionarytStateCensus = csvDataTable.ToDictionary(x => x.StateCode);
            return dicionarytStateCensus.Count;
        }
    }
}
