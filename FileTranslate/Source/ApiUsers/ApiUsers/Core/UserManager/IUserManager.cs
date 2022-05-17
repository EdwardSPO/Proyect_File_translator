using ApiUsers.Helpers;
using ApiUsers.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiUsers.Core.UserManager
{
    public interface IUserManager
    {
        Task<ResultHelper<IEnumerable<User>>> GetUsersAsync();
        Task<ResultHelper<User>> GetByIdAsync(int id);
        Task<ResultHelper<User>> CreateAsync(User user);
        Task<ResultHelper<User>> LoginAsync(User user);
        Task<ResultHelper<IEnumerable<UpdateFile>>> GetListAsync();
        Task<ResultHelper<User>> GetByIdListAsync(int id);


        

    }
}