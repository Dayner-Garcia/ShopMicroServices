using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopMicroServices.Orders.Domain.Interfaces;
using ShopMicroServices.Orders.Persistence.Context;
using ShopMicroServices.Orders.Persistence.Exceptions;
using System.Linq.Expressions;

namespace ShopMicroServices.Orders.Persistence.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly OrdersContext _context;
        private readonly ILogger<OrdersRepository> _Logger;

        public OrdersRepository(OrdersContext context, ILogger<OrdersRepository> logger)
        {
            this._context = context;
            this._Logger = logger;
            
        }
        public bool Exists(Expression<Func<Domain.Entities.Orders, bool>> filter)
        {
           return _context.SalesOrders.Any(filter);
        }

        public List<Domain.Entities.Orders> GetAll()
        {
            return _context.SalesOrders.ToList();
        }

        public Domain.Entities.Orders GetEntityBy(int Id)
        {
            try
            {
                var order = _context.SalesOrders.Find(Id);

                if (order is null)
                    throw new OrdersExeptions("Order not found.");

                return order;
            }
            catch (Exception ex)
            {
                this._Logger.LogError("Error Obtaining the Order.");
                throw;
            }
        }

        public void Remove(Domain.Entities.Orders entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentException("The entity orders cannot be null.");

                var order = _context.SalesOrders.Find(entity.Id);

                if (order is null)
                    throw new OrdersExeptions("The order you want to delete is not found.");

                _context.SalesOrders.Remove(order);
                _context.SaveChanges();
            }
            catch (Exception ex) 
            {
                this._Logger.LogError("Error removiendo la orden.", ex.ToString());
            }
        }

        public void Save(Domain.Entities.Orders entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentException("The entity order cannot be null.");

                if (Exists(co => co.Id == entity.Id))
                    throw new OrdersExeptions("La orden no se encuentra.");

                _context.SalesOrders.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                this._Logger.LogError("Error agregando la orden.", ex.ToString());
                throw;
            }
        }

        public void Update(Domain.Entities.Orders entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentException("La entidad orders no puede ser nula.");

                var orderToUpdate = this._context.SalesOrders.Find(entity.Id);

                if (orderToUpdate is null)
                    throw new OrdersExeptions("La orden que desea actualizar no se enecuentra registrada.");

                orderToUpdate.CustId = entity.CustId;
                orderToUpdate.EmpId = entity.EmpId;
                orderToUpdate.OrderDate = entity.OrderDate;
                orderToUpdate.RequiredDate = entity.RequiredDate;
                orderToUpdate.ShippedDate = entity.ShippedDate;
                orderToUpdate.ShipperId = entity.ShipperId;
                orderToUpdate.Freight = entity.Freight;
                orderToUpdate.ShipName = entity.ShipName;
                orderToUpdate.ShipAddress = entity.ShipAddress;
                orderToUpdate.ShipCity = entity.ShipCity;
                orderToUpdate.ShipRegion = entity.ShipRegion;
                orderToUpdate.ShipPostalCode = entity.ShipPostalCode;
                orderToUpdate.ShipCountry = entity.ShipCountry;

                _context.Entry(orderToUpdate).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                _Logger.LogError("Error actualizando la orden.", ex.ToString());
                throw;
            }
        }
    }
}