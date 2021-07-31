using System;
using System.Collections.Generic;
using System.Text;

namespace IndianCensusAnalyserProblem
{
    //Interface segregation principle
    public interface IStateCensusCsvOperations
    {
        string[] LoadCountryCsv(string fileCsvPath, string header);
    }
}