using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndianCensusAnalyserProblem
{
    public class CensusAnalyzer : GetCensusAdapter
    {
        public string[] LoadCountryCsv(string fileCsvPath, string header)
        {
            string[] result=new string[50];
            try
            {
                result = GetCensusData(fileCsvPath, header);
                //Skip the headers
                foreach (var member in result.Skip(1))
                {
                    //Checks for delimiter 
                    if (!member.Contains(","))
                        throw new CensusCustomException(CensusCustomException.ExceptionType.INVALID_DELIMITER, "Invalid Delimiter");
                }
            }
            catch (CensusCustomException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
