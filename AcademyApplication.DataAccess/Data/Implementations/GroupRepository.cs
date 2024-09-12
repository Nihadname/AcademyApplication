using AcademyApplication.Core.Entities;
using AcademyApplication.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApplication.DataAccess.Data.Implementations
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(AcademyAppDbContext context) : base(context)
        {
        }
    }
}
