//-----------------------------------------------------------------------
// <copyright file="CensusAnalyserManager.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
// <creater name="Sandhya Patil"/>
//-----------------------------------------------------------------------
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
        public static readonly ICSABuilder builder = CSVBuilderFactory.CreateCSVBuilder();
        /// <summary>
        /// Method to load number of states 
        /// </summary>
        /// <param name="indianCensusCSVFilePath">indianCensusCSVFilePath parameter</param>
        /// <returns>return  number of states</returns>
        public static Dictionary<string, StateCensusDAO> LoadIndiaCensusStatesData(string indianCensusCSVFilePath)
        {
            List<StateCensusDAO> censusData = builder.LoadCensusStateData(indianCensusCSVFilePath);
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
            List<StateCodesDAO> statesCodesData = builder.LoadStateCodesData(indianStateCensusCSVFilePath);
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
            List<StateCensusDAO> statesCensusData = builder.LoadCensusStateData(indianCensusStatesFilePath);
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
            List<StateCodesDAO> stateCodes = builder.LoadStateCodesData(indianStateCodesFilePath);
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
            List<StateCensusDAO> stateCensusData = builder.LoadCensusStateData(indianStateFilePath);
            List<StateCensusDAO> sortedDensityPerSqKm = stateCensusData.OrderBy(x => x.AreaInSqKm).ToList();
            string stateDensityPerSqKmJsonInFormat = JsonConvert.SerializeObject(sortedDensityPerSqKm);
            return stateDensityPerSqKmJsonInFormat;
        }

        /// <summary>
        /// Method to load us state census data
        /// </summary>
        /// <param name="usCensusCSVFilePath"></param>
        /// <returns></returns>
        public static Dictionary<string, USCensusDAO> LoadUSCensusStatesData(string usCensusCSVFilePath)
        {
            List<USCensusDAO> censusData = builder.LoadUSStateCensusData(usCensusCSVFilePath);
            Dictionary<string, USCensusDAO> dictionaryIndianCensus = censusData.ToDictionary(m => m.State);
            return dictionaryIndianCensus;
        }

        /// <summary>
        /// Method to sort us state by population
        /// </summary>
        /// <param name="usCensusCSVFilePath"></param>
        /// <returns></returns>
        public static string SortedUSStatePopulationWise(string usCensusCSVFilePath)
        {
            List<USCensusDAO> usStateDAO = builder.LoadUSStateCensusData(usCensusCSVFilePath);
            List<USCensusDAO> sortedPopulation = usStateDAO.OrderBy(x => x.Population).ToList();
            string statePolpulationJsonInFormat = JsonConvert.SerializeObject(sortedPopulation);
            return statePolpulationJsonInFormat;
        }

        /// <summary>
        /// Method to sort the state data by housing density
        /// </summary>
        /// <param name="usCensusCSVFilePath">usCensusCSVFilePath parameter</param>
        /// <returns>return the sorted state data</returns>
        public static string SortedUSStateByHousingDensityWise(string usCensusCSVFilePath)
        {
            List<USCensusDAO> usStateDAO = builder.LoadUSStateCensusData(usCensusCSVFilePath);
            List<USCensusDAO> sortedPopulation = usStateDAO.OrderBy(x => x.HousingDensity).ToList();
            string statePolpulationJsonInFormat = JsonConvert.SerializeObject(sortedPopulation);
            return statePolpulationJsonInFormat;
        }

        /// <summary>
        /// Method to sort the state data by total area
        /// </summary>
        /// <param name="usCensusCSVFilePath">usCensusCSVFilePath parameter</param>
        /// <returns>return the sorted state dat</returns>
        public static string SortedUSStateByTotalAreaWise(string usCensusCSVFilePath)
        {
            List<USCensusDAO> usStateDAO = builder.LoadUSStateCensusData(usCensusCSVFilePath);
            List<USCensusDAO> sortedTotalArae = usStateDAO.OrderBy(x => x.TotalArea).ToList();
            string stateAreaJsonInFormat = JsonConvert.SerializeObject(sortedTotalArae);
            return stateAreaJsonInFormat;
        }

        public static string SortedUSStateByPpulationDensityWise(string usCensusCSVFilePath)
        {
            List<USCensusDAO> usStateDAO = builder.LoadUSStateCensusData(usCensusCSVFilePath);
            List<USCensusDAO> sortedPopulationdensity = usStateDAO.OrderBy(x => x.PopulationDensity).ToList();
            string statePopulationDensityJsonInFormat = JsonConvert.SerializeObject(sortedPopulationdensity);
            return statePopulationDensityJsonInFormat;
        }
    }
}

