using System.IO;

namespace IndianStateCensusAnalyser
{
    class CensusAdapter
    {
        protected string[] GetCensusData(string csvFilePath, string dataHeaders)
        {
            string[] censusData;
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserCustomException("File Not Found", CensusAnalyserCustomException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserCustomException("Invalid File Type", CensusAnalyserCustomException.ExceptionType.INVALID_FILE_TYPE);
            }
            censusData = File.ReadAllLines(csvFilePath);
            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyserCustomException("Incorrect header in Data", CensusAnalyserCustomException.ExceptionType.INCORRECT_HEADER);
            }
            return censusData;
        }
    }
}