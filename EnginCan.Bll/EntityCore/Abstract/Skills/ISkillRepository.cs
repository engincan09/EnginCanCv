using EnginCan.Core.Utilities.Results.Abstract;
using EnginCan.Dal.EfCore.Abstract;
using EnginCan.Entity.Models.Skills;
using EnginCan.Entity.Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnginCan.Bll.EntityCore.Abstract.Skills
{
    public interface ISkillRepository : IEntityBaseRepository<Skill>
    {
        IDataResult<IQueryable<Skill>> GetAllSkill();
        IDataResult<Skill> GetById(int id);
        IResult AddSkill(Skill skill);
        IResult UpdateSkill(Skill skill);
        IResult DeleteSkill(int id);
    }
}
