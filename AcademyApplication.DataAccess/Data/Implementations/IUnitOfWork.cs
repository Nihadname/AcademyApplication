using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApplication.DataAccess.Data.Implementations
{
    public interface IUnitOfWork
    {
        public IGroupRepository GroupRepository { get; }
        public void Commit();
    }
}
