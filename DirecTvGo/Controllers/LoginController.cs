using DirecTvGo.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DirecTvGo.Controllers
{
    public class LoginController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;
        


        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public async Task<IHttpActionResult> Post([FromBody] UserLogin LoginInfo)
        {
            var user = UserManager.Find(LoginInfo.UserEmail, LoginInfo.UserPassword);
            if (user != null)
            {
                ServiceGetTokenUser service = new ServiceGetTokenUser();
                string token = service.tokenInfo(LoginInfo);
                ServiceResponseAccessService reponseLogin = new ServiceResponseAccessService();
                ResponseTokenInfo responseTokenInfo = reponseLogin.reponseAccess(token, user);
                LoginService loginService = new LoginService();
                LoginSession login = loginService.Login_user(responseTokenInfo, user);
                ApplicationDbContext db = new ApplicationDbContext();
                db.Login_Session.Add(login);
                db.SaveChanges();


                return Ok(login);
            }
            else
            {
                IdentityResult validationResult = new IdentityResult("Invalid username and/or password");
                return GetErrorResult(validationResult);
            }
        }

        // POST api/Login/SignUp

        [Route("SignUp")]
        public async Task<IHttpActionResult> SignUp([FromBody] UserLogin LoginInfo) {
            var user = UserManager.Find(LoginInfo.UserEmail, LoginInfo.UserPassword);
            if (user != null)
            {
                ServiceGetTokenUser service = new ServiceGetTokenUser();
                string token = service.tokenInfo(LoginInfo);
                ServiceResponseAccessService reponseLogin = new ServiceResponseAccessService();
                ResponseTokenInfo responseTokenInfo = reponseLogin.reponseAccess(token, user);

                return Ok(responseTokenInfo);
            }
            else { 
                IdentityResult validationResult = new IdentityResult("Invalid username and/or password");
                return GetErrorResult(validationResult);
            }
            
            
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}