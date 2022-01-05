using LecturersMVC_Web_App.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LecturersMVC_Web_App.Controllers.api
{
    public class StudentController : ApiController
    {

        static string ConnctionString = "Data Source=LAPTOP-OT5IVM7S;Initial Catalog=CollegeDB;Integrated Security=True";

        DataClasses1DataContext StudentDB = new DataClasses1DataContext(ConnctionString);

        // GET: api/Student

        public IHttpActionResult Get()
        {
            try
            {
                
                    List<Student> students = StudentDB.Students.ToList();
                    return Ok(new { students });
                
            }
            catch (SqlException ex) { return BadRequest(ex.Message); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // GET: api/Student/5
        public IHttpActionResult Get(int id)
        {
            try
            {

                Student studentsOne = StudentDB.Students.First(stu => stu.Id == id);
                return Ok(new { studentsOne });

            }
            catch (SqlException ex) { return BadRequest(ex.Message); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // POST: api/Student
        public IHttpActionResult Post([FromBody] Student value)
        {
            try
            {
                StudentDB.Students.InsertOnSubmit(value);
                StudentDB.SubmitChanges();
                return Ok("row add");

            }
            catch (SqlException ex) { return BadRequest(ex.Message); }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }

        // PUT: api/Student/5
        public IHttpActionResult Put(int id, [FromBody] Student valueStudent)
        {
            try
            {
                Student NewStudents = StudentDB.Students.First(stu => stu.Id == id);
                NewStudents.FullName = valueStudent.FullName;
                NewStudents.LastName = valueStudent.LastName;
                NewStudents.BornYear = valueStudent.BornYear;
                NewStudents.Email = valueStudent.Email;
                NewStudents.YearStudent = valueStudent.YearStudent;

                StudentDB.SubmitChanges();

                return Ok(new { NewStudents });

            }
            catch (SqlException ex) { return BadRequest(ex.Message); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // DELETE: api/Student/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Student studentOne = StudentDB.Students.First(s => s.Id == id);
                StudentDB.Students.DeleteOnSubmit(studentOne);
                StudentDB.SubmitChanges();
                List<Student> StudentList = StudentDB.Students.ToList();
                return Ok(new { StudentList });

            }
            catch (SqlException ex) { return BadRequest(ex.Message); }
            catch (Exception ex) { return BadRequest(ex.Message); }


        }
    }
}
