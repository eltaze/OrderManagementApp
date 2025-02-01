using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLogic.BL
{
    public class UsersBL(IUOF uOF,
                       IMemoryCache cache,
                       IConfiguration Cofig,
                       IMapper mapper)  : IUserBL
    {
        private readonly IMapper mapper = mapper;
        private readonly IUOF uOF = uOF;
        private readonly IMemoryCache cache = cache;
 

        public async Task<bool> Add(UsersUI entity)
        {
           var user = mapper.Map<Users>(entity);
            var  result =  await uOF.User.Add(user);
            await uOF.ComplateTask();
            return result;

        }

        public Task<bool> Delete(int id)
        {
            var result =  uOF.User.Delete(id);
            return result;
        }

        public UsersUI GetByNamePassword(string username, string password)
        {
            var user = uOF.User.GetByName(username,password);
            var result = mapper.Map<UsersUI>(user);
            return result;
        }

        public Task<bool> Update(UsersUI entity)
        {
            var user = mapper.Map<Users>(entity);
            var result =  uOF.User.Update(user);
             uOF.ComplateTask();
            return result;
        }

    }
}
