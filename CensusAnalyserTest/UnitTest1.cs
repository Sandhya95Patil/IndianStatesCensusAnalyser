using IndianCensusAnalyser;
using IndianCensusAnalyser.Exceptions;
using NUnit.Framework;
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


        /// <summary>
        /// count no of record in india census csv
        /// </summary>        
        [Test]
        public void GivenCensusCSVFile_ShouldReturn_CorrectNumberOfRecords()
        {
            int indiaCensusCSVDataCount = CensusAnalyserManager.LoadIndiaCensusData(India_Census_FilePath);
            Assert.AreEqual(29, indiaCensusCSVDataCount);
        }

        [Test]
        public void Wrong_FilePath_ReturnException()
        {
            try
            {
                CensusAnalyserManager.LoadIndiaCensusData(Wrong_India_Census_FilePath);
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
                CensusAnalyserManager.LoadIndiaCensusData(Wrong_India_Census_Type_FilePath);
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
                CensusAnalyserManager.LoadIndiaCensusData(Wrong_India_Census_Delimeter);
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
                CensusAnalyserManager.LoadIndiaCensusData(Wrong_India_Census_Header);
            }
            catch(CSABuilderException e)
            {
                Assert.AreEqual(CSABuilderException.ExceptionType.Header_Incorrrect, e.EType);
            }
        }

        [Test]
        public void Check_Matched_Records_Of_States_Codes()
        {
            int records=CensusAnalyserManager.LoadIndiaStateCode(States_Code_File_Path);
            Assert.AreEqual(37, records);
        }

        [Test]
        public void Wrong_FilePath_Of_StatesCode_Should_Return_Exception()
        {
            try
            {
                CensusAnalyserManager.LoadIndiaStateCode(Wrong_States_Code_File_Path);
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
                CensusAnalyserManager.LoadIndiaStateCode(Wrong_India_Census_Type_FilePath);
            }
            catch(CSABuilderException e)
            {
                Assert.AreEqual(CSABuilderException.ExceptionType.Type_Incorrect, e.EType);
            }
        }
    }
}