using DnsClient;
using Ecommerce.Domain.Core.Interfaces.Repositories;
using Ecommerce.Domain.Core.Services;
using Ecommerce.Domain.Core.Exceptions;
using Ecommerce.Domain.Model;
using System.Data;
using System.Net.Mail;

namespace Ecommerce.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void SaveCustomer(Customer customer)
        {
            ValidateEmail(customer.Email);
            customer.IsActive = true;
            customer.CreatedDate = DateTime.Now;
            customer.Address.CreatedDate = DateTime.Now;

            _customerRepository.Insert(customer);
        }

        private void ValidateEmail(string email)
        {
            if (!IsEmailValid(email))
            {
                throw new DuplicateEmailExceptions(email);

            }

            var existingCustomer = _customerRepository.GetByEmail(email);

            if (existingCustomer is not null)
            {
                throw new DuplicateEmailExceptions(email);
            }
        }

        private bool IsEmailValid(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            try
            {
                var emailAddress = new MailAddress(email);
                if (emailAddress.Address != email)
                {
                    return false;
                }
                return CheckDomainHasMXRecord(emailAddress.Host);
            } catch (Exception ex)
            {
            
                
            }

            return true;
        }

        private bool CheckDomainHasMXRecord(string domain)
        {
            try
            {
                var lookup = new LookupClient();
                var result = lookup.Query(domain, QueryType.MX);

                return result.Answers.MxRecords().Any();
            }

            catch (Exception)
            {
                return false;
            }

            
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.Update(customer);
        }

        public void DeleteCustomer(string id)
        {
            _customerRepository.Delete(id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetCustomerById(string id)
        {
            return _customerRepository.Get(id);
        }
    }
}
