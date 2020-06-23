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
     
        public List<StateCensusDAO> LoadCensusStateData(string csvFilePath)
        {
            List<StateCensusDAO> numOfRecords = new List<StateCensusDAO>();
            try
            {
                //using csvHelper to read csv Data and convert into list
                using (var reader = new StreamReader(csvFilePath))
                    if (csvFilePath.EndsWith(".csv"))
                    {
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            numOfRecords = csv.GetRecords<StateCensusDAO>().ToList();
                        }
                    }
                    else
                    {
                        throw new CSABuilderException(CSABuilderException.ExceptionType.Type_Incorrect, "");
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

        public List<StateCodesDAO> LoadStateCodesData(string csvStatesCodeFilePath)
        {
            List<StateCodesDAO> records = new List<StateCodesDAO>();
            try
            {
                //using csvHelper to read csv Data and convert into list
                using (var reader = new StreamReader(csvStatesCodeFilePath))
                    if (csvStatesCodeFilePath.EndsWith(".csv"))
                    {
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            records = csv.GetRecords<StateCodesDAO>().ToList();
                        }
                    }
                    else
                    {
                        throw new CSABuilderException(CSABuilderException.ExceptionType.Type_Incorrect, "");
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
            catch (DirectoryNotFoundException e)
            {
                throw new CSABuilderException(CSABuilderException.ExceptionType.Type_Incorrect, e.Message);
            }
        }

        public List<USCensusDAO> LoadUSStateCensusData(string csvUSStateFilePath)
        {
            List<USCensusDAO> records = new List<USCensusDAO>();
            try
            {
                //using csvHelper to read csv Data and convert into list
                using (var reader = new StreamReader(csvUSStateFilePath))
                    if (csvUSStateFilePath.EndsWith(".csv"))
                    {
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            records = csv.GetRecords<USCensusDAO>().ToList();
                        }
                    }
                    else
                    {
                        throw new CSABuilderException(CSABuilderException.ExceptionType.Type_Incorrect, "");
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
            catch(DirectoryNotFoundException e)
            {
                throw new CSABuilderException(CSABuilderException.ExceptionType.Type_Incorrect, e.Message);
            }
        }
    }
}