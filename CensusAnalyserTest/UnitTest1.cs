using IndianCensusAnalyser;
using IndianCensusAnalyser.Exceptions;
using NUnit.Framework;

namespace CensusAnalyserTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        private static readonly string India_Census_FilePath = @"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateCensusData.csv";
        private static readonly string Wrong_India_Census_FilePath = @"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\CSVFiles\IndiaStateCensusData.csv";
        private static readonly string Wrong_India_Census_Type_FilePath = @"C:\Users\Sanbhy\source\repos\IndianCensusAnalyser\IndianCensusAnalyser\IndiaStateData.txt";

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
            catch (CSABuilderException)
            {
                Assert.AreEqual(CSABuilderException.ExceptionType.No_SuchFile_Exception, "No such file exception");
            }
        }
        
        [Test]
        public void Wrong_FileType_ReturnException()
        {
            try
            {
                CensusAnalyserManager.LoadIndiaCensusData(Wrong_India_Census_Type_FilePath);
            }
            catch (CSABuilderException e)
            {
                Assert.AreEqual(CSABuilderException.ExceptionType.No_SuchFile_Exception, e.Message);
            }
        }
    }
}