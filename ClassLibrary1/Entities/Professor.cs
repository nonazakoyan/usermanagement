using DataAccessLayer.DBTools;
using DataAccessLayer.Interfaces;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace BussinesLayer.Entities
{
    public class Professor : User, IErrMsg
    {
        public string? Password { get; set; }
        public int? Salary { get; set; }
        public string? Position { get; set; }
        public string? TeachingCourses { get; set; }
        public string? TeachingSubjects { get; set; }
        public string? ErrMsg { get; set; }
        public Professor()
        {
        }
        public async Task<Professor> AddRegisterProfessorAsync()
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("_FirstName", this.FirstName),
                    new SPParam("_LastName", this.LastName),
                    new SPParam("_Birthday", this.Birthday),
                    new SPParam("_Email", this.Email),
                    new SPParam("_Password", this.Password),
                    new SPParam("_Salary", this.Salary),
                    new SPParam("_Position", this.Position)
                };
                Professor item = await MySQLDataAccess<Professor>.ExecuteSPItemAsync("RegisterUser", par);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Professor.AddRegisterProfessorAsync, Ex:{ex.Message}");
                return null;
            }
            finally
            {
            }
        }
        public async Task<Professor> LoginUser()
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("_Email", this.Email),
                    new SPParam("_Password", this.Password)
                };
                Professor item = await MySQLDataAccess<Professor>.ExecuteSPItemAsync("LoginUser", par);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Professor.LoginUser, Ex:{ex.Message}");
                return null;
            }
        }
        public async Task DeleteprofessorAsync()
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("_Id", this.Id)
                };
                Professor item = await MySQLDataAccess<Professor>.ExecuteSPItemAsync("DeleteProfessor", par);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Professor.DeleteprofessorAsync, Ex:{ex.Message}");
            }
        }
        public async Task<Professor> AddProfessorToCourseAsync(int ProfessorId, int CourseId)
        {
            try
            {
                List<SPParam> par = new List<SPParam>
                {
                    new SPParam("_ProfessorId", ProfessorId),
                    new SPParam("_CourseId", CourseId)
                };
                Professor item = await MySQLDataAccess<Professor>.ExecuteSPItemAsync("AddProfessorToCourse", par);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Professor.AddProfessorToCourseAsync, Ex:{ex.Message}");
                return null;
            }
        }
        public async Task<Professor> GetProfessorAsync()
        {
            try
            {
                List<SPParam> param = new List<SPParam>
                {
                    new SPParam("_Id", this.Id)
                };
                Professor item = await MySQLDataAccess<Professor>.ExecuteSPItemAsync("GetProfessor", param);
                return item;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Func: Professor.GetProfessorAsync, Ex:{ex.Message}");
                return null;
            }
        }
    }
}
