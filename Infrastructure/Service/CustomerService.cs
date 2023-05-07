using Infrastructure.Entities;
using Infrastructure.Repository;
using System.Linq;

namespace Infrastructure.Service
{
    public interface ICustomerService
    {
        IQueryable<Customer> GetCustomers();
        Customer GetCustomer(int id);
        void InsertCustomer(Customer Customer);
        void UpdateCustomer(Customer Customer);
        void DeleteCustomer(Customer Customer);
    }

    public class CustomerService : ICustomerService
    {
        private ICustomerRepository CustomerRepository;

        public CustomerService(ICustomerRepository CustomerRepository)
        {
            this.CustomerRepository = CustomerRepository;
        }

        public IQueryable<Customer> GetCustomers()
        {
            return CustomerRepository.GetAll();
        }

        public Customer GetCustomer(int id)
        {
            return CustomerRepository.GetById(id);
        }

        public void InsertCustomer(Customer Customer)
        {
            CustomerRepository.Insert(Customer);
        }

        public void UpdateCustomer(Customer Customer)
        {
            CustomerRepository.Update(Customer);
        }

        public void DeleteCustomer(Customer Customer)
        {
            CustomerRepository.Delete(Customer);
        }
    }
}
