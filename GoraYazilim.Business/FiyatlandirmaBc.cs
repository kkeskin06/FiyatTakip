using GoraYazilim.Business.Interface;
using GoraYazilim.DataAccess.Interface;
using GoraYazilim.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoraYazilim.Business
{
    public class FiyatlandirmaBc : IFiyatlandirmaBc
    {
        private readonly IFiyatlandirmaDao fiyatlandirmaDao;

        public FiyatlandirmaBc(IFiyatlandirmaDao fiyatlandirmaDao)
        {
            this.fiyatlandirmaDao = fiyatlandirmaDao;
        }
        public async Task Add(DtoFiyatlandirma dto)
        {
            await fiyatlandirmaDao.Add(dto);
        }

        public async Task Delete(int id)
        {
            await fiyatlandirmaDao.Delete(id);
        }

        public async Task<DtoFiyatlandirma> Find(int id)
        {
            return await fiyatlandirmaDao.Find(id);
        }

        public async Task<List<DtoFiyatlandirma>> GetAll()
        {
            return await fiyatlandirmaDao.GetAll();
        }

        public async Task<List<DtoFiyatlandirma>> GetById(int id)
        {
            return await fiyatlandirmaDao.GetById(id);
        }

        public async Task<List<DtoFiyatlandirma>> GetBySaticiId(int id)
        {
            return await fiyatlandirmaDao.GetBySaticiId(id);
        }

        public async Task Update(DtoFiyatlandirma dto)
        {
            await fiyatlandirmaDao.Update(dto);
        }
    }
}
