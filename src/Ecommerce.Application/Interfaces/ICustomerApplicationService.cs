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
        void UpdateCustomer(CustomerDto customer);
        void DeleteCustomer(string od );
        IEnumerable<CustomerDto> GetAll(); 
        CustomerDto GetCustomerById(string id);
    }
}
