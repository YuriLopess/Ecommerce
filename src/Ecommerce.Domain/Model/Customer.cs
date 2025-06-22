using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Model
{
    public class Customer
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirtDate { get; set; }
        public string Cpf { get; set; }
        public Address Address { get; set; }
        public bool IsActive { get; set; }

    }
}
