using IndianCensusAnalyser;
using IndianCensusAnalyser.Exceptions;
using IndianCensusAnalyser.Model;
using Nancy.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace CensusAnalyserTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        private static readonly string India_Census_FilePath = @"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateCensusData.csv";
        private static readonly string Wrong_India_Census_FilePath = @"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\IndiaStateCensusData.csv";
        private static readonly string Wrong_India_Census_Type_FilePath = @"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateData.txt";
        private static readonly string Wrong_India_Census_Delimeter = @"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateCensusWrongDelimeter.csv";
        private static readonly string Wrong_India_Census_Header = @"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateCensusData.csv";

        private static readonly string States_Code_File_Path = @"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateCode.csv";
        private static readonly string Wrong_States_Code_File_Path = @"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\IndiaStateCode.csv";
        private static readonly string Wrong_States_Code_Delimeter = @"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateCodeWrongDelimeter.csv";


        /// <summary>
        /// count no of record in india census csv
        /// </summary>        
        [Test]
        public void GivenCensusCSVFile_ShouldReturn_CorrectNumberOfRecords()
        {
            int indiaCensusCSVDataCount = CensusAnalyserManager.LoadIndiaCensusStatesData(India_Census_FilePath);
            Assert.AreEqual(29, indiaCensusCSVDataCount);
        }

        [Test]
        public void Wrong_FilePath_ReturnException()
        {
            try
            {
                CensusAnalyserManager.LoadIndiaCensusStatesData(Wrong_India_Census_FilePath);
            }
            catch (CSABuilderException e)
            {
                Assert.AreEqual(CSABuilderException.ExceptionType.No_SuchFile_Exception, e.EType);
            }
        }
        
        [Test]
        public void Wrong_FileType_ShouldReturnException()
        {
            try
            {
                CensusAnalyserManager.LoadIndiaCensusStatesData(Wrong_India_Census_Type_FilePath);
            }
            catch (CSABuilderException e)
            {
                Assert.AreEqual(CSABuilderException.ExceptionType.No_SuchFile_Exception, e.EType);
            }
        }

        [Test]
        public void Wrong_Delimeter_ShouldReturnException()
        {
            try
            {
                CensusAnalyserManager.LoadIndiaCensusStatesData(Wrong_India_Census_Delimeter);
            }
            catch (CSABuilderException e)
            {
                Assert.AreEqual(CSABuilderException.ExceptionType.File_Delimeter_Incorrect, e.EType);
            }
        }

        [Test]
        public void Wrong_Header_ShouldReturnException()
        {
            try
            {
                CensusAnalyserManager.LoadIndiaCensusStatesData(Wrong_India_Census_Header);
            }
            catch(CSABuilderException e)
            {
                Assert.AreEqual(CSABuilderException.ExceptionType.Header_Incorrrect, e.EType);
            }
        }

        [Test]
        public void Check_Matched_Records_Of_States_Codes()
        {
            int records=CensusAnalyserManager.LoadIndiaStateSCodeData(States_Code_File_Path);
            Assert.AreEqual(37, records);
        }

        [Test]
        public void Wrong_FilePath_Of_StatesCode_Should_Return_Exception()
        {
            try
            {
                CensusAnalyserManager.LoadIndiaStateSCodeData(Wrong_States_Code_File_Path);
            }
            catch (CSABuilderException e)
            {
                Assert.AreEqual(CSABuilderException.ExceptionType.No_SuchFile_Exception, e.EType);
            }
        }

        [Test]
        public void Wrong_FileType_StatesData_ShouldReturnException()
        {
            try
            {
                CensusAnalyserManager.LoadIndiaStateSCodeData(Wrong_India_Census_Type_FilePath);
            }
            catch(CSABuilderException e)
            {
                Assert.AreEqual(CSABuilderException.ExceptionType.Type_Incorrect, e.EType);
            }
        }

        [Test]
        public void Wrong_Delimeter_Of_StateCode_ShouldReturnException()
        {
            try
            {
                CensusAnalyserManager.LoadIndiaStateSCodeData(Wrong_States_Code_Delimeter);
            }
            catch (CSABuilderException e)
            {
                Assert.AreEqual(CSABuilderException.ExceptionType.File_Delimeter_Incorrect, e.EType);
            }
        }

        [Test]
        public void Wrong_Header_Of_StateCode_ShouldReturnException()
        {
            try
            {
                CensusAnalyserManager.LoadIndiaStateSCodeData(States_Code_File_Path);
            }
            catch(CSABuilderException e)
            {
                Assert.AreEqual(CSABuilderException.ExceptionType.Header_Incorrrect, e.EType);
            }
        }

        [Test]
        public void Check_Start_State_Of_SortedState_ShouldMacthing()
        {
            string stateCensusJsonData= CensusAnalyserManager.SortStatesByAlphabeticalOrder(India_Census_FilePath);
            List<StateCensusData> sortedList = new JavaScriptSerializer().Deserialize<List<StateCensusData>>(stateCensusJsonData);
            Assert.AreEqual("Andhra Pradesh", sortedList[0].State);
        }

       [Test]
       public void Check_End_State_Of_SortedState_ShouldMatching()
        {
            string stateCensusJsonData = CensusAnalyserManager.SortStatesByAlphabeticalOrder(India_Census_FilePath);
            List<StateCensusData> sortedList = new JavaScriptSerializer().Deserialize<List<StateCensusData>>(stateCensusJsonData);
            Assert.AreEqual("West Bengal", sortedList[28].State);
        }

        [Test]
        public void Check_Start_StateCode_Of_SortedStateCodes_ShouldMatch()
        {
            string stateCodesJsonData = CensusAnalyserManager.SortedStateCodesByAlphabeticalOrder(States_Code_File_Path);
            List<StatesCodeData> sortedList = new JavaScriptSerializer().Deserialize<List<StatesCodeData>>(stateCodesJsonData);
            Assert.AreEqual("AD", sortedList[0].StateCode);
        }

        [Test]
        public void Check_Last_StateCode_Of_SortedStateCode_ShouldMatch()
        {
            string stateCodesJsonData = CensusAnalyserManager.SortedStateCodesByAlphabeticalOrder(States_Code_File_Path);
            List<StatesCodeData> sortedList = new JavaScriptSerializer().Deserialize<List<StatesCodeData>>(stateCodesJsonData);
            Assert.AreEqual("PY", sortedList[28].StateCode);
        }
    }
}