using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL.Repository
{
    public class PlayerREP
    {
        public List<PlayerModel> getPlayer()
        {
            List<PlayerModel> PlayerList = new List<PlayerModel>();
            using(SqlConnection conn = clsConnectionDB.openConnection())
            {
                SqlCommand cmd = new SqlCommand("Proc_getPlayer", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader SDR = cmd.ExecuteReader())
                {
                    while(SDR.Read())
                    {
                        PlayerModel PM = new PlayerModel();
                        PM.PlayerID = SDR["PlayerID"].ToString();
                        PM.PlayerName = SDR["PlayerName"].ToString();
                        PM.PlayerDept = SDR["PlayerDept"].ToString();
                        PlayerList.Add(PM);
                    }
                }
            }
            return PlayerList;
        }

        public void deletePlayer(string PlayerID)
        {
            using (SqlConnection conn = clsConnectionDB.openConnection())
            {
                SqlCommand cmd = new SqlCommand("Proc_deletePlayer", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", PlayerID);
                cmd.ExecuteNonQuery();
            }
        }

        public void insertPlayer(string PlayerID, string PlayerName, string PlayerDept)
        {
            using (SqlConnection conn = clsConnectionDB.openConnection())
            {
                SqlCommand cmd = new SqlCommand("Proc_insertPlayer", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", PlayerID);
                cmd.Parameters.AddWithValue("@name", PlayerName);
                cmd.Parameters.AddWithValue("@dept", PlayerDept);
                cmd.ExecuteNonQuery();
            }
        }
    }
}