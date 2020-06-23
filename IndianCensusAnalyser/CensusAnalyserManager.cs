namespace IndianCensusAnalyser
{
    using IndianCensusAnalyser.Interface;
    using IndianCensusAnalyser.Model;
    using LanguageExt;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Census Analyser Manager class
    /// </summary>
    public class CensusAnalyserManager
    {
        /// <summary>
        /// Method to load number of states 
        /// </summary>
        /// <param name="indianCensusCSVFilePath">indianCensusCSVFilePath parameter</param>
        /// <returns>return  number of states</returns>
        public static Dictionary<string, StateCensusDAO> LoadIndiaCensusStatesData(string indianCensusCSVFilePath)
        {
            ICSABuilder csvBuilder = CSVBuilderFactory.CreateCSVBuilder();
            List<StateCensusDAO> censusData = csvBuilder.LoadCensusStateData(indianCensusCSVFilePath);
            Dictionary<string, StateCensusDAO> dictionaryIndianCensus = censusData.ToDictionary(m => m.State);
            return dictionaryIndianCensus;
        }

        /// <summary>
        /// Method to load state codes 
        /// </summary>
        /// <param name="indianStateCensusCSVFilePath">indianStateCensusCSVFilePath parameter</param>
        /// <returns>return number of state codes</returns>
        public static Dictionary<string, StateCodesDAO> LoadIndiaStateSCodeData(string indianStateCensusCSVFilePath)
        {
            ICSABuilder csvBuilder = CSVBuilderFactory.CreateCSVBuilder();
            List<StateCodesDAO> statesCodesData = csvBuilder.LoadStateCodesData(indianStateCensusCSVFilePath);
            Dictionary<string, StateCodesDAO> dicionarytStateCensus = statesCodesData.ToDictionary(x => x.StateCode);
            return dicionarytStateCensus;
        }

        /// <summary>
        /// Method to sort the states by alphabetical order
        /// </summary>
        /// <param name="indianCensusStatesFilePath">indianCensusStatesFilePath parameter</param>
        /// <returns>return sorted states</returns>
        public static string SortStatesByAlphabeticalOrder(string indianCensusStatesFilePath)
        {
            ICSABuilder csvBuiledr = CSVBuilderFactory.CreateCSVBuilder();
            List<StateCensusDAO> statesCensusData = csvBuiledr.LoadCensusStateData(indianCensusStatesFilePath);
            List<StateCensusDAO> sortedStates = statesCensusData.OrderBy(x => x.State).ToList();
            string statesInJsonFormat = JsonConvert.SerializeObject(sortedStates);
            return statesInJsonFormat;
        }

        /// <summary>
        /// Method to sort the state codes by alphabetical order
        /// </summary>
        /// <param name="indianStateCodesFilePath">indianStateCodesFilePath parameter</param>
        /// <returns>return the state codes</returns>
        public static string SortedStateCodesByAlphabeticalOrder(string indianStateCodesFilePath)
        {
            ICSABuilder csvuilder = CSVBuilderFactory.CreateCSVBuilder();
            List<StateCodesDAO> stateCodes = csvuilder.LoadStateCodesData(indianStateCodesFilePath);
            List<StateCodesDAO> sortedStateCode = stateCodes.OrderBy(x => x.StateCode).ToList();
            string stateCodesInJsonFormat = JsonConvert.SerializeObject(sortedStateCode);
            return stateCodesInJsonFormat;
        }

        /// <summary>
        /// Method to sort the state population
        /// </summary>
        /// <param name="indianStateFilePath">indianStateFilePath parameter</param>
        /// <returns>return the state sorted by population</returns>
        public static string SortedStatePopulation(string indianStateFilePath)
        {
            ICSABuilder builder = CSVBuilderFactory.CreateCSVBuilder();
            List<StateCensusDAO> stateCensusData = builder.LoadCensusStateData(indianStateFilePath);
            List<StateCensusDAO> sortedPopulation = stateCensusData.OrderBy(x => x.Population).ToList();
            string statePopulationInJsonFormat = JsonConvert.SerializeObject(sortedPopulation);
            return statePopulationInJsonFormat;
        }

        /// <summary>
        /// Method to sort the density of state per sqkm
        /// </summary>
        /// <param name="indianStateFilePath">indianStateFilePath parameter</param>
        /// <returns>return the sorted state by density</returns>
        public static string SortedStateByDensityPerSqKm(string indianStateFilePath)
        {
            ICSABuilder builder = CSVBuilderFactory.CreateCSVBuilder();
            List<StateCensusDAO> stateCensusData = builder.LoadCensusStateData(indianStateFilePath);
            List<StateCensusDAO> sortedDensityPerSqKm = stateCensusData.OrderBy(x => x.DensityPerSqKm).ToList();
            string stateDensityPerSqKmJsonInFormat = JsonConvert.SerializeObject(sortedDensityPerSqKm);
            return stateDensityPerSqKmJsonInFormat;
        }

        /// <summary>
        /// Method to sort the area of state in sqkm
        /// </summary>
        /// <param name="indianStateFilePath">indianStateFilePath parameter</param>
        /// <returns>return the sorted state by density</returns>
        public static string SortedStateByAreaInSqKm(string indianStateFilePath)
        {
            ICSABuilder builder = CSVBuilderFactory.CreateCSVBuilder();
            List<StateCensusDAO> stateCensusData = builder.LoadCensusStateData(indianStateFilePath);
            List<StateCensusDAO> sortedDensityPerSqKm = stateCensusData.OrderBy(x => x.AreaInSqKm).ToList();
            string stateDensityPerSqKmJsonInFormat = JsonConvert.SerializeObject(sortedDensityPerSqKm);
            return stateDensityPerSqKmJsonInFormat;
        }

        public static Dictionary<string, USCensusDAO> LoadUSCensusStatesData(string usCensusCSVFilePath)
        {
            ICSABuilder csvBuilder = CSVBuilderFactory.CreateCSVBuilder();
            List<USCensusDAO> censusData = csvBuilder.LoadUSStateCensusData(usCensusCSVFilePath);
            Dictionary<string, USCensusDAO> dictionaryIndianCensus = censusData.ToDictionary(m => m.State);
            return dictionaryIndianCensus;
        }

        public static string SortedUSStatePopulationWise(string usCensusCSVFilePath)
        {
            ICSABuilder builder = CSVBuilderFactory.CreateCSVBuilder();
            List<USCensusDAO> usStateDAO = builder.LoadUSStateCensusData(usCensusCSVFilePath);
            List<USCensusDAO> sortedPopulation = usStateDAO.OrderBy(x => x.Population).ToList();
            string statePolpulationJsonInFormat = JsonConvert.SerializeObject(sortedPopulation);
            return statePolpulationJsonInFormat;
        }

        
    }
}

