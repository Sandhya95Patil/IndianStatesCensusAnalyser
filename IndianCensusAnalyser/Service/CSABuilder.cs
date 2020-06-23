using CsvHelper;
using IndianCensusAnalyser.Exceptions;
using IndianCensusAnalyser.Interface;
using IndianCensusAnalyser.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using MissingFieldException = CsvHelper.MissingFieldException;

namespace IndianCensusAnalyser.Service
{
    public class CSABuilder : ICSABuilder
    {
     
        public List<StateCensusData> LoadCensusStateData(string csvFilePath)
        {
            List<StateCensusData> numOfRecords = new List<StateCensusData>();
            try
            {
                //using csvHelper to read csv Data and convert into list
                using (var reader = new StreamReader(csvFilePath))
                ///Cultur is used to determine the default delimeter, ending, & formatting when type converting
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    numOfRecords = csv.GetRecords<StateCensusData>().ToList();
                }
                return numOfRecords;
            }
            catch (DirectoryNotFoundException e)
            {
                throw new CSABuilderException(CSABuilderException.ExceptionType.Type_Incorrect, e.Message);
            }
            catch (FileNotFoundException e)
            {
                throw new CSABuilderException(CSABuilderException.ExceptionType.No_SuchFile_Exception, e.Message);
            }
            catch (MissingFieldException e)
            {
                throw new CSABuilderException(CSABuilderException.ExceptionType.File_Delimeter_Incorrect, e.Message);
            }
            catch (HeaderValidationException e)
            {
                throw new CSABuilderException(CSABuilderException.ExceptionType.Header_Incorrrect, e.Message);
            }
        }

        public List<StatesCodeData> LoadStateCodesData(string csvStatesCodeFilePath)
        {
            List<StatesCodeData> records = new List<StatesCodeData>();
            try
            {
                //using csvHelper to read csv Data and convert into list
                using (var reader = new StreamReader(csvStatesCodeFilePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    records = csv.GetRecords<StatesCodeData>().ToList();
                }
                return records;
            }
            catch (FileNotFoundException e)
            {
                throw new CSABuilderException(CSABuilderException.ExceptionType.No_SuchFile_Exception, e.Message);
            }
            catch (MissingFieldException e)
            {
                throw new CSABuilderException(CSABuilderException.ExceptionType.File_Delimeter_Incorrect, e.Message);
            }
            catch(HeaderValidationException e)
            {
                throw new CSABuilderException(CSABuilderException.ExceptionType.Header_Incorrrect, e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<USStateCensusData> LoadUSStateCensusData(string csvUSStateFilePath)
        {
            List<USStateCensusData> records = new List<USStateCensusData>();
            try
            {
                //using csvHelper to read csv Data and convert into list
                using (var reader = new StreamReader(csvUSStateFilePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    records = csv.GetRecords<USStateCensusData>().ToList();
                }
                return records;
            }
            catch (FileNotFoundException e)
            {
                throw new CSABuilderException(CSABuilderException.ExceptionType.No_SuchFile_Exception, e.Message);
            }
            catch (MissingFieldException e)
            {
                throw new CSABuilderException(CSABuilderException.ExceptionType.File_Delimeter_Incorrect, e.Message);
            }
            catch (HeaderValidationException e)
            {
                throw new CSABuilderException(CSABuilderException.ExceptionType.Header_Incorrrect, e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}