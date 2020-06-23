using System;
using System.Collections.Generic;
using System.Text;

namespace IndianCensusAnalyser.Model
{
    public class USCensusDAO
    {
        public string StateId;
        public string State;
        public double Population;
        public double TotalArea;
        public double HousingDensity;
        public double HousingUnits;
        public double WaterArea;
        public double LandArea;
        public double PopulationDensity;
        public USCensusDAO(USStateCensusData usStateCensus)
        {
            this.StateId = usStateCensus.StateId;
            this.State = usStateCensus.State;
            this.Population = usStateCensus.Population;
            this.TotalArea = usStateCensus.TotalArea;
            this.HousingDensity = usStateCensus.HousingDensity;
            this.HousingUnits = usStateCensus.HousingUnits;
            this.WaterArea = usStateCensus.WaterArea;
            this.LandArea = usStateCensus.LandArea;
            this.PopulationDensity = usStateCensus.PopulationDensity;
        }
    }
}
