using Ecommerce.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Dtos
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirtDate { get; set; }
        public string Cpf { get; set; }
        public AddressDto Address { get; set; }
    }
} 