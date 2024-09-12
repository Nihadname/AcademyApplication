using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApplication.DataAccess.Data.Implementations
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly AcademyAppDbContext _appDbContext;
        public IGroupRepository GroupRepository { get; private set; }

        public UnitOfWork(AcademyAppDbContext appDbContext)
        {
            GroupRepository=new GroupRepository(appDbContext);
            _appDbContext = appDbContext;
        }
        public void Commit()
        {
            _appDbContext.SaveChanges();
        }
        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
