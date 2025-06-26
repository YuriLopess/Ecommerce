using Ecommerce.Application.Dtos;
using Ecommerce.Domain.Mappers.Interfaces;
using Ecommerce.Domain.Model;

namespace Ecommerce.Application.Mappers
{
    public class CustomerMapper : IMapper<Customer, CustomerDto>, IMapper<CustomerDto, Customer>
    {
        public CustomerDto Map(Customer source)
        {
            return new CustomerDto
            {
                Name = source.Name,
                LastName = source.LastName,
                Email = source.Email,
                BirtDate = source.BirtDate,
                Address = new AddressDto
                {
                    Street = source.Address.Street,
                    City = source.Address.City,
                    PostalCode = source.Address.PostalCode,
                    Number = source.Address.Number,
                    State = source.Address.State,
                },
                Cpf = source.Cpf,
            };
        }

        public Customer Map(CustomerDto source)
        {
            return new Customer
            { 
                Name = source.Name,
                LastName = source.LastName,
                Email = source.Email,
                BirtDate = source.BirtDate,
                Address = new Address
                {
                    Street = source.Address.Street,
                    City = source.Address.City,
                    PostalCode = source.Address.PostalCode,
                    Number = source.Address.Number,
                    State = source.Address.State,
                },
                Cpf = source.Cpf
            };

        }

        public IEnumerable<CustomerDto> Map(IEnumerable<Customer> source)
        {
            foreach (var item in source)
            {
                yield return Map(item);
            }
        }

        public IEnumerable<Customer> Map(IEnumerable<CustomerDto> source)
        {
            foreach (var item in source)
            {
                yield return Map(item);
            }
        }
    } 
}
