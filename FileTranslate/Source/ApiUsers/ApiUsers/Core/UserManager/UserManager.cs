using Microsoft.EntityFrameworkCore;
using ApiUsers.Data;
using ApiUsers.Helpers;
using ApiUsers.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ApiUsers.Core.UserManager
{
    public class UserManager : IUserManager
    {
        private readonly UsersContext _context;

        public UserManager(UsersContext context)
        {
            _context = context;
        }

        public async Task<ResultHelper<User>> GetByIdAsync(int id)
        {
            var resultado = new ResultHelper<User>();
            var user = await _context.Users.FirstOrDefaultAsync(s => s.Id == id);
            if (user != null)
            {
                resultado.Value = user;
            }
            else
            {
                resultado.AddError("no existe");
            }

            return resultado;
        }


        public async Task<ResultHelper<User>> CreateAsync(User user)
        {
            var resultado = new ResultHelper<User>();
            try
            {
                User nuevaUser = new User
                {
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password

                };

                _context.Users.Add(nuevaUser);
                await _context.SaveChangesAsync();

                resultado.Value = nuevaUser;
            }
            catch (Exception e)
            {
                resultado.AddError(e.Message);
            }
            return resultado;
        }

    

      


     
    }
}
