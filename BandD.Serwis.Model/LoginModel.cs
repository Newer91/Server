using System.Security;
using BandD.Serwis.Tools.ServerTools;
using BandD.Serwis.Model.DictionariesService;

namespace BandD.Serwis.Model
{
    public class LoginModel
    {
        private DictionariesServiceClient service = new DictionariesServiceClient();
        
        public bool Autorauthorization(SecureString password, string userName)
        {
            string pass = SecureTools.CalculateMD5Hash(SecureTools.convertToUNSecureString(password));
            return service.Autorauthorization(pass, userName);
        }
    }
}
