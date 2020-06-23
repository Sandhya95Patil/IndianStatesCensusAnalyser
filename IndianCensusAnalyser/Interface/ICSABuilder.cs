using IndianCensusAnalyser.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianCensusAnalyser.Interface
{
    public interface ICSABuilder
    {
        public List<StateCensusDAO> LoadCensusStateData(string csvFilePath);

        public List<StateCodesDAO> LoadStateCodesData(string csvStatesCodeFilePath);
        public List<USCensusDAO> LoadUSStateCensusData(string csvUSStateFilePath);
    }
}
