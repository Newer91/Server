using System.Security;
using BandD.Serwis.Tools.ServerTools;
using BandD.Serwis.Model.DictionariesService;
using BandD.Serwis.Domain;
using System.Collections.Generic;
using System.Linq;

namespace BandD.Serwis.Model
{
    public class UserModel
    {
        private DictionariesServiceClient service = new DictionariesServiceClient();

        public bool Autorauthorization(SecureString password, string userName)
        {
            string pass = SecureTools.CalculateMD5Hash(SecureTools.convertToUNSecureString(password));
            return service.Autorauthorization(pass, userName);
        }

        public List<User> getDataFromUser(string name, bool status)
        {
            return service.getDataFromUser(name, status).ToList();
        }
    }
}
