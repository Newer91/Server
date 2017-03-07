using BandD.Serwis.Tools.LoggerService;
using System;

namespace BandD.Serwis.Tools.Logger
{
    public static class LoggerExeption
    {
        static LoggerClient logger = new LoggerClient();
        public static void LogExeption(Exception exeption)
        {
            Guid applicationId = new Guid("C80D9061-FD9F-4007-9E05-04B59396CE89");
            Guid clientId = new Guid("9B82C798-371D-4A93-BD72-ED4FE52B9DB9");

            logger.SaveErrorToDataBase(applicationId, clientId, exeption.Message,exeption.TargetSite.Name);
        }
    }
}
