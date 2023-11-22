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
    public class AlturunBc : IAlturunBc
    {
        private readonly IAlturunDao alturunDao;

        public AlturunBc(IAlturunDao alturunDao)
        {
            this.alturunDao = alturunDao;
        }
        public async Task Add(DtoAltUrun dto)
        {
           await alturunDao.Add(dto);
        }

        public async Task Delete(int id)
        {
            await alturunDao.Delete(id);
        }

        public async Task<DtoAltUrun> Find(int id)
        {
            return await alturunDao.Find(id);
        }

        public async Task<List<DtoAltUrun>> GetAll()
        {
            return await alturunDao.GetAll();
        }

        public async Task<List<DtoAltUrun>> GetById(int id)
        {
            return await alturunDao.GetById(id);
        }

        public async Task Update(DtoAltUrun dto)
        {
            await alturunDao.Update(dto);
        }
    }
}
