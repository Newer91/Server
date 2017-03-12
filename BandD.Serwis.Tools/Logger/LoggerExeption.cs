using BandD.Serwis.Tools.LoggerService;
using System;
using System.Runtime.CompilerServices;

namespace BandD.Serwis.Tools.Logger
{
    public static class LoggerExeption
    {

        public static void LogExeption(Exception exeption, string codeMethodName)
        {
            LoggerClient logger = new LoggerClient();

            Guid applicationId = new Guid("C80D9061-FD9F-4007-9E05-04B59396CE89");
            Guid clientId = new Guid("9B82C798-371D-4A93-BD72-ED4FE52B9DB9");

            logger.SaveErrorToDataBase(applicationId, clientId, exeption.Message, exeption.TargetSite.Name, codeMethodName);
        }

        public static string CalleMethodsName([CallerMemberName] string name = "")
        {
            return name;
        }
    }
}
