using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Core.Services;
using Ecommerce.Domain.Mappers.Interfaces;
using Ecommerce.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application
{
    public class CustomerApplicationService : ICustomerApplicationService
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper<CustomerDto, Customer> _mapperEntity;
        private readonly IMapper<Customer, CustomerDto> _mapperDto;
        public CustomerApplicationService(ICustomerService customerService, IMapper<CustomerDto, Customer> mapperEntity, IMapper<Customer, CustomerDto> mapperDto)
        {
            _customerService = customerService;
            _mapperEntity = mapperEntity;
            _mapperDto = mapperDto;
        }

        public void DeleteCustomer(string id)
        {
            _customerService.DeleteCustomer(id);
        }

        public IEnumerable<CustomerDto> GetAll()
        {
            var customer = _customerService.GetCustomers();
            var customerDto = _mapperDto.Map(customer);
            return customerDto;
        }

        public CustomerDto GetCustomerById(string id)
        {
            var customer = _customerService.GetCustomerById(id);
            var customerDto = _mapperDto.Map(customer);
            return customerDto;
        }

        public void SaveCustomer(CustomerDto customerDto)
        {
            var customer = _mapperEntity.Map(customerDto);
            _customerService.SaveCustomer(customer);
        }

        public void UpdateCustomer(CustomerDto customerDto)
        {
            var customer = _mapperEntity.Map(customerDto);
            _customerService.UpdateCustomer(customer);
        }
    }
}
