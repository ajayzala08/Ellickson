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
    public class DepartmentController : ApiController
    {
        private IEllicksonRepository iellicksonRepository;

        public DepartmentController(IEllicksonRepository _iellicksonrepository)
        {
            iellicksonRepository = _iellicksonrepository;
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var result = iellicksonRepository.GetAllDepartment();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;

        }

        [HttpGet]
        public HttpResponseMessage GetUser(int deptId)
        {
            var result = iellicksonRepository.GetDepartById(deptId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }


        [HttpPost]
        public HttpResponseMessage Create(DepartmentModel deptmodel)
        {
            var result = iellicksonRepository.CreateDepartment(deptmodel);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;

        }

        [HttpPut]
        public HttpResponseMessage Put(int id, DepartmentModel model)
        {
            var result = iellicksonRepository.EditDepartment(id, model);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;

        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var result = iellicksonRepository.DeleteDepartment(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;

        }
    }
}
