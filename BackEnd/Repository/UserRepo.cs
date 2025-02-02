using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Repository
{
    public class UserRepo : RepositoryG<Users>
    {
        private readonly InvoiceContext context;
        private DbSet<Users> dbSet;
        public UserRepo(InvoiceContext context) : base(context)
        {
            this.context = context;
            dbSet = context.Set<Users>();
        }
        public Users GetByName(string name , string password)
        {
            var result = dbSet.Where(x => x.UserName==name && x.Password==password).FirstOrDefault();
            return result;
        }
    }
}
