using EnginCan.Bll.EntityCore.Abstract.Qualifications;
using EnginCan.Bll.Helpers;
using EnginCan.Core.Utilities.Results.Abstract;
using EnginCan.Core.Utilities.Results.Concrete;
using EnginCan.Dal.EfCore;
using EnginCan.Dal.EfCore.Concrete;
using EnginCan.Entity.Models.Abouts;
using EnginCan.Entity.Models.Qualifications;
using EnginCan.Entity.Models.Qualifications;
using EnginCan.Entity.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnginCan.Bll.EntityCore.Concrete.Qualifications
{
    public class QualificationRepository : EntityBaseRepository<Qualification>,IQualificationRepository
    {
        public QualificationRepository(EnginCanContext context) : base(context)
        {
        }
        /// <summary>
        /// Yeni deneyim kaydı oluşturur
        /// </summary>
        /// <param name="Qualification"></param>
        /// <returns></returns>
        public IResult AddQualification(Qualification Qualification)
        {
            try
            {
                Add(Qualification);
                Commit();
                return new SuccessResult(SystemConstants.AddedMessage);
            }
            catch (Exception)
            {
                return new ErrorResult(SystemConstants.AddedErrorMessage);
            }
        }

        /// <summary>
        /// deneyim kaydını siler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IResult DeleteQualification(int id)
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
        /// Tüm deneyimleri döndürür
        /// </summary>
        /// <returns></returns>
        public IDataResult<IQueryable<Qualification>> GetAllQualification()
        {
            var result = FindBy(m => m.DataStatus == DataStatus.Activated);
            return new SuccessDataResult<IQueryable<Qualification>>(result);
        }

        /// <summary>
        /// Tekil bilgisine göre deneyim döndürür
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IDataResult<Qualification> GetById(int id)
        {
            var result = FindBy(m => m.Id == id && m.DataStatus == DataStatus.Activated)
                        .AsNoTracking()
                       .FirstOrDefault();

            if (result != null)
                return new SuccessDataResult<Qualification>(result);
            else
                return new ErrorDataResult<Qualification>(null, SystemConstants.NoData);
        }

        /// <summary>
        /// deneyim günceller
        /// </summary>
        /// <param name="Qualification"></param>
        /// <returns></returns>
        public IResult UpdateQualification(Qualification Qualification)
        {
            var hasData = FindBy(m => m.Id == Qualification.Id && m.DataStatus == DataStatus.Activated)
             .AsNoTracking()
                      .FirstOrDefault();
            if (hasData == null)
                return new ErrorDataResult<About>(null, SystemConstants.NoData);

            try
            {
                Update(Qualification);
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
