
namespace IndianCensusAnalyser.Model
{
    public class StateCensusDAO
    {
        public string State;
        public double Population;
        public double AreaInSqKm;
        public double DensityPerSqKm;
        public StateCensusDAO(StateCensusData stateCensusData)
        {
            this.State = stateCensusData.State;
            this.Population = stateCensusData.Population;
            this.DensityPerSqKm = stateCensusData.DensityPerSqKm;
            this.AreaInSqKm = stateCensusData.AreaInSqKm;
        }
    }
}
