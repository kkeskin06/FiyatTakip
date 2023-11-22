using GoraYazilim.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoraYazilim.DataAccess.Interface
{
    public interface ISaticiDao
    {
        Task<List<DtoSatici>> GetAll();
        Task<List<DtoSatici>> GetById(int id);
        Task<DtoSatici> Find(int id);
        Task Add(DtoSatici dto);
        Task Update(DtoSatici dto);
        Task Delete(int id);
    }
}
