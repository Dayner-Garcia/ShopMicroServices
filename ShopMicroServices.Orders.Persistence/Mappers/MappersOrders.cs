

using ShopMicroServices.Orders.Domain.Entities;
using ShopMicroServices.Orders.Persistence.Models;
using System.Net;

namespace ShopMicroServices.Orders.Persistence.Mappers
{
    public static class MappersOrders
    {
        public static GetOrdersModel MapToModel(Domain.Entities.Orders entity)
        {
            return new GetOrdersModel
            {
                OrderId = entity.Id,
                CustId = entity.CustId,
                EmpId = entity.EmpId,
                OrderDate = entity.OrderDate,
                RequiredDate = entity.RequiredDate,
                ShippedDate = entity.ShippedDate,
                ShipperId = entity.ShipperId,
                Freight = entity.Freight,
                ShipName = entity.ShipName,
                ShipAddress = entity.ShipAddress,
                ShipCity = entity.ShipCity,
                ShipRegion = entity.ShipRegion,
                ShipPostalCode = entity.ShipPostalCode,
                ShipCountry = entity.ShipCountry,
            };
        }
        public static Domain.Entities.Orders MapToEntity(SaveOrdersModel model)
        {
            Domain.Entities.Orders entity = new Domain.Entities.Orders();

            entity.Id = entity.Id;
            entity.CustId = entity.CustId;
            entity.EmpId = entity.EmpId; ;
            entity.OrderDate = entity.OrderDate;
            entity.RequiredDate = entity.RequiredDate;
            entity.ShippedDate = entity.ShippedDate;
            entity.ShipperId = entity.ShipperId;
            entity.Freight = entity.Freight;
            entity.ShipName = entity.ShipName;
            entity.ShipAddress = entity.ShipAddress;
            entity.ShipCity = entity.ShipCity;
            entity.ShipRegion = entity.ShipRegion;
            entity.ShipPostalCode = entity.ShipPostalCode;
            entity.ShipCountry = entity.ShipCountry;
            return entity;
        }
        private static void MapToEntity(UpdateOrdersModel model, Domain.Entities.Orders entity)
        {
            entity.CustId = entity.CustId;
            entity.EmpId = entity.EmpId; ;
            entity.OrderDate = entity.OrderDate;
            entity.RequiredDate = entity.RequiredDate;
            entity.ShippedDate = entity.ShippedDate;
            entity.ShipperId = entity.ShipperId;
            entity.Freight = entity.Freight;
            entity.ShipName = entity.ShipName;
            entity.ShipAddress = entity.ShipAddress;
            entity.ShipCity = entity.ShipCity;
            entity.ShipRegion = entity.ShipRegion;
            entity.ShipPostalCode = entity.ShipPostalCode;
            entity.ShipCountry = entity.ShipCountry;
        }
    }
}
