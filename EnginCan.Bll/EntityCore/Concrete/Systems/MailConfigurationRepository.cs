using EnginCan.Bll.EntityCore.Abstract.Systems;
using EnginCan.Bll.Helpers;
using EnginCan.Core.Utilities.Results.Abstract;
using EnginCan.Core.Utilities.Results.Concrete;
using EnginCan.Dal.EfCore;
using EnginCan.Dal.EfCore.Concrete;
using EnginCan.Entity.Models.Systems;
using EnginCan.Entity.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnginCan.Bll.EntityCore.Concrete.Systems
{
    public class MailConfigurationRepository : EntityBaseRepository<MailConfiguration>, IMailConfigurationRepository
    {
        public MailConfigurationRepository(EnginCanContext context) : base(context)
        {
        }

        /// <summary>
        /// Tekil bilgisine göre sistem ayarı döndürür
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IDataResult<MailConfiguration> GetById(int id)
        {
            var result = FindBy(m => m.Id == id && m.DataStatus == DataStatus.Activated)
                         .AsNoTracking()
                        .FirstOrDefault();

            if (result != null)
                return new SuccessDataResult<MailConfiguration>(result);
            else
                return new ErrorDataResult<MailConfiguration>(null, SystemConstants.NoData);
        }    
    }
}
