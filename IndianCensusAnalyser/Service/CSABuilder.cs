using IndianCensusAnalyser.Exceptions;
using IndianCensusAnalyser.Interface;
using IndianCensusAnalyser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndianCensusAnalyser.Service
{
    public class CSABuilder : ICSABuilder
    {
        public List<IndiaStateCensusData> LoadCensusStateData(string csvFilePath)
        {
            List<IndiaStateCensusData> numOfRecords = new List<IndiaStateCensusData>();
            try
            {
                string[] lines;
                var list = new List<string>();
                var fileStream = new FileStream(csvFilePath, FileMode.Open, FileAccess.Read);
                int numOfEntries = 0;

                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        numOfEntries++;
                        list.Add(line);
                    }
                }
                lines = list.ToArray();
                return numOfRecords;
            }
            catch (FileNotFoundException e)
            {
                throw new CSABuilderException(CSABuilderException.ExceptionType.No_SuchFile_Exception, e.Message);
            }
        }
    }
}
