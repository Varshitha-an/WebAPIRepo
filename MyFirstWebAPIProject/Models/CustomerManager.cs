using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebAPIProject.Models
{
    public class CustomerManager : ICustomerManagementRepository<Customer>
    {
        CustomerManagementContext _context;
        public CustomerManager(CustomerManagementContext context)
        {
            _context = context;
        }
        public void Add(Customer entity)
        {
            _context.Customers.Add(entity);
            _context.SaveChanges();
            
        }

        public void Delete(int id)
        {
            _context.Customers.Remove(_context.Customers.FirstOrDefault(cust => cust.CustomerId == id));
            _context.SaveChanges();
        }

        public IEnumerable<Customer> GetAllData()
        {
           return  _context.Customers.ToList();
        }

        public Customer GetById(int id)
        {
           Customer customer= _context.Customers.FirstOrDefault(cust => cust.CustomerId == id);
            return customer;

        }

        public void Update(int id, Customer entity)
        {
           Customer cu= _context.Customers.FirstOrDefault(cust => cust.CustomerId == id);
            cu.IsOldCustomer = entity.IsOldCustomer;
            cu.Name = entity.Name;
            cu.Phone = entity.Phone;
            _context.SaveChanges();
        }
    }
}
