﻿using BandD.Serwis.Model.LoginService;
using System.Security;
using BandD.Serwis.Tools.ServerTools;

namespace BandD.Serwis.Model
{
    public class LoginModel
    {
        private LoginServiceClient service = new LoginServiceClient();
        
        public bool Autorauthorization(SecureString password, string userName)
        {
            string pass = SecureTools.CalculateMD5Hash(SecureTools.convertToUNSecureString(password));
            return service.Autorauthorization(pass, userName);
        }
    }
}
