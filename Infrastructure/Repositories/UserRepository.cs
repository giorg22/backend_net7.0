using Domain.Entities;
using Domain.IRepository;
using Infrastructure.DB;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.ResultExtensionMethods;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataCotext)
        {
            _dataContext = dataCotext;
        }

        public async Task<QueryResponse<User>> GetUserById(string id)
        {
            return await Ok(await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<CommandResponse> UpdateUser(User user)
        {
            _dataContext.Update(user);
            await _dataContext.SaveChangesAsync();
            return await Ok();
        }
    }
}
