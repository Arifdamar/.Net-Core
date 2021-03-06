﻿using System;
using System.Collections.Generic;
using System.Text;
using Arif.JWTAuthentication.Entities.Interfaces;

namespace Arif.JWTAuthentication.Entities.Dtos.AppUserDtos
{
    public class AppUserRegisterDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
