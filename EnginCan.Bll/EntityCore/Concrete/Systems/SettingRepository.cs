using EnginCan.Bll.EntityCore.Abstract.Skills;
using EnginCan.Bll.EntityCore.Abstract.Systems;
using EnginCan.Bll.Helpers;
using EnginCan.Core.Utilities.Results.Abstract;
using EnginCan.Core.Utilities.Results.Concrete;
using EnginCan.Dal.EfCore;
using EnginCan.Dal.EfCore.Concrete;
using EnginCan.Entity.Models.Abouts;
using EnginCan.Entity.Models.Skills;
using EnginCan.Entity.Models.Systems;
using EnginCan.Entity.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnginCan.Bll.EntityCore.Concrete.Systems
{
    public class SettingRepository : EntityBaseRepository<Setting>, ISettingRepository
    {
        public SettingRepository(EnginCanContext context) : base(context)
        {
        }

        /// <summary>
        /// Tekil bilgisine göre sistem ayarı döndürür
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IDataResult<Setting> GetById(int id)
        {
            var result = FindBy(m => m.Id == id && m.DataStatus == DataStatus.Activated)
                         .AsNoTracking()
                        .FirstOrDefault();

            if (result != null)
                return new SuccessDataResult<Setting>(result);
            else
                return new ErrorDataResult<Setting>(null, SystemConstants.NoData);
        }

        /// <summary>
        /// Sistem ayarları güncellemesi yapar
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public IResult UpdateSetting(Setting setting)
        {
            var hasData = FindBy(m => m.Id == setting.Id && m.DataStatus == DataStatus.Activated)
             .AsNoTracking()
                      .FirstOrDefault();
            if (hasData == null)
                return new ErrorDataResult<Setting>(null, SystemConstants.NoData);

            try
            {
                Update(setting);
                Commit();

                return new SuccessResult(SystemConstants.UpdatedMessage);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Setting>(null, SystemConstants.UpdatedErrorMessage);
            }
        }
    }
}
