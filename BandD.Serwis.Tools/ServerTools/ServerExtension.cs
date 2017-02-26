namespace BandD.Serwis.Tools.ServerTools
{
    public static class ServerExtension
    {
        public static string GetConnectionString(string computerName)
        {
            string result = string.Empty;

            switch (computerName)
            {
                case "BANDD":
                    result = "SerwisConnectionStringBL";
                    break;
                case "DESKTOP-H4L3EG5":
                    result = "SerwisConnectionStringAS";
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
