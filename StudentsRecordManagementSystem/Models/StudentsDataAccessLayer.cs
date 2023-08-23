using StudentsRecordManagementSystem.Utility;
using System.Collections.Generic;
using System.Data;
using System;
using System.Data.SqlClient;

namespace StudentsRecordManagementSystem.Models
{
    public class StudentsDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Students> GetAllStudent()
        {
            List<Students> lstStudent = new List<Students>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Students students = new Students();
                    students.Id = Convert.ToInt32(rdr["Id"]);
                    students.FirstName = rdr["FirstName"].ToString();
                    students.LastName = rdr["LastName"].ToString();
                    students.Email = rdr["Email"].ToString();
                    students.Mobile = rdr["Mobile"].ToString();
                    students.Address = rdr["Address"].ToString();

                    lstStudent.Add(students);
                }
                con.Close();
            }
            return lstStudent;
        }
        public void AddStudent(Students students)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_AddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", students.FirstName);
                cmd.Parameters.AddWithValue("@LastName", students.LastName);
                cmd.Parameters.AddWithValue("@Email", students.Email);
                cmd.Parameters.AddWithValue("@Mobile", students.Mobile);
                cmd.Parameters.AddWithValue("@Address", students.Address);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateStudent(Students students)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", students.Id);
                cmd.Parameters.AddWithValue("@FirstName", students.FirstName);
                cmd.Parameters.AddWithValue("@LastName", students.LastName);
                cmd.Parameters.AddWithValue("@Email", students.Email);
                cmd.Parameters.AddWithValue("@Mobile", students.Mobile);
                cmd.Parameters.AddWithValue("@Address", students.Address);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Students GetStudentData(int id)
        {
            Students students = new Students();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Students WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    students.Id = Convert.ToInt32(rdr["Id"]);
                    students.FirstName = rdr["FirstName"].ToString();
                    students.LastName = rdr["LastName"].ToString();
                    students.Email = rdr["Email"].ToString();
                    students.Mobile = rdr["Mobile"].ToString();
                    students.Address = rdr["Address"].ToString();
                }
            }
            return students;
        }

        public void DeleteStudent(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeletStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
