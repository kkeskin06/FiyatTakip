using GoraYazilim.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoraYazilim.Business.Interface
{
    public interface IAlturunBc
    {
        Task<List<DtoAltUrun>> GetAll();

        Task<List<DtoAltUrun>> GetById(int id);
        Task<DtoAltUrun> Find(int id);
        Task Add(DtoAltUrun dto);
        Task Update(DtoAltUrun dto);
        Task Delete(int id);
    }
}
