using System;
using SouthavenFeed.Exceptions;

namespace SouthavenFeed.Exceptions
{
    public static class ErrorMessages
    {
        public static string Message(EMsgCodes code)
        {
            switch(code)
            {
                default:
                    return null;
                case EMsgCodes.GENERAL_ERROR:
                    return "Oops! Something went wrong...";
                case EMsgCodes.UNABLE_TO_CONNECT_TO_DATABASE:
                    return "Unable to connect to database. The application can not continue.";
            }
        }
    }
}
