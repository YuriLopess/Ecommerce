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
        public CustomerApplicationService(ICustomerService customerService, IMapper<CustomerDto, Customer> mapperEntity)
        {
            _customerService = customerService;
            _mapperEntity = mapperEntity;
        }

        public void SaveCustomer(CustomerDto customerDto)
        {
            var customer = _mapperEntity.Map(customerDto);
            _customerService.SaveCustomer(customer);
        }
    }
}
