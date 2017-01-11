namespace BandD.Serwis.Tools.Extension
{
    public static class ClientTools
    {
        public static bool ValidateProperty(object property)
        {
            var s = property as string;
            if (s != null && s != string.Empty)
                return true;

            return false;
        }
    }
}
