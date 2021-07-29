using IndianCensusAnalyserProblem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IndianCensusProject
{
    [TestClass]
    public class UnitTest1
    {
        //Interface
        IStateCensusCsvOperations censusAnalyzer;
        IStateCodeCsvOperations stateCodeCsv;
        GetCensusAdapter getCensusAdapter;

        //Path for Indian State Census
        string censusFilePath = @"D:\Assignments\IndianCensusAnalyserProblem\IndianCensusAnalyserProblem\IndianStateCensusInformation.csv";
        string invalidFileCsvPath = @"D:\Assignments\IndianCensusAnalyserProblem\IndianCensusAnalyserProblem\InvalidCensusFile.csv";
        string invalidFileTypePath = @"D:\Assignments\IndianCensusAnalyserProblem\IndianCensusAnalyserProblem\InvalidCensusFile.css";
        string invalidDelimiterFilePath = @"D:\Assignments\IndianCensusAnalyserProblem\IndianCensusAnalyserProblem\IndianStateCensusWithInvalidDelimiter.csv";
        string invalidHeaderFilePath = @"D:\Assignments\IndianCensusAnalyserProblem\IndianCensusAnalyserProblem\IndianStateCensusWithInvalidHeader.csv";

        //Path for state code csv file
        string stateCodeFilePath = @"D:\Assignments\IndianCensusAnalyserProblem\IndianCensusAnalyserProblem\IndianStateCode.csv";
        string stateCodeInvalidFilePath = @"D:\Assignments\IndianCensusAnalyserProblem\IndianCensusAnalyserProblem\InvalidIndianState.csv";
        string stateCodeInvalidFileTypePath = @"D:\Assignments\IndianCensusAnalyserProblem\IndianCensusAnalyserProblem\InvalidCensusFile.css";
        string stateCodeInvalidFileDelimiterPath = @"D:\Assignments\IndianCensusAnalyserProblem\IndianCensusAnalyserProblem\InvalidIndianStateDelimiterCode.csv";
        string stateCodeInvalidFileHeaderPath = @"D:\Assignments\IndianCensusAnalyserProblem\IndianCensusAnalyserProblem\InvalidIndianStateHeaderCode.csv";

        [TestInitialize]
        public void SetUp()
        {
            getCensusAdapter = new GetCensusAdapter();
            censusAnalyzer = new CensusAnalyzer();
            stateCodeCsv = new CsvStateAnalyzer();
        }

        //TC1.1: Count the number of records
        [TestMethod]
        [TestCategory("Given State Census CSV return Count of fields")]
        public void TestMethodToCheckCountOfDataRetrieved()
        {
            int expected = 28;
            string[] result = getCensusAdapter.GetCensusData(censusFilePath, "﻿State,Population,Increase,Area,Density");
            int actual = result.Length - 1;
            Assert.AreEqual(expected, actual);
        }

        //TC1.2:Check whether File exists
        [TestMethod]
        [TestCategory("Check Whether File Exists")]
        public void TestMethodToCheckInvalidFile()
        {
            try
            {
                getCensusAdapter.GetCensusData(invalidFileCsvPath, "State,Population,Increase,Area,Density");

            }
            catch (CensusCustomException ex)
            {
                Assert.AreEqual(ex.Message, "File not found!");
            }
        }

        //TC1.3:Check for correct Extension
        [TestMethod]
        [TestCategory("Invalid File Extension")]
        public void TestMethodToCheckInvalidFileExtension()
        {
            try
            {
                getCensusAdapter.GetCensusData(invalidFileTypePath, "State,Population,Increase,Area,Density");

            }
            catch (CensusCustomException ex)
            {
                Assert.AreEqual(ex.Message, "Invalid file type");
            }
        }
        //TC1.4:Check for proper Delimiter
        [TestMethod]
        [TestCategory("Delimiter Check")]
        public void TestMethodToCheckInvalidDelimiter()
        {
            try
            {
                censusAnalyzer.LoadCountryCsv(CountryChecker.Country.INDIA,invalidDelimiterFilePath,"State-Population-Increase.Area.Density");

            }
            catch (CensusCustomException ex)
            {
                Assert.AreEqual(ex.Message, "Invalid Delimiter");
            }
        }
        //TC1.5: Check for incorrect header
        [TestMethod]
        [TestCategory("Incorrect Header")]
        public void TestMethodToCheckIncorrectHeader()
        {
            try
            {
                censusAnalyzer.LoadCountryCsv(CountryChecker.Country.INDIA, invalidHeaderFilePath, "State,Population,Increase,Area,Density");
            }
            catch (CensusCustomException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect Header");
            }
        }

    }
}