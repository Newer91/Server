using BandD.Serwis.Tools.ServerTools.Extension;

namespace BandD.Serwis.Tools.Extension
{
    public static class ClientTools
    {
        public static bool ValidateProperty(object property)
        {
            var s = property as string;
            if (s != null && s != string.Empty)
                return true;
            var i = property as int?;
            if (i != null)
                return true;

            return false;
        }

        public static string SetTitleToDetailView(ViewType type)
        {
            string result = string.Empty;

            if (type == ViewType.Edit)
                result = "Edytuj element";
            else if (type == ViewType.New)
                result = "Dodaj element";
            else if (type == ViewType.View)
                result = "Przeglądaj element";

            return result;
        }
    }
}
