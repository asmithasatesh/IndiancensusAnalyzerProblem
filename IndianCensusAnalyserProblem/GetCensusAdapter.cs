using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndianCensusAnalyserProblem
{
    public class GetCensusAdapter
    {
        public string[] GetCensusData(string csvStateFilePath, string dataHeaders)
        {
            string[] statusData;
            //Checking file is exists or not
            if (!File.Exists(csvStateFilePath))
                throw new CensusCustomException(CensusCustomException.ExceptionType.FILE_NOT_FOUND, "File not found!");
            //Checking the path if it is csv extension or not
            else if (Path.GetExtension(csvStateFilePath) != ".csv")
                throw new CensusCustomException(CensusCustomException.ExceptionType.INVALID_FILE_TYPE, "Invalid Extension");
            //Read the data and check if it has proper header
            statusData = File.ReadAllLines(csvStateFilePath);
            if (statusData[0] != dataHeaders)
                throw new CensusCustomException(CensusCustomException.ExceptionType.INCORRECT_HEADER, "Incorrect Header");
            return statusData;
        }
    }
}
