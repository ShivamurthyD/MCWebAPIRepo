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
        User GetUser(string mobile);
        void CreateUser(UserRequest userRequest);
        bool EmailMobilVerification(string email, string mobile);
        void DeleteUser(string mobile);
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

        public void DeleteUser(string mobile)
        {
            var findUser = dataContext.Users.SingleOrDefault(x => x.Mobile == mobile);
            if(findUser==null)
            {
                throw new AppException($"Mobile number {mobile} not exists in the record");
            }
            else
            {
                dataContext.Users.Remove(findUser);
                dataContext.SaveChanges();
            }
        }

        public bool EmailMobilVerification(string email, string mobile)
        {
            var userverification = dataContext.Users.SingleOrDefault(x => x.Mobile == mobile);
            if (userverification != null)
            {
                userverification.Mobilverfied = true;
                userverification.Emailverified = true;
                userverification.Status = true;
                dataContext.SaveChanges();
                return true;
            }
            else
            {
                throw new AppException($"Entered Email : {email}  and Entered Mobile num : {mobile} Not valid");
            }
                
        }

        public User GetUser(string mobile)
        {
            var user = dataContext.Users.SingleOrDefault(x => x.Mobile == mobile);
            if (user == null) throw new KeyNotFoundException("User record not found!");
            return user;
        }
    }
}
