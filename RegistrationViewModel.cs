using System;
using System.Collections.Generic;
using System.Text;
using TechNetWikiProxyDesignPattern.Repository;

namespace TechNetWikiProxyDesignPattern
{
    public class RegistrationViewModel
    {
        #region Information about the Item
        public int Item_Id { get; set; }
        public string Item_Name { get; set; }
        public decimal Item_Price { get; set; }
        public DateTime? Item_AvailableFrom { get; set; }
        public DateTime? Item_AvailableTo { get; set; }
        #endregion

        #region Inforamtion about the Seller
        public int Seller_Id { get; set; }
        public string Seller_Name { get; set; }
        public BankDetails Seller_BankDetails { get; set; }
        public Address Seller_Address { get; set; }
        public int Seller_EstimatedDeliveryLeadTime { get; set; }
        #endregion
    }    
}
