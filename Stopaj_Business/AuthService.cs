using System;
using System.Collections.Generic;
using System.Text;
using Stopaj_Business.Interface;
using Stopaj_Data.Entity;
using Stopaj_Data.Context;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Linq;

namespace Stopaj_Business
{
   public class AuthService:IAuthService
    {
        public AuthService(IConfiguration iConfig)
        {
            config = iConfig;
        }
        public IConfiguration config { get; set; }

        public User LoginDealer(int dealerId, string password)
        {
            User user = new User();
            using (EntityContext entityContext = new EntityContext(config))
            {
                user = entityContext.Users.FirstOrDefault(x => x.IsActive && x.DealerId == dealerId && x.Password == PasswordHasher(password) && (x.RoleId == 1) || (x.RoleId == 3));
            }
            return user;
        }

        public User LoginCallCenter(int userId, string password)
        {
            User user = new User();
            using (EntityContext entityContext = new EntityContext(config))
            {
                user = entityContext.Users.FirstOrDefault(x => x.IsActive && x.Id == userId && x.Password == PasswordHasher(password) && (x.RoleId == 2 || x.RoleId == 4));
            }
            return user;
        }

        public User GetUserByDealerId(int dealerId)
        {
            User user = new User();
            using (EntityContext entityContext = new EntityContext(config))
            {
                user = entityContext.Users.FirstOrDefault(x => x.DealerId == dealerId);
                return user;
            }
        }

        public User GetUserById(int userId)
        {
            User user = new User();
            using (EntityContext entityContext = new EntityContext(config))
            {
                user = entityContext.Users.FirstOrDefault(x => x.Id == userId);
                return user;
            }
        }

        public List<User> GetAllCallCenterUser()
        {
            using (EntityContext entityContext = new EntityContext(config))
            {
                return entityContext.Users.Where(x => x.RoleId == 1).ToList();
            }
        }

        public List<User> GetAllDealerUser()
        {
            using (EntityContext entityContext = new EntityContext(config))
            {
                return entityContext.Users.Where(x => x.RoleId == 4).ToList();
            }
        }

        public void UpdateUser(User user)
        {
            using (EntityContext entityContext = new EntityContext(config))
            {
                entityContext.Users.Update(user);
                entityContext.SaveChanges();
            }
        }

        public string RandomPassword(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        string serverKey = "deneme";
        //password ü hash leme
        public string PasswordHasher(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {

                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData + serverKey));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public void CreateBulkDealer(List<User> userList)
        {
            using (EntityContext entityContext = new EntityContext(config))
            {
                //entitycontext teki dealer id lerin listesi
                var dealerIdList = entityContext.Users.Where(x => x.DealerId != null).Select(x => x.DealerId).ToList();
                //entitycontext te olmayan id ler yeni eklenecek olarak listeleniyor
                var newUserList = userList.Where(x => !dealerIdList.Any(y => y.Value == x.DealerId)).ToList();
                //entitycontex te var olan id ler update olacak şekilde listeleniyor
                var updateUserList = userList.Where(x => dealerIdList.Any(y => y.Value == x.DealerId)).ToList();

                entityContext.AddRange(newUserList);
                entityContext.SaveChanges();

                List<User> updatedList = new List<User>();
                foreach (var i in updateUserList)
                {
                    var user = entityContext.Users.FirstOrDefault(x => x.DealerId == i.DealerId);
                    user.Address = i.Address;
                    user.City = i.City;
                    user.Email = i.Email;
                    user.Phone = i.Phone;
                    user.DealerName = i.DealerName;
                    user.FullName = i.FullName;
                    user.UpdatedDate = DateTime.Now;

                    updatedList.Add(user);
                    entityContext.SaveChanges();
                }
            }
        }

        public void CreateCallCenter(User user)
        {
            using (EntityContext entityContext = new EntityContext(config))
            {
                entityContext.Add(user);
                entityContext.SaveChanges();
            }
        }

    }
}
