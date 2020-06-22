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
        public static int LoadIndiaCensusStatesData(string indianCensusCSVFilePath)
        {
            ICSABuilder csvBuilder = CSVBuilderFactory.CreateCSVBuilder();
            List<StateCensusData> censusData = csvBuilder.LoadCensusStateData(indianCensusCSVFilePath);
            Dictionary<string, StateCensusData> dictionaryIndianCensus = censusData.ToDictionary(m => m.State);
            return dictionaryIndianCensus.Count;
        }

        public static int LoadIndiaStateSCodeData(string indianStateCensusCSVFilePath)
        {
            ICSABuilder csvBuilder = CSVBuilderFactory.CreateCSVBuilder();
            List<StatesCodeData> statesCodesData = csvBuilder.LoadStateCSVData(indianStateCensusCSVFilePath);
            Dictionary<string, StatesCodeData> dicionarytStateCensus = statesCodesData.ToDictionary(x => x.StateCode);
            return dicionarytStateCensus.Count;
        }
    }
}
