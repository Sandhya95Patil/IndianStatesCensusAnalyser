using IndianCensusAnalyser.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianCensusAnalyser.Interface
{
    public interface ICSABuilder
    {
        public List<StateCensusDAO> LoadCensusStateData(string csvFilePath);

        public List<StatesCodeData> LoadStateCodesData(string csvStatesCodeFilePath);
        public List<USStateCensusData> LoadUSStateCensusData(string csvUSStateFilePath);
    }
}
