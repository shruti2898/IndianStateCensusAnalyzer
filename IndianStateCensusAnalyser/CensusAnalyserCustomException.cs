using System;

namespace IndianStateCensusAnalyser
{
    public class CensusAnalyserCustomException : Exception
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND,
            INVALID_FILE_TYPE,
            INCORRECT_DELIMITER,
            INCORRECT_HEADER,
            NO_SUCH_COUNTRY
        }

        public ExceptionType eType;
        public CensusAnalyserCustomException(string message, ExceptionType exceptionType) : base(message)
        {
            this.eType = exceptionType;
        }

    }
}
