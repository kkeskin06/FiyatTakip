using GoraYazilim.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoraYazilim.DataAccess.Interface
{
    public interface IFiyatlandirmaDao
    {
        Task<List<DtoFiyatlandirma>> GetAll();

        Task<List<DtoFiyatlandirma>> GetById(int id);
        Task<List<DtoFiyatlandirma>> GetBySaticiId(int id);
        Task<DtoFiyatlandirma> Find(int id);
        Task Add(DtoFiyatlandirma dto);
        Task Update(DtoFiyatlandirma dto);
        Task Delete(int id);
    }
}
