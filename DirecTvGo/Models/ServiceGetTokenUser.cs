using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace DirecTvGo.Models
{
    public class ServiceGetTokenUser
    {
        public string tokenInfo(UserLogin user) {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:44354/token");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded"; // or whatever - application/json, etc, etc
            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());

            try
            {
                string query = "username=" + user.UserEmail + "&password=" + user.UserPassword + "&grant_type=password";
                requestWriter.Write(query);
            }
            catch
            {
                throw;
            }
            finally
            {
                requestWriter.Close();
                requestWriter = null;
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                return sr.ReadToEnd();
            }
        }
    }
}