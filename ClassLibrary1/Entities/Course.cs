using DataAccessLayer.DBTools;
using DataAccessLayer.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace BussinesLayer.Entities
{
    public class Course : IErrMsg
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? Grade { get; set; }
        public string? Specialty { get; set; }
        public string? ErrMsg { get; set; }
        public Course() { }
        public async Task<Course> AddCourseAsync()
        {
            try
            {
                List<SPParam> param = new List<SPParam>()
                {
                    new SPParam("_Name", this.Name),
                    new SPParam("_Grade", this.Grade),
                    new SPParam("_Specialty",this.Specialty)
                };
                Course item = await MySQLDataAccess<Course>.ExecuteSPItemAsync("AddCourse", param);
                return item;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Func: Course.AddCourseAsync, Ex:{ex.Message}");
                return null;
            }
        }
        public async Task DeleteCourseAsync()
        {
            try
            {
                List<SPParam> param = new List<SPParam>()
                {
                    new SPParam("_Id", this.Id),

                };
                await MySQLDataAccess<Course>.ExecuteSPItemAsync("DeleteCourse", param);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Func: Course.DeleteCourseAsync, Ex:{ex.Message}");
            }
        }
    }
}
