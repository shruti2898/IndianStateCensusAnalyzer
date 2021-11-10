using IndianStateCensusAnalyser.DTO;
using System.Collections.Generic;

namespace IndianStateCensusAnalyser
{
    class CSVAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                //case (CensusAnalyser.Country.US):
                //    return new USCensusAdapter().LoadUSCensusData(csvFilePath, dataHeaders);
                default:
                    throw new CensusAnalyserCustomException("No Such Country", CensusAnalyserCustomException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
    }
}
