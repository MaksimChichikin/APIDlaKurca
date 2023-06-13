using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Lerkorin.CommonsAppData.DTO;
using Lerkorin.Interface;
using Lerkorin.Models;
using Microsoft.EntityFrameworkCore;

namespace Lerkorin.CommonsAppData.User
{
    public class UsersClass : IUsers
    {
        private readonly _130123_ChichikinContext _context;

        public UsersClass(_130123_ChichikinContext context)
        {
            _context = context;
        }

        public HttpStatusCode Authenticate(string login, string password)
        {
            Models.User user = _context.Users.FirstOrDefault(x => x.Login == login);
            if (user != null)
            {
                string hashedPassword = GetMd5Hash(password);

                if (user.Password == hashedPassword)
                {
                    user.IdUserActivityNavigation = _context.UserActivities.FirstOrDefault(a => a.Id == 1);

                    HistoryLog logEntry = new HistoryLog
                    {
                        UserLoginDate = DateTime.Now,
                        LoginAttempt = user.NumberOfLoginAttempts,
                        IdUser = user.Id
                    };

                    _context.HistoryLogs.Add(logEntry);
                    _context.SaveChanges();

                    user.NumberOfLoginAttempts = 0;

                    _context.SaveChanges();
                    return HttpStatusCode.OK;
                }
                else
                {
                    user.NumberOfLoginAttempts++;
                    _context.SaveChanges();
                }
            }
            return HttpStatusCode.Unauthorized;
        }

        private string GetMd5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public List<UserDTO> FirstOfDefault(string login, string password)
        {
            HttpStatusCode authenticationResult = Authenticate(login, password);

            if (authenticationResult == HttpStatusCode.OK)
            {
                List<UserDTO> data = _context.Users.Include(x => x.IdRoleNavigation)
                    .Include(x => x.IdUserActivityNavigation)
                    .Include(x => x.IdUserStatusNavigation)
                    .Where(x => x.Login == login && x.Password == GetMd5Hash(password))
                    .Select(x => new UserDTO
                    {
                        Id = x.Id,
                        Login = x.Login,
                        Role = x.IdRoleNavigation.Name,
                        Activity = x.IdUserActivityNavigation.Name,
                        IsFirstLogin = (bool)x.IsFirstLogin,
                        DateAdd = x.DateAdd.HasValue ? x.DateAdd.Value : DateTime.MinValue,
                        UserStatus = x.IdUserStatusNavigation.Name
                    })
                    .ToList();

                return data;
            }
            else
            {
                return new List<UserDTO>();
            }
        }
    }
}





