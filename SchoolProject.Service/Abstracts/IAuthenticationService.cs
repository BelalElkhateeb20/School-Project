﻿using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Abstracts
{
    public interface IAuthenticationService
    {
        public Task<JwtAuthRespone> GetJWTToken(User user);
        public Task<JwtAuthRespone> GetRefrechToken(string accessToken,string refreshToken);
        public TokenValidatedResult ValidateToken(string accessToken);
    }
}
