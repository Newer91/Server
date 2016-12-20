﻿using System;

namespace BandD.Serwis.Domain
{
    public class User: BaseClass
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public string Role { get; set; }
    }
}