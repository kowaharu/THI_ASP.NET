using Infrastructure.EF;
using Infrastructure.Entities;
using Infrastructure.Generic;

namespace Infrastructure.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
    }

    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(EXDbContext context) : base(context)
        {
        }
    }
}
