using System;

namespace BandD.Serwis.Class
{
    public class Login: BaseClass
    {
        public Guid LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public string Role { get; set; }
    }
}
