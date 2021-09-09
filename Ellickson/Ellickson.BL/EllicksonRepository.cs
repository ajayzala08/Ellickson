using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ellickson.Data;
using Ellickson.IBL;
using Ellickson.Model;

namespace Ellickson.BL
{
    public class EllicksonRepository : IEllicksonRepository
    {
        private ellickson_dbEntities db;

        public EllicksonRepository()
        {
            db = new ellickson_dbEntities();
        }
        public IEnumerable<UserModel> GetAllUser()
        {
            IEnumerable<UserModel> listofusers = (from users in db.tblUser_Master
                                                  select new UserModel()
                                                  {
                                                      UserID = users.UserID,
                                                      Name = users.Name,
                                                      Designation = users.Designation,
                                                      DepartmentID = users.DepartmentID,
                                                      Address = users.Address,
                                                      State = users.State,
                                                      City = users.City,
                                                      PinCode = users.PinCode,
                                                      ContactNo = users.ContactNo,
                                                      Alternate_ContactNo = users.Alternate_ContactNo,
                                                      EmailID = users.EmailID,
                                                      Password = users.Password,
                                                      CreatedDate = users.CreatedDate,
                                                      UpdatedDate = users.UpdatedDate
                                                  }).ToList();
            return listofusers;
        }

        public UserModel GetUserById(int userId)
        {
            var res = db.tblUser_Master.Find(userId);

            if (res != null)
            {

                UserModel listofusers = (from users in db.tblUser_Master where userId == users.UserID
                                                      select new UserModel()
                                                      {
                                                          UserID = users.UserID,
                                                          Name = users.Name,
                                                          Designation = users.Designation,
                                                          DepartmentID = users.DepartmentID,
                                                          Address = users.Address,
                                                          State = users.State,
                                                          City = users.City,
                                                          PinCode = users.PinCode,
                                                          ContactNo = users.ContactNo,
                                                          Alternate_ContactNo = users.Alternate_ContactNo,
                                                          EmailID = users.EmailID,
                                                          Password = users.Password,
                                                          CreatedDate = users.CreatedDate,
                                                          UpdatedDate = users.UpdatedDate
                                                      }).FirstOrDefault();
                return listofusers;
            }
            return null;
        }
        public int CreateUser(UserModel usermodel)
        {
            Data.tblUser_Master users = new Data.tblUser_Master()
            {
                Name = usermodel.Name,
                Designation = usermodel.Designation,
                DepartmentID = usermodel.DepartmentID,
                Address = usermodel.Address,
                State = usermodel.State,
                City = usermodel.City,
                PinCode = usermodel.PinCode,
                ContactNo = usermodel.ContactNo,
                Alternate_ContactNo = usermodel.Alternate_ContactNo,
                EmailID = usermodel.EmailID,
                CreatedDate = usermodel.CreatedDate,
                UpdatedDate = usermodel.UpdatedDate,
                IsActive = usermodel.isActive,
                isDelete = usermodel.isDelete
            };
            db.tblUser_Master.Add(users);
            return db.SaveChanges();
        }

       
        public int EditUser(int id, UserModel usermodel)
        {            
            if (id == usermodel.UserID)
            {
                Data.tblUser_Master users = new Data.tblUser_Master()
                {
                    UserID = usermodel.UserID,
                    Name = usermodel.Name,
                    Designation = usermodel.Designation,
                    DepartmentID = usermodel.DepartmentID,
                    Address = usermodel.Address,
                    State = usermodel.State,
                    City = usermodel.City,
                    PinCode = usermodel.PinCode,
                    ContactNo = usermodel.ContactNo,
                    Alternate_ContactNo = usermodel.Alternate_ContactNo,
                    EmailID = usermodel.EmailID,
                    Password = usermodel.Password,
                    CreatedDate = usermodel.CreatedDate,
                    UpdatedDate = usermodel.UpdatedDate,
                    IsActive = usermodel.isActive,
                    isDelete = usermodel.isDelete
                };
                db.Entry(users).State = System.Data.Entity.EntityState.Modified;                
                return db.SaveChanges();
            }
            else
            {                
                return 0;
            }
        }
        public int DeleteUser(int id)
        {
            UserModel model = new UserModel();
            var Info = db.tblUser_Master.Where(m => m.UserID == id).FirstOrDefault();
            db.tblUser_Master.Remove(Info);
            db.SaveChanges();
            return 1;
        }

