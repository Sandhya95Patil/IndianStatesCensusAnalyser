using System;
using System.Collections.Generic;
using System.Text;

namespace IndianCensusAnalyser.Model
{
    public class StateCensusData
    {
        public string State { get; set; }
        public double Population { get; set; }
        public double AreaInSqKm { get; set; }
        public double DensityPerSqKm { get; set; }
    }
}
