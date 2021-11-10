using NUnit.Framework;
using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class IndianStateCodeUnitTest
    {
       
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCodeFilePath = @"C:\Users\Mehta\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CsvFiles\IndiaStateCode.csv";
        static string wrongHeaderStateCodeFilePath = @"C:\Users\Mehta\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CsvFiles\WrongIndiaStateCode.csv";
        static string wrongIndianStateCodeFilePath = @"C:\Users\Mehta\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CsvFiles\WrongIndiaStateCode1.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\Mehta\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CsvFiles\IndiaStateCode.txt"; 
        static string delimiterIndianStateCodeFilePath = @"C:\Users\Mehta\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CsvFiles\DelimiterIndiaStateCode.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        // Test Case 2.1 : For given Indian State Code csv file, Check to ensure the Number of Record matches.
        [Test]
        public void GivenIndianStateCodeFile_WhenReaded_ShouldReturnStateDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }


        // Test Case 2.2 : For given Indian State Code CSV file when file name is incorrect then it should return a custom exception. 
        [Test]
        public void GivenWrongIndianStateCodeFile_WhenReaded_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserCustomException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserCustomException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

        // Test Case 2.3 : For given Indian State Code CSV file when file name is correct but file type is incorrect then it should return a custom exception.
        [Test]
        public void GivenWrongIndianStateCodeFileType_WhenReaded_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserCustomException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCodeFileType, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserCustomException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }

        // Test Case 2.4 : For given Indian State Code CSV file when file is correct but delimeter is incorrect then it should return a custom exception.
        [Test]
        public void GivenIndianStateCodefile_WhenDelimeterNotProper_ShouldReturnException()
        {
            var stateException = Assert.Throws<CensusAnalyserCustomException>(() => censusAnalyser.LoadCensusData(delimiterIndianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserCustomException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }

        // Test Case 2.5 : For given Indian State Code CSV file when file is correct but headers in Csv file are incorrect then it should return a custom exception.
        [Test]
        public void GivenIndianStateCodefile_WhenHeaderNotProper_ShouldReturnException()
        {
            var stateException = Assert.Throws<CensusAnalyserCustomException>(() => censusAnalyser.LoadCensusData(wrongHeaderStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserCustomException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}
