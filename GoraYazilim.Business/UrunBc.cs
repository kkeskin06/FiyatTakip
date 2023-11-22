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
    public class UrunBc : IUrunBc
    {
        private readonly IUrunDao urunDao;

        public UrunBc(IUrunDao urunDao)
        {
            this.urunDao = urunDao;
        }

        public async Task Add(DtoUrun dto)
        {
            await urunDao.Add(dto);
        }

        public async Task Delete(int id)
        {
            await urunDao.Delete(id);
        }

        public async Task<DtoUrun> Find(int id)
        {
            return await urunDao.Find(id);
        }

        public async Task<List<DtoUrun>> GetAll()
        {
            return await urunDao.GetAll();
        }

        public async Task Update(DtoUrun dto)
        {
            await urunDao.Update(dto);
        }
    }
}
