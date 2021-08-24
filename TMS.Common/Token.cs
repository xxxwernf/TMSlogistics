﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Common
{
    public class Token
    {
        public IConfiguration Configuration;
        public Token(IConfiguration configuration)
        {
            Configuration = configuration;
        }
         /// <summary>
         /// 生成JWT码
         /// </summary>
         /// <returns></returns>
        public string Authenticate()
        {
            var jwtConfig = Configuration.GetSection("Jwt");
            //秘钥，就是标头，这里用Hmacsha256算法，需要256bit的密钥
            var securityKey = new SigningCredentials(
            new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(jwtConfig.GetValue<string>("Secret"))),
            SecurityAlgorithms.HmacSha256);
            //Claim，JwtRegisteredClaimNames中预定义了好多种默认的参数名，也可以像下面的Guid一样自己定义键名.
            //ClaimTypes也预定义了好多类型如role、email、name。Role用于赋予权限，不同的角色可以访问不同的接口
            //相当于有效载荷
            var claims = new Claim[] {
                new Claim(JwtRegisteredClaimNames.Iss,jwtConfig.GetValue<string>("Iss")),
                new Claim(JwtRegisteredClaimNames.Aud,jwtConfig.GetValue<string>("Aud")),
                new Claim("Guid",Guid.NewGuid().ToString("D")),
                new Claim(ClaimTypes.Role,"system"),
                new Claim(ClaimTypes.Role,"admin"),
            };
            SecurityToken securityToken = new JwtSecurityToken(
            signingCredentials: securityKey,
            expires: DateTime.Now.AddMinutes(2),//过期时间
            claims: claims
        );
            //生成jwt令牌
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

    }

}


