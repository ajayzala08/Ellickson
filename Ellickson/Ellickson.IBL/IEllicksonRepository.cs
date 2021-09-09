using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ellickson.Model;

namespace Ellickson.IBL
{
    public interface IEllicksonRepository
    {
        IEnumerable<UserModel> GetAllUser();
        UserModel GetUserById(int userId);
        int CreateUser(UserModel usermodel);
        int EditUser(int id, UserModel usermodel);
        int DeleteUser(int id);

        IEnumerable<DepartmentModel> GetAllDepartment();
        DepartmentModel GetDepartById(int id);
        int CreateDepartment(DepartmentModel departmentmodel);
        int EditDepartment(int id, DepartmentModel departmentmodel);
        int DeleteDepartment(int id);

        int UserLogin(LoginModel loginmodel);

        int ChangePassword(int id, ChangePasswordModel changepwdmodel);
    }
}
