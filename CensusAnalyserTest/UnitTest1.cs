
namespace CensusAnalyserTest
{
    using IndianCensusAnalyser;
    using IndianCensusAnalyser.Exceptions;
    using IndianCensusAnalyser.Model;
    using Nancy.Json;
    using NUnit.Framework;
    using System.Collections.Generic;

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

        private static readonly string US_Census_FilePath = @"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\USCensusData.csv";



        /// <summary>
        /// Use case 1.1 count no of record in india census csv file 
        /// </summary>        
        [Test]
        public void GivenCensusCSVFile_ShouldReturn_CorrectNumberOfRecords()
        {
            int indiaCensusCSVDataCount = CensusAnalyserManager.LoadIndiaCensusStatesData(India_Census_FilePath);
            Assert.AreEqual(29, indiaCensusCSVDataCount);
        }

        /// <summary>
        /// Use case 1.2 Wrong file path should raised exception
        /// </summary>
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
        
        /// <summary>
        /// Use case 1.3 Wrong file type should raised exception
        /// </summary>
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

        /// <summary>
        /// Use case 1.4 Wrong delimeter should raised exception
        /// </summary>
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

        /// <summary>
        /// Use case 1.5 Wrong header should raised exception
        /// </summary>
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

        /// <summary>
        /// Use case 2.1 Cont number of state code records should match
        /// </summary>
        [Test]
        public void Check_Matched_Records_Of_States_Codes()
        {
            int records=CensusAnalyserManager.LoadIndiaStateSCodeData(States_Code_File_Path);
            Assert.AreEqual(37, records);
        }

        /// <summary>
        /// Use case 2.2 Wrong file path should raised exception
        /// </summary>
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

        /// <summary>
        /// Use case 2.3 Wrong file type should raised exception
        /// </summary>
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

        /// <summary>
        /// Use case 2.4 Wrong delimeter should raised exception
        /// </summary>
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

        /// <summary>
        /// Use case 2.5 Wrong Wrong header should raised exception
        /// </summary>
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

        /// <summary>
        /// Use case 3.1 Check start state of sorted states should match
        /// </summary>
        [Test]
        public void Check_Start_State_Of_SortedState_ShouldMacthing()
        {
            string stateCensusJsonData= CensusAnalyserManager.SortStatesByAlphabeticalOrder(India_Census_FilePath);
            List<StateCensusData> sortedList = new JavaScriptSerializer().Deserialize<List<StateCensusData>>(stateCensusJsonData);
            Assert.AreEqual("Andhra Pradesh", sortedList[0].State);
        }

        /// <summary>
        /// Use case 3.2 Check last state of sorted states should match
        /// </summary>
        [Test]
       public void Check_End_State_Of_SortedState_ShouldMatching()
        {
            string stateCensusJsonData = CensusAnalyserManager.SortStatesByAlphabeticalOrder(India_Census_FilePath);
            List<StateCensusData> sortedList = new JavaScriptSerializer().Deserialize<List<StateCensusData>>(stateCensusJsonData);
            Assert.AreEqual("West Bengal", sortedList[28].State);
        }

        /// <summary>
        /// Use case 4.1 Check last state code of sorted states should match
        /// </summary>
        [Test]
        public void Check_Start_StateCode_Of_SortedStateCodes_ShouldMatch()
        {
            string stateCodesJsonData = CensusAnalyserManager.SortedStateCodesByAlphabeticalOrder(States_Code_File_Path);
            List<StatesCodeData> sortedList = new JavaScriptSerializer().Deserialize<List<StatesCodeData>>(stateCodesJsonData);
            Assert.AreEqual("AD", sortedList[0].StateCode);
        }

        /// <summary>
        /// Use case 4.2 Check last state code of sorted states should match
        /// </summary>
        [Test]
        public void Check_Last_StateCode_Of_SortedStateCode_ShouldMatch()
        {
            string stateCodesJsonData = CensusAnalyserManager.SortedStateCodesByAlphabeticalOrder(States_Code_File_Path);
            List<StatesCodeData> sortedList = new JavaScriptSerializer().Deserialize<List<StatesCodeData>>(stateCodesJsonData);
            Assert.AreEqual("PY", sortedList[28].StateCode);
        }

        /// <summary>
        /// Use case 5 Check population wise sorted state should match
        /// </summary>
        [Test]
        public void Check_Population_Wise_Sorted_Should_Return_Result_Higher_State_By_Population()
        {
            string statePopulationJsonData = CensusAnalyserManager.SortedStatePopulation(India_Census_FilePath);
            List<StateCensusData> sortedList = new JavaScriptSerializer().Deserialize<List<StateCensusData>>(statePopulationJsonData);
            Assert.AreEqual("Uttar Pradesh", sortedList[28].State);
        }

        /// <summary>
        /// Use case 6 Check density wise sorted state should match
        /// </summary>
        [Test]
       public void Check_Density_Wise_Sorted_Should_Return_Higher_State_By_DensityPerSqKm()
        {
            string stateDensityPerSqKm = CensusAnalyserManager.SortedStateByDensityPerSqKm(India_Census_FilePath);
            List<StateCensusData> sortedList = new JavaScriptSerializer().Deserialize<List<StateCensusData>>(stateDensityPerSqKm);
            Assert.AreEqual("Bihar", sortedList[28].State);
        }

        /// <summary>
        /// Use case 7 Check area wise sorted state should match
        /// </summary>
        [Test]
        public void Check_Area_Wise_Sorted_Should_Return_Higher_State_By_AreaInSqKm()
        {
            string stateDensityPerSqKm = CensusAnalyserManager.SortedStateByDensityPerSqKm(India_Census_FilePath);
            List<StateCensusData> sortedList = new JavaScriptSerializer().Deserialize<List<StateCensusData>>(stateDensityPerSqKm);
            Assert.AreEqual("Bihar", sortedList[28].State);
        }

        [Test]
        public void GivenUSCensusCSVFile_ShouldReturn_CorrectNumberOfRecords()
        {
            int indiaCensusCSVDataCount = CensusAnalyserManager.LoadUSCensusStatesData(US_Census_FilePath);
            Assert.AreEqual(51, indiaCensusCSVDataCount);
        }
    }
}