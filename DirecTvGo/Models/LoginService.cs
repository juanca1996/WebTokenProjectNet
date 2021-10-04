using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DirecTvGo.Models
{
    public class LoginService
    {
        public LoginSession Login_user(ResponseTokenInfo tokeninfo, ApplicationUser user) {
           
            LoginSession login = new LoginSession()
            {
                login_id = Guid.NewGuid().ToString(),
                Creation_date = tokeninfo.Creation_Date,
                Update_date = tokeninfo.Update_date,
                token = tokeninfo.Token.ToString(),
                Last_login = tokeninfo.Last_Login,
                userId = user.Id
            };

            return login;
        }
    }
}