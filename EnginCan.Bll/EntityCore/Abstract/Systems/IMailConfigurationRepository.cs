using EnginCan.Core.Utilities.Results.Abstract;
using EnginCan.Dal.EfCore.Abstract;
using EnginCan.Entity.Models.Systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnginCan.Bll.EntityCore.Abstract.Systems
{
    public interface IMailConfigurationRepository : IEntityBaseRepository<MailConfiguration>
    {
        IDataResult<MailConfiguration> GetById(int id);
    }
}
