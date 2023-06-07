using Lerkorin.CommonsAppData.DTO;
using Lerkorin.Interface;
using Lerkorin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

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
                if (user.Password == password)
                {
                    user.ReleaseDate = DateTime.Today;
                    user.NumberOfLoginAttempts = 0; // Присваиваем значение 0
                    _context.SaveChanges();
                    return HttpStatusCode.OK;
                }
                else
                {
                    user.NumberOfLoginAttempts++;
                    _context.SaveChanges();
                }
            }

            return HttpStatusCode.Unauthorized; // Возвращаем статус 401 (Unauthorized)
        }

        public List<UserDTO> FirstOfDefault(string login, string password)
        {
            HttpStatusCode authenticationResult = Authenticate(login, password);

            if (authenticationResult == HttpStatusCode.OK)
            {
                // Получаем текущую дату и время
                DateTime currentDateTime = DateTime.Now;

                // Обновляем поле ReleaseDate для соответствующего пользователя на текущую дату и время
                Models.User user = _context.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
                if (user != null)
                {
                    user.ReleaseDate = currentDateTime;
                    _context.SaveChanges(); // Сохраняем изменения в базе данных
                }

                List<UserDTO> data = _context.Users.Include(x => x.IdRoleNavigation)
                    .Where(x => x.Login == login && x.Password == password)
                    .Select(x => new UserDTO
                    {
                        Login = x.Login,
                        Password = x.Password,
                        Role = x.IdRoleNavigation.Name,
                        ReleaseDate = currentDateTime,
                        NumberOfLoginAttempts = (int)x.NumberOfLoginAttempts
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





