
using ShopMicroServices.Customers.Persistence.Models;

namespace ShopMicroServices.Customers.Persistence.MappersCustomers
{
    public static class MappersCustomers
    {
        public static CustomersModel MapToModel(Domain.Entities.Customers entity)
        {
            return new CustomersModel
            {
                CustId = entity.Id,
                CompanyName = entity.CompanyName,
                ContactName = entity.ContactName,
                ContactTitle = entity.ContactTitle,
                Address = entity.Address,
                Email = entity.Email,
                City = entity.City,
                Region = entity.Region,
                PostalCode = entity.PostalCode,
                Country = entity.Country,
                Phone = entity.Phone,
                Fax = entity.Fax
            };
        }

        public static Domain.Entities.Customers MapToEntity(SaveCustomersModel model)
        {
            Domain.Entities.Customers entity = new Domain.Entities.Customers();
            entity.Id = model.CustId;
            entity.CompanyName = model.CompanyName;
            entity.ContactName = model.ContactName;
            entity.ContactTitle = model.ContactTitle;
            entity.Address = model.Address;
            entity.Email = model.Email;
            entity.City = model.City;
            entity.Region = model.Region;
            entity.PostalCode = model.PostalCode;
            entity.Country = model.Country;
            entity.Phone = model.Phone;
            entity.Fax = model.Fax;
            return entity;
        }
        private static void MapToEntity(UpdateCustomersModel model, Domain.Entities.Customers entity)
        {
            entity.CompanyName = model.CompanyName;
            entity.ContactName = model.ContactName;
            entity.ContactTitle = model.ContactTitle;
            entity.Address = model.Address;
            entity.Email = model.Email;
            entity.City = model.City;
            entity.Region = model.Region;
            entity.PostalCode = model.PostalCode;
            entity.Country = model.Country;
            entity.Phone = model.Phone;
            entity.Fax = model.Fax;
        }
    }
}