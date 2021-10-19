using MaxCleanAPI.DTO;
using MaxCleanAPI.Entity;
using MaxCleanAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCryptNet=BCrypt.Net.BCrypt;

namespace MaxCleanAPI.Service
{
    public interface IUserService
    {
        User GetUser(int ID);
        void CreateUser(UserRequest userRequest);
    }
    public class UserService : IUserService
    {
        private DataContext dataContext;
        public UserService(DataContext DataContext)
        {
            dataContext = DataContext;
        }

        public void CreateUser(UserRequest userRequest)
        {
            if (dataContext.Users.Any(x => x.Email == userRequest.Email || x.Mobile == userRequest.Mobil && x.Status == true))
            {
                throw new AppException($"User Email :{userRequest.Email} or Mobile : {userRequest.Mobil} already exist.");
            }
            User user = new User()
            {
                createddate = DateTime.Now,
                Email = userRequest.Email,
                Emailverified = false,
                firstname = userRequest.firstname,
                lastname = userRequest.lastname,
                Mobile = userRequest.Mobil,
                Mobilverfied = false,
                Password = userRequest.Password,
                Status = true,
                updateddate = DateTime.Now,
            };

            user.Password = BCryptNet.EnhancedHashPassword(userRequest.Password);

            dataContext.Users.Add(user);
            dataContext.SaveChanges();
           
        }

        public User GetUser(int ID)
        {
            var user = dataContext.Users.Find(ID);
            if (user == null) throw new KeyNotFoundException("User record not found!");
            return user;
        }
    }
}
