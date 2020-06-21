using IndianCensusAnalyser.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianCensusAnalyser.Interface
{
    public interface ICSABuilder
    {
        public List<IndiaStateCensusData> LoadCensusStateData(string csvFilePath);

        public List<IndiaStatesCodeData> LoadStateCSVData(string csvStatesCodeFilePath);

    }
}
