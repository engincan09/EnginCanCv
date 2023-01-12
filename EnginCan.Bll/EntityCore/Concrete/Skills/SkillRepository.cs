using EnginCan.Bll.EntityCore.Abstract.Abouts;
using EnginCan.Bll.EntityCore.Abstract.Skills;
using EnginCan.Bll.Helpers;
using EnginCan.Core.Utilities.Results.Abstract;
using EnginCan.Core.Utilities.Results.Concrete;
using EnginCan.Dal.EfCore;
using EnginCan.Dal.EfCore.Concrete;
using EnginCan.Entity.Models.Abouts;
using EnginCan.Entity.Models.Skills;
using EnginCan.Entity.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnginCan.Bll.EntityCore.Concrete.Skills
{
    public class SkillRepository : EntityBaseRepository<Skill>, ISkillRepository
    {
        public SkillRepository(EnginCanContext context) : base(context)
        {
        }

        /// <summary>
        /// Yeni yetenek kaydı oluşturur
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        public IResult AddSkill(Skill skill)
        {
            try
            {
                Add(skill);
                Commit();
                return new SuccessResult(SystemConstants.AddedMessage);
            }
            catch (Exception)
            {
                return new ErrorResult(SystemConstants.AddedErrorMessage);
            }
        }

        /// <summary>
        /// Yetenek kaydını siler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IResult DeleteSkill(int id)
        {
            var result = FindBy(a => a.Id == id).FirstOrDefault();
            if (result == null)
                return new ErrorResult(SystemConstants.NoData);

            else
            {
                try
                {
                    Delete(result);
                    Commit();
                    return new SuccessResult(SystemConstants.DeletedMessage);
                }
                catch (Exception)
                {
                    return new ErrorResult(SystemConstants.DeletedErrorMessage);
                }
            }
        }

        /// <summary>
        /// Tüm yetenekleri döndürür
        /// </summary>
        /// <returns></returns>
        public IDataResult<IQueryable<Skill>> GetAllSkill()
        {
            var result = FindBy(m => m.DataStatus == DataStatus.Activated);
            return new SuccessDataResult<IQueryable<Skill>>(result);
        }

        /// <summary>
        /// Tekil bilgisine göre yetenek döndürür
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IDataResult<Skill> GetById(int id)
        {
            var result = FindBy(m => m.Id == id && m.DataStatus == DataStatus.Activated)
                        .AsNoTracking()
                       .FirstOrDefault();

            if (result != null)
                return new SuccessDataResult<Skill>(result);
            else
                return new ErrorDataResult<Skill>(null, SystemConstants.NoData);
        }

        /// <summary>
        /// Yetenek günceller
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        public IResult UpdateSkill(Skill skill)
        {
            var hasData = FindBy(m => m.Id == skill.Id && m.DataStatus == DataStatus.Activated)
             .AsNoTracking()
                      .FirstOrDefault();
            if (hasData == null)
                return new ErrorDataResult<About>(null, SystemConstants.NoData);

            try
            {
                Update(skill);
                Commit();

                return new SuccessResult(SystemConstants.UpdatedMessage);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<About>(null, SystemConstants.UpdatedErrorMessage);
            }
        }
    }
}
