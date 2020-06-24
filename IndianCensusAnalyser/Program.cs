
//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
// <creater name="Sandhya Patil"/>
//-----------------------------------------------------------------------
namespace IndianCensusAnalyser
{
    using IndianCensusAnalyser.Model;
    using Nancy.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To The Indian State Census Analyser");

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("*********************************");
                Console.WriteLine("1: Indian States Information");
                Console.WriteLine("2: Indian States Codes");
                Console.WriteLine("3: Us States Information");
                Console.WriteLine("4: US State Data In JSON Format Sorted Based On Population");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Dictionary<string, StateCensusDAO> allStatesData = CensusAnalyserManager.LoadIndiaCensusStatesData(@"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateCensusData.csv");
                        foreach (KeyValuePair<string, StateCensusDAO> data in allStatesData)
                        {

                            Console.WriteLine($"StateName: {data.Value.State}, Population:  {data.Value.Population}, Density: {data.Value.DensityPerSqKm}, Area: {data.Value.AreaInSqKm}");
                        }
                        Console.WriteLine("Number of states in india: " + allStatesData.Count);
                        break;
                    case 2:
                        Dictionary<string, StateCodesDAO> allStateCodes = CensusAnalyserManager.LoadIndiaStateSCodeData(@"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateCode.csv");
                        foreach (KeyValuePair<string, StateCodesDAO> data in allStateCodes)
                        {
                            Console.WriteLine($"State Name: {data.Value.StateName}, State Code: {data.Value.StateCode}");
                        }
                        break;
                    case 3:
                        Dictionary<string, USCensusDAO> allUSState = CensusAnalyserManager.LoadUSCensusStatesData(@"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\USCensusData.csv");
                        foreach (KeyValuePair<string, USCensusDAO> data in allUSState)
                        {
                            Console.WriteLine($"State Id: {data.Value.StateId}, State Name: {data.Value.State}, State Population: {data.Value.Population}, State Population Density : {data.Value.PopulationDensity}, State Total Area: {data.Value.TotalArea}, State Water Area : {data.Value.WaterArea}, State Land Area : {data.Value.LandArea}, State Housing Units : {data.Value.HousingUnits}, State Housing Density : {data.Value.HousingDensity}");
                        }
                        Console.WriteLine("Number of states in us" + allUSState);
                        break;
                    case 4:
                        string usStateDataInJsonFormat = CensusAnalyserManager.SortedUSStatePopulationWise(@"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\USCensusData.csv");
                        Console.WriteLine(usStateDataInJsonFormat);
                        break;
                    case 5:
                        CensusAnalyserManager.SortedUSStateByTotalAreaWise(@"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\USCensusData.csv");
                       // flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid, Please enter valid number");
                        break;
                }
             }
        }
    }
}
