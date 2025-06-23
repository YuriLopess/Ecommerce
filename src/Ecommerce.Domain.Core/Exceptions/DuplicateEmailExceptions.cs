using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Core.Exceptions
{
    public class DuplicateEmailExceptions : Exception
    {
        public DuplicateEmailExceptions(string email) : base($"Email {email} is already in use.")
        {

        }
    }
}
