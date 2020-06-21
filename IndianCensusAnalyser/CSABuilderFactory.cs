using IndianCensusAnalyser.Interface;
using IndianCensusAnalyser.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianCensusAnalyser
{
    public class CSABuilderFactory
    {
        public static ICSABuilder CreateCSVBuilder()
        {
            return new CSABuilder();
        }
    }
}
