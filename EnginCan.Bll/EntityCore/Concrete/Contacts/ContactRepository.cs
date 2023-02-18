using EnginCan.Bll.EntityCore.Abstract.Contacts;
using EnginCan.Bll.Helpers;
using EnginCan.Core.Utilities.Results.Abstract;
using EnginCan.Core.Utilities.Results.Concrete;
using EnginCan.Dal.EfCore;
using EnginCan.Dal.EfCore.Concrete;
using EnginCan.Entity.Models.Abouts;
using EnginCan.Entity.Models.Contacts;
using EnginCan.Entity.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EnginCan.Bll.EntityCore.Concrete.Contacts
{
    public class ContactRepository : EntityBaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(EnginCanContext context) : base(context)
        {
        }

        /// <summary>
        /// Yeni iletişim kaydı oluşturur
        /// </summary>
        /// <param name="Contact"></param>
        /// <returns></returns>
        public IResult AddContact(Contact contact)
        {
            try
            {
                Add(contact);
                Commit();
                return new SuccessResult(SystemConstants.AddedMessage);
            }
            catch (Exception)
            {
                return new ErrorResult(SystemConstants.AddedErrorMessage);
            }
        }

        /// <summary>
        /// deneyim iletişim siler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IResult DeleteContact(int id)
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
        /// Tüm iletişim döndürür
        /// </summary>
        /// <returns></returns>
        public IDataResult<IQueryable<Contact>> GetAllContact()
        {
            var result = FindBy(m => m.DataStatus == DataStatus.Activated);
            return new SuccessDataResult<IQueryable<Contact>>(result);
        }

        /// <summary>
        /// Tekil bilgisine göre iletişim döndürür
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IDataResult<Contact> GetById(int id)
        {
            var result = FindBy(m => m.Id == id && m.DataStatus == DataStatus.Activated)
                        .AsNoTracking()
                       .FirstOrDefault();

            if (result != null)
                return new SuccessDataResult<Contact>(result);
            else
                return new ErrorDataResult<Contact>(null, SystemConstants.NoData);
        }

        /// <summary>
        /// iletişim günceller
        /// </summary>
        /// <param name="Contact"></param>
        /// <returns></returns>
        public IResult UpdateContact(Contact contact)
        {
            var hasData = FindBy(m => m.Id == contact.Id && m.DataStatus == DataStatus.Activated)
             .AsNoTracking()
                      .FirstOrDefault();
            if (hasData == null)
                return new ErrorDataResult<About>(null, SystemConstants.NoData);

            try
            {
                Update(contact);
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
