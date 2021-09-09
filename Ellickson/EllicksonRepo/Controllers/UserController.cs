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
    
    public class UserController : ApiController
    {
        private IEllicksonRepository iellicksonRepository;
       
        public UserController(IEllicksonRepository _iellicksonrepository)
        {
            iellicksonRepository = _iellicksonrepository;
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var result = iellicksonRepository.GetAllUser();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;

            //List<UserModel> li = new List<UserModel>();
            //Dictionary<string, string> dict = new Dictionary<string, string>();
            //var details = iellicksonRepository.GetAllUser();
            //foreach (var x in details)
            //{
            //    UserModel model = new UserModel();
            //    model.UserID = x.UserID;
            //    model.Name = x.Name;
            //    model.Designation = x.Designation;
            //    model.DepartmentID = x.DepartmentID;
            //    model.Address = x.Address;
            //    model.State = x.State;
            //    model.City = x.City;
            //    model.PinCode = x.PinCode;
            //    model.ContactNo = x.ContactNo;
            //    model.Alternate_ContactNo = x.Alternate_ContactNo;
            //    model.EmailID = x.EmailID;
            //    model.Password = x.Password;
            //    model.CreatedDate = x.CreatedDate;
            //    model.UpdatedDate = x.UpdatedDate;
            //    li.Add(model);
            //}
            //return Request.CreateResponse(HttpStatusCode.OK, li);
        }

        [HttpGet]
        public HttpResponseMessage GetUser(int userId)
        {
            var result = iellicksonRepository.GetUserById(userId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }


        [HttpPost]
        public HttpResponseMessage Create(UserModel usermodel)
        {
            var result = iellicksonRepository.CreateUser(usermodel);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;

        }

        [HttpPut]
        public HttpResponseMessage Put(int id, UserModel model)
        {
            var result = iellicksonRepository.EditUser(id, model);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;           

        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var result = iellicksonRepository.DeleteUser(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;

        }

    }
}