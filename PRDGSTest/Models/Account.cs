﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRDGSTest.Models
{
    public class Account
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string [] Roles { get; set; }
    }
}