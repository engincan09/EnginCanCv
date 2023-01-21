using EnginCan.Core.Utilities.Results.Abstract;
using EnginCan.Dal.EfCore.Abstract;
using EnginCan.Entity.Models.Qualifications;
using System.Linq;

namespace EnginCan.Bll.EntityCore.Abstract.Qualifications
{
    public interface  IQualificationRepository : IEntityBaseRepository<Qualification>
    {
        IDataResult<IQueryable<Qualification>> GetAllQualification();
        IDataResult<Qualification> GetById(int id);
        IResult AddQualification(Qualification skill);
        IResult UpdateQualification(Qualification skill);
        IResult DeleteQualification(int id);
    }
}
