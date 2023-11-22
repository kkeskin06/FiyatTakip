using GoraYazilim.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoraYazilim.DataAccess.Interface
{
    public interface IUserDao
    {
        Task<List<DtoUser>> GetAll();
    }
}
