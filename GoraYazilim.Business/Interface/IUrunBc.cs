using GoraYazilim.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoraYazilim.Business.Interface
{
    public interface IUrunBc
    {
        Task<List<DtoUrun>> GetAll();
        Task<DtoUrun> Find(int id);
        Task Add(DtoUrun dto);
        Task Update(DtoUrun dto);
        Task Delete(int id);
    }
}
