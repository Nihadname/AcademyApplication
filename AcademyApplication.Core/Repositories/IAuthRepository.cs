using AcademyApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApplication.Core.Repositories
{
    public interface IAuthRepository:IRepository<AppUser>
    {
    }
}
