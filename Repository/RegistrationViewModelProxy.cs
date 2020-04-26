namespace TechNetWikiProxyDesignPattern.Repository
{
    interface IRegistrationViewModelProxy
    {
        RegistrationViewModel GetRegistrationViewModel(Seller seller, 
                                                        BankDetails bankDetails, 
                                                        Address addres, 
                                                        Item item);
    }

    public class UserRegistrationViewModelProxy : IRegistrationViewModelProxy
    {
        public RegistrationViewModel GetRegistrationViewModel(Seller seller, BankDetails bankDetails, Address addres, Item item)
        {
            return new RegistrationViewModel
            {
                Item_Id = item.Id,
                Item_Name = item.Name,
                Item_Price = item.Price,
                Seller_EstimatedDeliveryLeadTime = seller.EstimatedDeliveryLeadTime                
            }; 
        }
    }

    public class AdminRegistrationViewModelProxy : IRegistrationViewModelProxy
    {
        public RegistrationViewModel GetRegistrationViewModel(Seller seller, BankDetails bankDetails, Address addres, Item item)
        {
            return new RegistrationViewModel
            {
                Item_Id = item.Id,
                Item_Name = item.Name,
                Item_Price = item.Price,
                Item_AvailableFrom = item.AvailableFrom,
                Item_AvailableTo = item.AvailableTo,

                Seller_Id = seller.Id,
                Seller_Address = addres,
                Seller_BankDetails = bankDetails,
                Seller_Name = seller.Name,
                Seller_EstimatedDeliveryLeadTime = seller.EstimatedDeliveryLeadTime,                
            };
        }
    }
}
