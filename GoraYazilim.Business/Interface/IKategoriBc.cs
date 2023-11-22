using GoraYazilim.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoraYazilim.Business.Interface
{
    public interface IKategoriBc
    {
        Task<List<DtoKategori>> GetAll();
        Task<DtoKategori> Find(int id);
        Task Add(DtoKategori dto);
        Task Update(DtoKategori dto);
        Task Delete(int id);
    }
}
