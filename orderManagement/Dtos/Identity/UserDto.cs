﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orderManagement.Dtos.Identity
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public string KnownAs { get; set; }
        public string Email { get; set; }
    }
}