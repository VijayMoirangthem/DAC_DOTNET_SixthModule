using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL.Repository
{
    public class CourseRep
    {
        public List<CourseModel> getCourse()
        {
            List <CourseModel> CourseList = new List<CourseModel>();    
            using (SqlConnection conn = clsConnectionDB.openConnection())
            {
                SqlCommand cmd = new SqlCommand("Proc_getCourse", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using(SqlDataReader SDR = cmd.ExecuteReader())
                {
                    while(SDR.Read())
                    {
                        CourseModel CM = new CourseModel();
                        CM.CID = SDR["CID"].ToString();
                        CM.CName = SDR["CName"].ToString();
                        CM.CDuration = Convert.ToInt32(SDR["CDuration"]);
                        CM.CFees = Convert.ToInt32(SDR["CFees"]);
                        CourseList.Add(CM); 
                    }
                }
            }
            return CourseList;
        }

        public void insertCourse(string CID , string CName , int CDuration , int CFees)
        {
            using(SqlConnection conn = clsConnectionDB.openConnection())
            {
                SqlCommand cmd = new SqlCommand("Proc_insertCourse", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", CID);
                cmd.Parameters.AddWithValue("@name", CName);
                cmd.Parameters.AddWithValue("@duration", CDuration);
                cmd.Parameters.AddWithValue("@fees", CFees);
                cmd.ExecuteNonQuery();
            }
        }

        public void deleteCourse(string CID)
        {
            using(SqlConnection conn = clsConnectionDB.openConnection())
            {
                SqlCommand cmd = new SqlCommand("Proc_deleteCourse", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", CID);
                cmd.ExecuteNonQuery();
            }
        }

        public CourseModel getCourseByID(string CID)
        {
            CourseModel CMOD = new CourseModel();
            using (SqlConnection conn = clsConnectionDB.openConnection())
            {
                SqlCommand cmd = new SqlCommand("Proc_getCourseByID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", CID);
                using(SqlDataReader SDR = cmd.ExecuteReader())
                {
                    while(SDR.Read())
                    {
                        CMOD.CID = SDR["CID"].ToString();
                        CMOD.CName = SDR["CName"].ToString();
                        CMOD.CDuration = Convert.ToInt32(SDR["CDuration"]);
                        CMOD.CFees = Convert.ToInt32(SDR["CFees"]);
                    }
                }
            }
            return CMOD;
        }
    }
}