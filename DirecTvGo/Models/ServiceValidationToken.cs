using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DirecTvGo.Models
{
    public class ServiceValidationToken
    {
        public string responseValidationToken(string token, string userId) {
            return validateConditionToken(token, userId);
        }

        public string validateConditionToken(string token, string userId) {
            LoginSession loginSesionInfo = validateIfTheTokenIsThesameUser(token, userId);
            if (loginSesionInfo != null)
            {
                return boolvalidateIfTheTokenExpire(loginSesionInfo) == true ? "ok" : "Invalid Session";
            }
            else {
                return "No Authorized";
            }
        }

        public LoginSession validateIfTheTokenIsThesameUser(string token, string userId) {
            ApplicationDbContext db = new ApplicationDbContext();

            var loginData = db.Login_Session.Where(x => x.userId == userId && x.token == token).FirstOrDefault();

            if (loginData != null) {
                return loginData;
            }
            else
            {
                return null;
            }
        }

        public bool boolvalidateIfTheTokenExpire(LoginSession loginSessionInfo) 
        {
            var timeNow = DateTime.Now;
            var lastLogin = loginSessionInfo.Last_login.AddMinutes(30);

            if (timeNow > lastLogin) 
            {
                return false;
            }
            else
            {
                return true;
            }
        
        }
    }
}