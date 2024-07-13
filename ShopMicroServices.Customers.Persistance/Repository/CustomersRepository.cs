
using ShopMicroServices.Customers.Domain.Interfaces;
using ShopMicroServices.Customers.Persistence.Context;
using ShopMicroServices.Customers.Persistence.Exceptions;

using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;


namespace ShopMicroServices.Customers.Persistence.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly CustomersContext _Context;
        private readonly ILogger<CustomersRepository> _Logger;

        public CustomersRepository(CustomersContext context, ILogger<CustomersRepository> logger)
        {
            this._Context = context;
            this._Logger = logger;
        }

        public bool Exists(Expression<Func<Domain.Entities.Customers, bool>> filter)
        {
            return _Context.SalesCustomers.Any(filter);
        }

        public List<Domain.Entities.Customers> GetAll()
        {
            return _Context.SalesCustomers.ToList();
        }

        public List<Domain.Entities.Customers> GetCustomersByNameCompany(string CompanyName)
        {
            return _Context.SalesCustomers
                           .Where(c => c.CompanyName == CompanyName)
                           .ToList();
        }

        public Domain.Entities.Customers GetEntityBy(int Id)
        {
            try
            {
                var customer = _Context.SalesCustomers.Find(Id);

                if (customer is null)
                    throw new CustomersExeptions("Cust not found.");

                return customer;
            }
            catch (Exception ex)
            {
                this._Logger.LogError("Error obtaining the customer.");
                throw; // Se relanza la exepcion (Me daba un error sin esto).
            }
        }

        public void Remove(Domain.Entities.Customers entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentException("the entity customer cannot be null.");

                var customerstoRemove = this._Context.SalesCustomers.Find(entity.Id);

                if (customerstoRemove is null)
                    throw new CustomersExeptions("The customer you want to delete is not found.");

                // espercificos o campos de auditoria .
                _Context.SalesCustomers.Remove(entity);
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                this._Logger.LogError("Error removiendo el customer.", ex.ToString());
            }
        }

        public void Save(Domain.Entities.Customers entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentException("the entity customer cannot be null.");

                if (Exists(co => co.Id == entity.Id))
                    throw new CustomersExeptions("El customer no se encuentra registrado.");

                _Context.SalesCustomers.Add(entity);
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                this._Logger.LogError("Error agregando el customer.", ex.ToString());
                throw;
            }
        }

        public void Update(Domain.Entities.Customers entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentException("The entity customer cannot be null.");

                var customersToUpdate = this._Context.SalesCustomers.Find(entity.Id);

                if (customersToUpdate is null)
                    throw new CustomersExeptions("El customer que desea actualizar no se encuentra registrado.");

                customersToUpdate.CompanyName = entity.CompanyName;
                customersToUpdate.ContactName = entity.ContactName;
                customersToUpdate.ContactTitle = entity.ContactTitle;
                customersToUpdate.Address = entity.Address;
                customersToUpdate.Email = entity.Email;
                customersToUpdate.City = entity.City;
                customersToUpdate.Region = entity.Region;
                customersToUpdate.PostalCode = entity.PostalCode;
                customersToUpdate.Country = entity.Country;
                customersToUpdate.Phone = entity.Phone;
                customersToUpdate.Fax = entity.Fax;

                _Context.Entry(customersToUpdate).State = EntityState.Modified;
                _Context.SaveChanges();
            }
            catch(Exception ex)
            {
                _Logger.LogError("Error updating the customer.", ex);
                throw;
            }

        }
    }
}