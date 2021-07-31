using System;
using System.Collections.Generic;
using System.Text;

namespace IndianCensusAnalyserProblem
{
    public class CsvAdapterFactory
    {
        public string[] LoadCsvData(CountryChecker.Country country, string csvFilePath, string headers)
        {
            try
            {
                //Checking the country 
                switch (country)
                {
                    case (CountryChecker.Country.INDIA):
                        {
                            return new CensusAnalyzer().LoadCountryCsv(csvFilePath, headers);
                        }
                    default:
                        {
                            throw new CensusCustomException(CensusCustomException.ExceptionType.NO_SUCH_COUNTRY, "NO SUCH COUNTRY");
                        }
                }
            }
            catch (CensusCustomException ex)
            {
                throw ex;
            }
        }
    }
}
