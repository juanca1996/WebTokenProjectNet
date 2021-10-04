using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace DirecTvGo.Models
{
    public class ServiceResponseAccessService
    {
        public ResponseTokenInfo reponseAccess(string reponse, ApplicationUser user) {
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(reponse)))
            { // Deserialization from JSON 
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(reponseJWT));
                reponseJWT reponseService = (reponseJWT)deserializer.ReadObject(ms);

                ResponseTokenInfo responseTokenInfo = new ResponseTokenInfo()
                {
                    Id = user.Id,
                    Creation_Date = DateTime.Now,
                    Update_date = DateTime.Now,
                    Last_Login = DateTime.Now,
                    Token = reponseService.access_token
                };

                return responseTokenInfo;
            }
            
        }
    }
}