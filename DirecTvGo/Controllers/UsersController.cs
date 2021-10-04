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
    public class UsersController : ApiController
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
        [Authorize]
        public async Task<IHttpActionResult> Get(string userId)
        {
            var request = Request;
            var headerReuqest = request.Headers;
            var tokenAuthorization = headerReuqest.Authorization.Parameter;
            ServiceValidationToken serviceValidationToken = new ServiceValidationToken();

            var reponseValidationToken = serviceValidationToken.responseValidationToken(tokenAuthorization, userId);
            if (reponseValidationToken == "ok")
            {
                var user = await UserManager.FindByIdAsync(userId);
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest("ups.. paso algo con la base de datos");
                }
            }
            else {
                return Content(HttpStatusCode.Unauthorized, reponseValidationToken);
            }
           
        }
    }
}