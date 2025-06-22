using Ecommerce.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        void Insert(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        IEnumerable<Customer> GetAll();
        Customer Get(int id);
    }
}
