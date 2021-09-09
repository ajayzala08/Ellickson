using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ellickson.Model;
using Ellickson.BL;
using System.Threading.Tasks;
using Ellickson.IBL;
using Ellickson.Data;

namespace EllicksonRepo.Controllers
{
    public class LoginController : ApiController
    {
        private IEllicksonRepository iellicksonRepository;

        public LoginController(IEllicksonRepository _iellicksonrepository)
        {
            iellicksonRepository = _iellicksonrepository;
        }

        [HttpPost]
        public HttpResponseMessage Userlogin(LoginModel model)
        {
            HttpResponseMessage response;
            var result = iellicksonRepository.UserLogin(model);
            if (result == 1)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Login Successfull");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.Unauthorized, "Login Fail");
            }
            return response;

        }
    }
}
