using Ecommerce.Application.Dtos;
using Ecommerce.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Interfaces
{
    public interface ICustomerApplicationService
    {
        void SaveCustomer(CustomerDto customer);
    }
}
