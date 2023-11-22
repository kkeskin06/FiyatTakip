using GoraYazilim.DataAccess.Interface;
using GoraYazilim.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoraYazilim.DataAccess
{
    public class UserDao : IUserDao
    {
        public Task<List<DtoUser>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
