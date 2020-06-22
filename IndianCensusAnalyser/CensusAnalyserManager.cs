using IndianCensusAnalyser.Interface;
using IndianCensusAnalyser.Model;
using IndianCensusAnalyser.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;

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
            List<StatesCodeData> statesCodesData = csvBuilder.LoadStateCodesData(indianStateCensusCSVFilePath);
            Dictionary<string, StatesCodeData> dicionarytStateCensus = statesCodesData.ToDictionary(x => x.StateCode);
            return dicionarytStateCensus.Count;
        }

        public static string SortStatesByAlphabeticalOrder(string indianCensusStatesFilePath)
        {
            ICSABuilder csvBuiledr = CSVBuilderFactory.CreateCSVBuilder();
            List<StateCensusData> statesCensusData = csvBuiledr.LoadCensusStateData(indianCensusStatesFilePath);
            List<StateCensusData> sortedStates = statesCensusData.OrderBy(x => x.State).ToList();
            string statesInJsonFormat = JsonConvert.SerializeObject(sortedStates);
            return statesInJsonFormat;
        }

        public static string SortedStateCodesByAlphabeticalOrder(string indianStateCodesFilePath)
        {
            ICSABuilder csvuilder = CSVBuilderFactory.CreateCSVBuilder();
            List<StatesCodeData> stateCodes = csvuilder.LoadStateCodesData(indianStateCodesFilePath);
            List<StatesCodeData> sortedStateCode = stateCodes.OrderBy(x => x.StateCode).ToList();
            string StateCodesInJsonFormat = JsonConvert.SerializeObject(sortedStateCode);
            return StateCodesInJsonFormat;
        }
    }
}
