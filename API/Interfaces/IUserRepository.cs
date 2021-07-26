using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppData user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppData>> GetUsersAsync();
        Task<AppData> GetUsersByIdAsync(int id);
        Task<AppData> GetUserByUsernameAsync(string username);
        Task<IEnumerable<memberDto>> GetMembersAync();
        Task<memberDto> GetMemberAync(string username);

        
    }
}