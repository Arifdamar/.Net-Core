using System;
using System.Collections.Generic;
using System.Text;
using Arif.JWTAuthentication.Entities.Interfaces;

namespace Arif.JWTAuthentication.Entities.Token
{
    public class JwtAccessToken : IToken
    {
        public string Token { get; set; }
    }
}
