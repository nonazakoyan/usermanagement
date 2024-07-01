using BussinesLayer.Entities.SubjectUtilities;
using DataAccessLayer.DBTools;
using DataAccessLayer.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using System.Xml.Linq;

namespace BussinesLayer.Entities
{
    public class Subject : IErrMsg
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public uint? rowCount { get; set; }
        public string? ErrMsg { get; set; }
        public Subject() { }

        public async Task<Subject> AddSubjectsAsync()
        {
            try
            {
                List<SPParam> param = new List<SPParam>
                {
                    new SPParam("_name", this.Name)
                };
                Subject item = await MySQLDataAccess<Subject>.ExecuteSPItemAsync("AddSubjects", param);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Subject.AddSubjectsAsync, Ex:{ex.Message}");
                return null;
            }
        }
        public async Task<Subject> DeleteSubjectAsync()
        {
            try
            {
                List<SPParam> param = new List<SPParam>
                {
                    new SPParam("_subjectId", this.Id)
                };
                Subject item = await MySQLDataAccess<Subject>.ExecuteSPItemAsync("DeleteSubject", param);
                return item;
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"Func: Subject.DeleteSubjectAsync, Ex:{ex.Message}");
                return null;
            }
        }
        public async Task<Subject> AddSubjectToProfessorAsync(int ProfessorId, int SubjectId)
        {
            try
            {
                List<SPParam> param = new List<SPParam>
                {
                    new SPParam("_ProfessorId", ProfessorId),
                    new SPParam("_subjectId", SubjectId)
                };
                Subject item = await MySQLDataAccess<Subject>.ExecuteSPItemAsync("AddSubjectsToProfessor", param);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Subject.AddSubjectToProfessorAsync, Ex:{ex.Message}");
                return null ;
            }
        }
        public async Task<Subject> AddSubjectToCourseAsync(int CourseId, int SubjectId)
        {
            try
            {
                List<SPParam> param = new List<SPParam>
                {
                    new SPParam("_CourseId", CourseId),
                    new SPParam("_SubjectId", SubjectId)
                };
                Subject item = await MySQLDataAccess<Subject>.ExecuteSPItemAsync("AddSubjectToCourse", param);
                return item;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Func: Subject.AddSubjectToCourseAsync, Ex:{ex.Message}");
                return null;
            }
        }
        public async Task<Subject> GetSubjectAsync()
        {
            try
            {
                List<SPParam> param = new List<SPParam>
                {
                    new SPParam("_SubjectId", this.Id)
                };
                Subject item = await MySQLDataAccess<Subject>.ExecuteSPItemAsync("GetSubjectById", param);
                return item;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Func: Subject.GetSubjectAsync, Ex:{ex.Message}");
                return null;
            }
        }
        public async Task<List<SubjectPaginByProfApi>> GetSubjectPagingByProfessorAsync(int ProfessorId, int viewCount, int startIndex)
        {
            try 
            {
                List<SPParam> param = new List<SPParam>
                {
                    new SPParam("professorId", ProfessorId),
                    new SPParam("viewCount", viewCount),
                    new SPParam("startIndex", startIndex)
                };
                List<SubjectPaginByProfApi> item = new List<SubjectPaginByProfApi>();
                (item,rowCount) = await MySQLDataAccess<SubjectPaginByProfApi>.ExecuteSPListByPagingAsync("GetSubjectByProfessorId", param);
                return item;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Func: Subject.GetSubjectPagingByProfessorAsync, Ex:{ex.Message}");
                return null;
            }
        }
    }
}
