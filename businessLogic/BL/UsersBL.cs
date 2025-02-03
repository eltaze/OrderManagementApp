using AutoMapper;
using businessLogic.Interface;
using BackEnd.Model;
using DataBack.Model;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace businessLogic.BL
{
    public class UsersBL : IUserBL
    {
        private readonly IMapper _mapper;
        private readonly IUOF _uOF;
        private readonly IMemoryCache _cache;

        public UsersBL(IUOF uOF, IMemoryCache cache, IConfiguration config, IMapper mapper)
        {
            _mapper = mapper;
            _uOF = uOF;
            _cache = cache;
        }

        public async Task<bool> Add(UsersUI entity)
        {
            var user = _mapper.Map<Users>(entity);
            var result = await _uOF.User.Add(user);
            await _uOF.ComplateTask();
            return result;
        }

        public Task<bool> Delete(int id)
        {
            return _uOF.User.Delete(id);
        }

        public UsersUI GetByNamePassword(string username, string password)
        {
            var user = _uOF.User.GetByName(username, password);
            return _mapper.Map<UsersUI>(user);
        }

        public Task<bool> Update(UsersUI entity)
        {
            var user = _mapper.Map<Users>(entity);
            var result = _uOF.User.Update(user);
            _uOF.ComplateTask();  // Since it's async, you might want to await this too
            return result;
        }
    }
}
