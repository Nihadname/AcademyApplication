using AcademyApplication.Core.Entities;
using AcademyApplication.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApplication.DataAccess.Data.Implementations
{
    public class AuthRepository : Repository<AppUser>, IAuthRepository
    {
        public AuthRepository(AcademyAppDbContext context) : base(context)
        {
        }
    }
}
