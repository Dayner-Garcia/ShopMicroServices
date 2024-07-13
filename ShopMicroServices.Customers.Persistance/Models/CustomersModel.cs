﻿
namespace ShopMicroServices.Customers.Persistence.Models
{
    public class CustomersModel
    {
        public int CustId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { set; get; }
        public string ContactTitle { set; get; }
        public string Address { set; get; }
        public string Email { set; get; }
        public string City { set; get; }
        public string? Region { set; get; }
        public string? PostalCode { set; get; }
        public string Country { set; get; }
        public string Phone { set; get; }
        public string? Fax { set; get; }
    }
}