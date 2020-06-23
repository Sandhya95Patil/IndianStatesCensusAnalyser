
namespace IndianCensusAnalyser.Model
{
    public class USStateCensusData
    {
        public string StateId { get; set; }
        public string State { get; set; }
        public double Population { get; set; }
        public double HousingUnits { get; set; }
        public double TotalArea { get; set; }
        public double WaterArea { get; set; }
        public double LandArea { get; set; }
        public double PopulationDensity { get; set; }
        public double HousingDensity { get; set; }
    }
}
