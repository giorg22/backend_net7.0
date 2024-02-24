using Domain.Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IUserRepository
    {
        Task<QueryResponse<User>> GetUserById(string id);
        Task<CommandResponse> UpdateUser(User user);
    }
}
