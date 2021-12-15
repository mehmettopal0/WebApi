using Core.DataAccess;
using Core.Utilities.Results;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEmployeeDal : IEntityRepository<Employee>
    {
        List<Employee> GetAllChildByParent(int parentId);
        IResult AddTree(Employee entity);
        void TreeDelete(int id);
    }
}
