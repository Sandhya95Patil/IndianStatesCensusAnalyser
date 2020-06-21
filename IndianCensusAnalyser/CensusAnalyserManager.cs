using IndianCensusAnalyser.Interface;
using IndianCensusAnalyser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndianCensusAnalyser
{
    public class CensusAnalyserManager
    {
        /// <summary>
        /// load india state census data into map
        /// </summary>
        /// <returns>size of dictionary</returns>
        public static int LoadIndiaCensusData(string indianCensusCSVFilePath)
        {
            ICSABuilder csvBuilder = CSABuilderFactory.CreateCSVBuilder();
            List<IndiaStateCensusData> indianCensusData = csvBuilder.LoadCensusStateData(indianCensusCSVFilePath);
            Dictionary<string, IndiaStateCensusData> dictionaryIndianCensus = indianCensusData.ToDictionary(m => m.State);
            return dictionaryIndianCensus.Count;
        }
    }
}
