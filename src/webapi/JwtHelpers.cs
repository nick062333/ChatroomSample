using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace webapi
{
    public class JwtHelpers
    {
        private readonly IConfiguration Configuration;

        public JwtHelpers(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public string GenerateToken(string userName, int expireMinutes = 30)
        {
            var issuer = Configuration.GetValue<string>("JwtSettings:Issuer");
            var signKey = Configuration.GetValue<string>("JwtSettings:SignKey");

            // 密鑰，用於簽名和驗證JWT令牌
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signKey));

            // 設置JWT令牌的頭部
            //HmacSha256Signature
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // 定義JWT令牌的內容，包括身份驗證的主題（subject）和一些聲明（claims）
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "Users")
            };

            // var userClaimsIdentity = new ClaimsIdentity(claims);

            // 建立JWT令牌
            var token = new JwtSecurityToken(
                issuer: issuer,
                // audience: "YourAudience",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expireMinutes), // 令牌有效期
                signingCredentials: signingCredentials
            );

            // 使用JwtSecurityTokenHandler來獲取JWT令牌的字符串表示
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);

   



            //will版本
            // // TODO: You can define your "roles" to your Claims.
            // claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            // claims.Add(new Claim(ClaimTypes.Role, "Users"));

            // var userClaimsIdentity = new ClaimsIdentity(claims);

            // // Create a SymmetricSecurityKey for JWT Token signatures
            // var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signKey));

            // // HmacSha256 MUST be larger than 128 bits, so the key can't be too short. At least 16 and more characters.
            // // https://stackoverflow.com/questions/47279947/idx10603-the-algorithm-hs256-requires-the-securitykey-keysize-to-be-greater
            // var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // // Create SecurityTokenDescriptor
            // var tokenDescriptor = new SecurityTokenDescriptor
            // {
            //     Issuer = issuer,
            //     //Audience = issuer, // Sometimes you don't have to define Audience.
            //     //NotBefore = DateTime.Now, // Default is DateTime.Now
            //     //IssuedAt = DateTime.Now, // Default is DateTime.Now
            //     Subject = userClaimsIdentity,
            //     Expires = DateTime.Now.AddMinutes(expireMinutes),
            //     SigningCredentials = signingCredentials
            // };

            // // Generate a JWT securityToken, than get the serialized Token result (string)
            // var tokenHandler = new JwtSecurityTokenHandler();
            // var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            // var serializeToken = tokenHandler.WriteToken(securityToken);

            // return serializeToken;
        }
    }
}