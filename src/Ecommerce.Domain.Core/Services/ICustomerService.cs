using Ecommerce.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Core.Services
{
    public interface ICustomerService
    {
        void SaveCustomer(Customer customer);
    }
}
