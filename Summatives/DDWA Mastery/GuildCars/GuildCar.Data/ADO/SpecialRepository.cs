using Dapper;
using GuildCar.Data.Interfaces;
using GuildCars.Model;
using GuildCars.Model.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCar.Data.ADO
{
    public class SpecialRepository: ISpecialRepository
    {

        public IEnumerable<Special> GetSpecials()
        {
                List<Special> specialList = new List<Special>();

                using (var cn = new SqlConnection(Settings.GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("GetSpecials");
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Special currentRow = new Special();
                            currentRow.SpecialDesc = dr["SpecialDesc"].ToString();
                            currentRow.SpecialId = (int)dr["SpecialId"];
                            currentRow.SpecialTitle = dr["SpecialTitle"].ToString();

                            specialList.Add(currentRow);
                        }

                        return specialList;
                    }
                }
        }

        public void InsertSpecial(Special special)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InsertSpecial", cn);
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                var param = new DynamicParameters();
                param.Add("@SpecialId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                param.Add("@SpecialTitle", special.SpecialTitle);
                param.Add("@SpecialDesc", special.SpecialDesc);

                cn.Execute("InsertSpecial", param, commandType: CommandType.StoredProcedure);

                special.SpecialId = param.Get<int>("@SpecialId");
            }
        }

        public void DeleteSpecials(int specialId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteSpecial");
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SpecialId", specialId);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }


    }
}
