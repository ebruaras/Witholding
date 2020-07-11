using Stopaj_Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stopaj_Business.Interface
{
   public interface IAuthService
    {
        User LoginDealer(int dealerId, string password);
        User LoginCallCenter(int userId, string password);
        User GetUserByDealerId(int dealerId);
        User GetUserById(int userId);
        List<User> GetAllCallCenterUser();
        List<User> GetAllDealerUser();
        string RandomPassword(int length);
        string PasswordHasher(string password);
        void CreateBulkDealer(List<User> userList);
        void CreateCallCenter(User user);
        void UpdateUser(User user);
    }
}
