using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLogic.Interface
{
    public interface IUserBL
    {
        Task<bool> Add(UsersUI entity);
        UsersUI GetByNamePassword(string username,string password);
        Task<bool> Update(UsersUI entity);
        Task<bool> Delete(int id);

    }
}