        public IEnumerable<DepartmentModel> GetAllDepartment()
        {
            IEnumerable<DepartmentModel> listofdepartment = (from department in db.tblDepartment_Master
                                                  select new DepartmentModel()
                                                  {
                                                     DepartmentID = department.DepartmentID,
                                                     Department_Name = department.Department_Name

                                                  }).ToList();
            return listofdepartment;
        }

        public DepartmentModel GetDepartById(int id)
        {
            var res = db.tblDepartment_Master.Find(id);

            if (res != null)
            {
                DepartmentModel listofdept = (from department in db.tblDepartment_Master
                                         where id == department.DepartmentID
                                         select new DepartmentModel()
                                         {                   
                                             DepartmentID = department.DepartmentID,
                                             Department_Name = department.Department_Name                                            
                                            
                                         }).FirstOrDefault();
                return listofdept;
            }
            return null;
        }

        public int CreateDepartment(DepartmentModel departmentmodel)
        {
            Data.tblDepartment_Master dept = new Data.tblDepartment_Master()
            {
                Department_Name = departmentmodel.Department_Name
            };
            db.tblDepartment_Master.Add(dept);
            return db.SaveChanges();
        }

        public int EditDepartment(int id, DepartmentModel departmentmodel)
        {
            if (id == departmentmodel.DepartmentID)
            {
                Data.tblDepartment_Master dept = new Data.tblDepartment_Master()
                {
                    DepartmentID = departmentmodel.DepartmentID,
                    Department_Name = departmentmodel.Department_Name                   
                };
                db.Entry(dept).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public int DeleteDepartment(int id)
        {
            DepartmentModel model = new DepartmentModel();
            var Info = db.tblDepartment_Master.Where(m => m.DepartmentID == id).FirstOrDefault();
            db.tblDepartment_Master.Remove(Info);
            db.SaveChanges();
            return 1;
        }

        public int UserLogin(LoginModel loginmodel)
        {
            Data.tblUser_Master users = new Data.tblUser_Master()
            {
                EmailID = loginmodel.email,
                Password = loginmodel.password
            };           
            
            var res = db.tblUser_Master.Where(x => x.EmailID == loginmodel.email && x.Password == loginmodel.password).FirstOrDefault();
            if (res != null)
            {
                if (res.EmailID == loginmodel.email && res.Password == loginmodel.password)
                {
                    return 1;
                }
                return 0;
            }
            else
            {
                return 0;
            }
        }

        public int ChangePassword(string pwd, ChangePasswordModel changepwdmodel)
        {
        //    Data.tblUser_Master users = new Data.tblUser_Master()
        //    {
        //        EmailID = changepwdmodel.email,
        //        Password = changepwdmodel.OldPassword
        //    };

        //    var pass = db.tblUser_Master.Where(x => x.EmailID == changepwdmodel.email && x.Password == changepwdmodel.OldPassword).FirstOrDefault();

        //    if (pass != null)
        //    {
        //        if (pass.Password == changepwdmodel.OldPassword)
        //        {
        //            Data.tblUser_Master newpwd = new Data.tblUser_Master()
        //            {
        //                Password = changepwdmodel.NewPassword
        //            };
        //            if (changepwdmodel.NewPassword == changepwdmodel.ConfirmNewPassword)
        //            {
        //                db.Entry(newpwd).State = System.Data.Entity.EntityState.Modified;
        //                return db.SaveChanges();
        //            }                  
        //        }
        //    }
        //    else
        //    {
        //        return 0;
        //    }
           return 0;
        }
    }
}
