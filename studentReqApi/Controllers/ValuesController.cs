using studentReqApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace studentReqApi.Controllers
{ 
    public class ValuesController : ApiController
    {
         
        Student stu = new Student();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        // GET api/values
        public List<Student> Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_MstStudent_SelectAll", con); 
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Student> lstStu = new List<Student>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Student stu = new Student();
                    stu.Id = Guid.Parse(dt.Rows[i]["Id"].ToString()); 
                    stu.regNo =Convert.ToInt16( dt.Rows[i]["RegNo"]); 
                    stu.firstName = dt.Rows[i]["FirstName"].ToString(); 
                    stu.lastName = dt.Rows[i]["LastName"].ToString(); 
                    stu.mobile = dt.Rows[i]["Mobile"].ToString(); 
                    stu.nic = dt.Rows[i]["Nic"].ToString(); 
                    stu.email = dt.Rows[i]["Email"].ToString();
                    lstStu.Add(stu);

                }
            }
            if (lstStu.Count > 0)
            {
                return lstStu;
            }else
            {
                return null;
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public string Post(Student stud)
        {
            string msg = "";
            if(stud != null)
            {
                

                SqlCommand cmd = new SqlCommand("SP_MstStudent_CreateorUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", stud.Id);
                cmd.Parameters.AddWithValue("@regno", stud.regNo);
                cmd.Parameters.AddWithValue("@fName", stud.firstName);
                cmd.Parameters.AddWithValue("@lName", stud.lastName);
                cmd.Parameters.AddWithValue("@mob", stud.mobile);
                cmd.Parameters.AddWithValue("@email", stud.email);
                cmd.Parameters.AddWithValue("@nic", stud.nic);
                cmd.Parameters.AddWithValue("@typ", stud.typ);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    msg= "Data set Inserted";
                }else
                {
                    msg= "Not Inserted";
                }

            }
            return msg;
        }

        // PUT api/values/5
        public void Put(int stud,[FromBody] string id)
        {
            
        }

        // DELETE api/values/5
        public void Delete(string stud)
        {
           
        }
    }
}
