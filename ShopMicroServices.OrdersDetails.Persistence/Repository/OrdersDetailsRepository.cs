using ShopMicroServices.OrdersDetails.Domain.Interfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopMicroServices.OrdersDetails.Persistence.Context;
using ShopMicroServices.OrdersDetails.Persistence.Exceptions;

namespace ShopMicroServices.OrdersDetails.Persistence.Repository
{
    public class OrdersDetailsRepository : IOrdersDetailsRepository
    {
        private readonly OrdersDetailsContext _context;
        private readonly ILogger<OrdersDetailsRepository> _logger;

        public OrdersDetailsRepository(OrdersDetailsContext context, ILogger<OrdersDetailsRepository> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        public bool Exists(Expression<Func<Domain.Entities.OrdersDetails, bool>> filter)
        {
            return _context.SalesOrdersDetails.Any(filter);
        }

        public List<Domain.Entities.OrdersDetails> GetAll()
        {
            return _context.SalesOrdersDetails.ToList();
        }

        public Domain.Entities.OrdersDetails GetEntityBy(int Id)
        {
            try
            {
                var orderDetail = _context.SalesOrdersDetails.Find(Id);

                if (orderDetail is null)
                    throw new OrdersDetailsExeptions("Order not found.");

                return orderDetail;
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obtainig the details of order.");
                throw;
            }
        }

        public void Remove(Domain.Entities.OrdersDetails entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentException("The entity orders cannot be null.");

                var orderDetail = _context.SalesOrdersDetails.Find(entity.Id);

                if (orderDetail is null)
                {
                    throw new OrdersDetailsExeptions("The order detail you want to delete is not found.");
                }

                _context.SalesOrdersDetails.Remove(orderDetail);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error eliminando el detalle de orden.", ex.ToString());
            }
        }

        public void Save(Domain.Entities.OrdersDetails entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentException("La entidad order details no puede ser nula.");

                if (Exists(co => co.Id == entity.Id))
                    throw new OrdersDetailsExeptions("El detalle de orden no se encuentra.");
                
                _context.SalesOrdersDetails.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error guardando el detalle de orden.", ex.ToString());
                throw;
            }
        }

        public void Update(Domain.Entities.OrdersDetails entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentException("La entidad no puede ser nula.");
                
                var orderDetailToUpdate = this._context.SalesOrdersDetails.Find(entity.Id);
                
                if (orderDetailToUpdate is null)
                    throw new OrdersDetailsExeptions("El detalle de la orden que desea actualizar no se encuentra registrado.");
                
                orderDetailToUpdate.Id = entity.Id;
                orderDetailToUpdate.ProductId = orderDetailToUpdate.ProductId;
                orderDetailToUpdate.UnitPrice = orderDetailToUpdate.UnitPrice;
                orderDetailToUpdate.Qty = orderDetailToUpdate.Qty;
                orderDetailToUpdate.Discount = orderDetailToUpdate.Discount;

                _context.Entry(orderDetailToUpdate).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error eliminando el detalle de orden.", ex.ToString());
                throw;
            }
        }
    }
}