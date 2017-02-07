using System;

namespace ClassViewModel.Dictionaries
{
    public class UserView
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public SlRoleView Rola { get; set; }
    }
}
