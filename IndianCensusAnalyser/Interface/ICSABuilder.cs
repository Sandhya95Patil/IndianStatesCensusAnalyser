using IndianCensusAnalyser.Model;

namespace IndianCensusAnalyser.Interface
{
    using System.Collections.Generic;

    /// <summary>
    /// ICSABuilder interface
    /// </summary>
    public interface ICSABuilder
    {
        /// <summary>
        /// Method to load indian states census data
        /// </summary>
        /// <param name="csvFilePath">csvFilePath parameter</param>
        /// <returns></returns>
        public List<StateCensusDAO> LoadCensusStateData(string csvFilePath);

        /// <summary>
        /// Method to load indian state codes 
        /// </summary>
        /// <param name="csvStatesCodeFilePath">csvStatesCodeFilePath parameter</param>
        /// <returns></returns>
        public List<StateCodesDAO> LoadStateCodesData(string csvStatesCodeFilePath);

        /// <summary>
        /// Method to load us states census data
        /// </summary>
        /// <param name="csvUSStateFilePath">csvUSStateFilePath parameter</param>
        /// <returns></returns>
        public List<USCensusDAO> LoadUSStateCensusData(string csvUSStateFilePath);
    }
}
