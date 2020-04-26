using System;
using System.Collections.Generic;
using System.Text;

namespace TechNetWikiProxyDesignPattern.Repository
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public int EstimatedDeliveryLeadTime { get; set; }
    }

    public class BankDetails
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public string IBAN { get; set; }
        public string AccountNumber { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }
    }
}
