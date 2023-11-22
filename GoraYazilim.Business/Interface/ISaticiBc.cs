using GoraYazilim.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoraYazilim.Business.Interface
{
    public interface ISaticiBc
    {
        Task<List<DtoSatici>> GetAll();
        Task<List<DtoSatici>> GetById(int id);
        Task<DtoSatici> Find(int id);
        Task Add(DtoSatici dto);
        Task Update(DtoSatici dto);
        Task Delete(int id);
    }
}
