using BussinesLayer.Entities.StudentsUtilities;
using DataAccessLayer.DBTools;
using DataAccessLayer.Interfaces;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Data.Common;
using System.Text;

namespace BussinesLayer.Entities
{
    public class Student : User, IErrMsg
    {
        public int? Grade { get; set; }
        public int? Fee { get; set; }
        public int? Gpa { get; set; }
        public int? CourseId { get; set; }
        public long? Count { get; set; }
        [JsonConvertable]
        public List<StudentApi> Students { get; set; } = new List<StudentApi>();
        public string? ErrMsg { get; set; }

        public Student() { }

        public async Task<Student> AddStudentAsync()
        {
            try
            {
                List<SPParam> param = new List<SPParam>()
                {
                    new SPParam("_FirstName", this.FirstName),
                    new SPParam("_LastName", this.LastName),
                    new SPParam("_Birthday", this.Birthday),
                    new SPParam("_Email", this.Email),
                    new SPParam("_Grade", this.Grade),
                    new SPParam("_Fee", this.Fee),
                    new SPParam("_Gpa", this.Gpa),
                    new SPParam("_CourseId", this.CourseId)
                };
                Student item = await MySQLDataAccess<Student>.ExecuteSPItemAsync("AddStudent", param);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Student.AddStudentAsync, Ex:{ex.Message}");
                return null;
            }
        }
        public async Task<Student> AddStudentJsonAsync(List<StudentJsonApi> model)
        {
            try
            {
                var jsonObj = JsonConvert.SerializeObject(model);
                List<SPParam> param = new List<SPParam>()
                {
                    new SPParam("studentJson", jsonObj)
                };
                Student item = await MySQLDataAccess<Student>.ExecuteSPItemAsync("AddStudentJson", param);
                return item;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Func: Student.AddStudentJsonAsync, Ex:{ex.Message}");
                return null;
            }
        }
        public async Task DeleteStudentAsync()
        {
            try
            {
                List<SPParam> param = new List<SPParam>
                {
                    new SPParam("_StudentId", this.Id)
                };
                Student item = await MySQLDataAccess<Student>.ExecuteSPItemAsync("DeleteStudent", param);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Student.DeleteStudentAsync, Ex:{ex.Message}");
            }
        }
        public async Task<Student> GetStudentByIdAsync()
        {
            try
            {
                List<SPParam> param = new List<SPParam>
                {
                    new SPParam("_studentId", this.Id)
                };
                Student item = await MySQLDataAccess<Student>.ExecuteSPItemAsync("GetStudent", param);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Student.GetStudentByIdAsync, Ex:{ex.Message}");
                return null;
            }
        }
        public async Task<Student> GetStudentByGpaAsync()
        {
            try
            {
                List<SPParam> param = new List<SPParam>
                {
                    new SPParam("_GPA", this.Gpa)
                };
                Student item = await MySQLDataAccess<Student>.ExecuteSPItemAsync("GetStudentByGpa", param);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Student.GetStudentByGpaAsync, Ex:{ex.Message}");
                return null;
            }
        }
        public async Task<List<StudentsByCourseApi>> GetStudentByCourseAsync()
        {
            try
            {
                List<SPParam> param = new List<SPParam>
                {
                    new SPParam("_CourseId", this.CourseId)
                };

                List<StudentsByCourseApi> item = await MySQLDataAccess<StudentsByCourseApi>.ExecuteSPListAsync("GetStudentsByCourse", param);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Student.GetStudentByCourseAsync, Ex:{ex.Message}");
                return null;
            }
        }
        public async Task<Student> GetStudentsGroupdAsync()
        {
            try
            {
                List<SPParam> param = new List<SPParam>
                {
                    new SPParam("_CourseId", this.CourseId),
                };

                Student students = await MySQLDataAccess<Student>.ExecuteSPItemAsync("GetStudentByCourseGroup", param);
                return students;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Student.GetStudentsGroupdAsync, Ex:{ex.Message}");
                return null;
            }
        }
    }
}

