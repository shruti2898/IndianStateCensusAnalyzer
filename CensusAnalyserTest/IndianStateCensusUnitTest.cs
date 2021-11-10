using NUnit.Framework;
using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class IndianStateCensusUnitTest
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusFilePath = @"C:\Users\Mehta\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CsvFiles\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\Mehta\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CsvFiles\WrongIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\Mehta\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CsvFiles\WrongIndiaStateCensusData1.csv"; 
        static string wrongIndianStateCensusFileType = @"C:\Users\Mehta\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CsvFiles\IndiaStateCensusData.txt"; 
        static string delimiterIndianCensusFilePath = @"C:\Users\Mehta\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CsvFiles\DelimiterIndiaStateCensusData.csv";
 
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

       
        // Test Case 1.1 : For given States Census CSV file, Check to ensure the Number of Record matches.
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
    
        // Test Case 1.2 : For given State Census CSV file when file name is incorrect then it should return a custom exception.      
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserCustomException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserCustomException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }

        //Test Case 1.3 : For given State Census CSV file when file name is correct but file type is incorrect then it should return a custom exception.
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserCustomException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileType, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserCustomException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }

        // Test Case 1.4 : For given State Census CSV file when file is correct but delimeter is incorrect then it should return a custom exception.
        [Test]
        public void GivenIndianCensusDatafile_WhenDelimeterNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserCustomException>(() => censusAnalyser.LoadCensusData(delimiterIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserCustomException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }

        // Test Case 1.5 : For given State Census CSV file when file is correct but headers in Csv file are incorrect then it should return a custom exception.
        [Test]
        public void GivenIndianCensusDatafile_WhenHeaderNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserCustomException>(() => censusAnalyser.LoadCensusData(wrongHeaderIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserCustomException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }

    }
}