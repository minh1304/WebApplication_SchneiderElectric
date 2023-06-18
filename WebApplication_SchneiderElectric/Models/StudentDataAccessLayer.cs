using Microsoft.Data.SqlClient;
using System.Data;
using WebApplication_SchneiderElectric.Utility;

namespace WebApplication_SchneiderElectric.Models
{
    public class StudentDataAccessLayer
    {
        string connectionString = ConnectionString.CName;
        public IEnumerable<Student> GetAllStudent()
        {
            List<Student> lstStudent = new List<Student>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Student student = new Student();
                    student.Id = Convert.ToInt32(rdr["Id"]);
                    student.FirstName = rdr["FirstName"].ToString();
                    student.LastName = rdr["LastName"].ToString();
                    student.Email = rdr["Email"].ToString();
                    student.Mobile = rdr["Mobile"].ToString();
                    student.Address = rdr["Address"].ToString();

                    lstStudent.Add(student);
                }
                con.Close();
            }
            return lstStudent;
        }
        public void AddStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Mobile", student.Mobile);
                cmd.Parameters.AddWithValue("@Address", student.Address);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
