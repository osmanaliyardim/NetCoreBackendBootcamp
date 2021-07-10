using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

        //RefreshToken sistemi eklenebilir
        //Token süresi biten kullanıcıyı tekrar login etmek yerine
        //Yeni bir token vermek amacıyla sistem kurulabilir
    }
}
