using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApplication.Application.Exceptions
{
    public class DublicateException:Exception
    {
        public DublicateException(){}
        public DublicateException(string message) : base(message){}
    }
}
