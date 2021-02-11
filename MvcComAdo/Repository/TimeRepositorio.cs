using MvcComAdo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcComAdo.Repository
{
    public class TimeRepositorio
    {
        private SqlConnection _con;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["stringConexao"].ToString();
            _con = new SqlConnection(constr);
        }

        public bool AdicionarTime(Times timeObj)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("IncluirTime", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Time", timeObj.Time);
                command.Parameters.AddWithValue("@Estado", timeObj.Estado);
                command.Parameters.AddWithValue("@Cores", timeObj.Cores);

                _con.Open();

                i = command.ExecuteNonQuery();
            }

            _con.Close();

            return i >= 1;
        }

        public List<Times> ObterTimes()
        {
            Connection();
            
            List<Times> timesList = new List<Times>();

            using (SqlCommand command = new SqlCommand("ObterTimes", _con))
            {
                command.CommandType = CommandType.StoredProcedure;

                _con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Times time = new Times()
                    {
                        TimeId = Convert.ToInt32(reader["TimeId"]),
                        Time = Convert.ToString(reader["Time"]),
                        Estado = Convert.ToString(reader["Estado"]),
                        Cores = Convert.ToString(reader["Cores"])
                    };

                    timesList.Add(time);
                }

                _con.Close();

                return timesList;
            }
        }

        public bool AtualizarTime(Times timeObj)
        {
            Connection();
            
            int i;

            using (SqlCommand command = new SqlCommand("AtualizarTime", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TimeId", timeObj.TimeId);
                command.Parameters.AddWithValue("@Time", timeObj.Time);
                command.Parameters.AddWithValue("@Estado", timeObj.Estado);
                command.Parameters.AddWithValue("@Cores", timeObj.Cores);

                _con.Open();

                i = command.ExecuteNonQuery();
            }

            _con.Close();

            return i >= 1;
        }

        public bool ExcluirTime(int id)
        {
            Connection();

            int i;

            using (SqlCommand command = new SqlCommand("ExcluirTimePorId", _con))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TimeId", id);

                _con.Open();

                i = command.ExecuteNonQuery();
            }

            _con.Close();

            if (i >= 1)
            {
                return true;
            }

            return false;
        }
    }
}