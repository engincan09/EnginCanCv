using EnginCan.Core.Utilities.Results.Abstract;
using EnginCan.Dal.EfCore.Abstract;
using EnginCan.Entity.Models.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnginCan.Bll.EntityCore.Abstract.Systems
{
    public interface ISettingRepository : IEntityBaseRepository<Setting>
    {
        IDataResult<Setting> GetById(int id);
        IResult UpdateSetting(Setting setting);
    }
}
