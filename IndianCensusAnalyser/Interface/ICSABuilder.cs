using IndianCensusAnalyser.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianCensusAnalyser.Interface
{
    public interface ICSABuilder
    {
        public List<StateCensusData> LoadCensusStateData(string csvFilePath);

        public List<StatesCodeData> LoadStateCodesData(string csvStatesCodeFilePath);

    }
}
