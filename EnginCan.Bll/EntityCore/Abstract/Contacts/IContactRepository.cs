using EnginCan.Core.Utilities.Results.Abstract;
using EnginCan.Dal.EfCore.Abstract;
using EnginCan.Dto.Contacts;
using EnginCan.Entity.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnginCan.Bll.EntityCore.Abstract.Contacts
{
    public interface IContactRepository : IEntityBaseRepository<Contact>
    {
        IDataResult<IQueryable<Contact>> GetAllContact();
        IDataResult<Contact> GetById(int id);
        IResult AddContact(Contact contact);
        IResult UpdateContact(Contact contact);
        IResult DeleteContact(int id);
        IResult PostResponse(ResponseDto responseDto);

    }
}
