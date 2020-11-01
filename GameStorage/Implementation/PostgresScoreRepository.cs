using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStorage
{
    public class PostgresScoreRepository : IScoreRepository
    {
        public List<ScoreModel> GetAll()
        {
            var result = new List<ScoreModel>();
           using NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Username=postgres;Password=perviz;Database=testdatabase");
            con.Open();
            NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM score Order by second ASC; ", con);
            NpgsqlDataReader rdr = com.ExecuteReader();
            while(rdr.Read())
            {
                ScoreModel scoremodel = new ScoreModel();

                var NameOrdinal = rdr.GetOrdinal("username");
               scoremodel.Username = rdr.GetString(NameOrdinal);

                var secondOrdinal = rdr.GetOrdinal("second");
                scoremodel.Second = rdr.GetInt32(secondOrdinal);
                
                var DateTimeOrdinal = rdr.GetOrdinal("time");
                scoremodel.DateTime = rdr.GetDateTime(DateTimeOrdinal);

                result.Add(scoremodel);
            }
           
            // get alla scores from Database

            return result;
        }


        public void Insert(ScoreModel score)
        {
            using var con = new NpgsqlConnection("Host=localhost;Username=postgres;Password=perviz;Database=testdatabase");
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand("INSERT into score  (username, second ,time) values('" + score.Username + "','" + score.Second + "','" + score.DateTime + "')", con);
            command.ExecuteNonQuery();
        }
    }
}
