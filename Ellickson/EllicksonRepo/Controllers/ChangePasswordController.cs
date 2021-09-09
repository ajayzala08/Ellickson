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
    public class ChangePasswordController : ApiController
    {
        private IEllicksonRepository iellicksonRepository;

        public ChangePasswordController(IEllicksonRepository _iellicksonrepository)
        {
            iellicksonRepository = _iellicksonrepository;
        }

        //[HttpPost]
        //public HttpResponseMessage ChangePassword(string pwd, ChangePasswordModel model)
        //{
        //    HttpResponseMessage response;
        //    var result = iellicksonRepository.ChangePassword(pwd, model);
        //    if (result == 1)
        //    {
        //        response = Request.CreateResponse(HttpStatusCode.OK, "Password Changed Successfull");
        //    }
        //    else
        //    {
        //        response = Request.CreateResponse(HttpStatusCode.Unauthorized, "Fail");
        //    }
        //    return response;

        //}
    }
}
