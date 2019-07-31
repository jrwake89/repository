using GuildCar.Data.Interfaces;
using GuildCars.Model.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCar.Data.Mock_Repository
{
    public class MockUsersRepository :IUsersRepository
    {
        private static List<UsersItem> _users = new List<UsersItem>()
        {
            new UsersItem {UserName = "admin@test.com", Email = "admin@test.com", EmailConfirmed = "admin@test.com", PasswordHash="Testing1!", PhoneNumberConfirmed = true, AccessFailedCount= 0, LockoutEnabled = false, Role ="admin", TwoFactorEnabled=false, FirstName = "admin", LastName = "Test", UserId = "514957c5-1882-49ee-8e26-e516367fde69"}
        };

        public IEnumerable<UsersItem> GetAllUsers()
        {
            return _users;
        }

        public void InsertUser(UsersItem user)
        {
            _users.Add(user);
        }

        public void UpdateUser(UsersItem user)
        {
            _users.Where(u => u.UserId == user.UserId);

        }
    }
}
