using Dapper;
using GuildCar.Data.Interfaces;
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
    public class UsersRepository :IUsersRepository
    {

        public IEnumerable<UsersItem> GetAllUsers()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllUsers");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;

                List<UsersItem> users = new List<UsersItem>();

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    
                    while (dr.Read())
                    {
                        UsersItem user = new UsersItem();
                        user.Email = dr["Email"].ToString();
                        user.EmailConfirmed = dr["EmailConfirmed"].ToString();
                        user.AccessFailedCount = (int)dr["AccessFailedCount"];
                        user.FirstName = dr["FirstName"].ToString();
                        user.LastName = dr["LastName"].ToString();
                        user.LockoutEnabled = Convert.ToBoolean(dr["LockoutEnabled"]);
                        user.PasswordHash = dr["PasswordHash"].ToString();
                        user.PhoneNumberConfirmed = Convert.ToBoolean(dr["PhoneNumberConfirmed"]);
                        user.Role = dr["RoleId"].ToString();
                        user.TwoFactorEnabled = Convert.ToBoolean(dr["TwoFactorEnabled"]);
                        user.UserId = dr["UserId"].ToString();
                        user.UserName = dr["UserName"].ToString();

                        users.Add(user);
                    }
                }

                return users;
            }
        }

        public void InsertUser(UsersItem user)
        {

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InsertUser");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;

                List<UsersItem> users = new List<UsersItem>();

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    var param = new DynamicParameters();
                    param.Add("@UserId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    param.Add("@Email", user.Email);
                    param.Add("@EmailConfirmed", user.EmailConfirmed);
                    param.Add("@AccessFailedCount", user.AccessFailedCount);
                    param.Add("@FirstName", user.FirstName);
                    param.Add("@LastName", user.LastName);
                    param.Add("@LockOutEnable", user.LockoutEnabled);
                    param.Add("@PasswordHash", user.PasswordHash);
                    param.Add("@PhoneNumberConfirmed", user.PhoneNumberConfirmed);
                    param.Add("@RoleId", user.Role);
                    param.Add("@TwoFactorEnabled", user.TwoFactorEnabled);
                    param.Add("@UserName", user.UserName);


                    cn.Execute("InsertUser", param, commandType: CommandType.StoredProcedure);
                }
            }
        }

        public void UpdateUser(UsersItem user)
        {

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UpdateUser");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;

                List<UsersItem> users = new List<UsersItem>();

                cn.Open();

                    var param = new DynamicParameters();
                    param.Add("@UserId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    param.Add("@Email", user.Email);
                    param.Add("@EmailConfirmed", user.EmailConfirmed);
                    param.Add("@AccessFailedCount", user.AccessFailedCount);
                    param.Add("@FirstName", user.FirstName);
                    param.Add("@LastName", user.LastName);
                    if(user.Role == "disabled")
                    {
                        param.Add("@LockoutEnabled", 1);
                    }
                    else
                    {
                        param.Add("@LockoutEnabled", 0);
                    }
                    param.Add("@PasswordHash", user.PasswordHash);
                    param.Add("@PhoneNumberConfirmed", user.PhoneNumberConfirmed);
                    param.Add("@RoleId", user.Role);
                    param.Add("@TwoFactorEnabled", user.TwoFactorEnabled);
                    param.Add("@UserName", user.UserName);


                    cn.Execute("UpdateUser", param, commandType: CommandType.StoredProcedure);
            }

            
        }

        public void UpdatePassword(UsersItem user)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllUsers");
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;

                List<UsersItem> users = new List<UsersItem>();

                cn.Open();

                    var param = new DynamicParameters();

                param.Add("@UserId", user.UserId);
                param.Add("@PasswordHash", user.PasswordHash);

                    cn.Execute("UpdateUser", param, commandType: CommandType.StoredProcedure);

            }

                
        }
    }
}
