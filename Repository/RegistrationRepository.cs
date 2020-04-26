using System;
using System.Collections.Generic;
using System.Linq;

namespace TechNetWikiProxyDesignPattern.Repository
{
    internal class RegistrationRepository
    {
        IRegistrationViewModelProxy _registrationViewModelProxy;
        public RegistrationRepository(IRegistrationViewModelProxy registrationViewModelProxy)
        {
            _registrationViewModelProxy = registrationViewModelProxy;
        }

        public IEnumerable<RegistrationViewModel> GetRegistrationViewModels(int pageNumer, int pageSize)
        {
            var query = from seller in _sellers
                        join address in _addresses on seller.Id equals address.SellerId
                        join bank in _bankDetails on seller.Id equals bank.SellerId
                        join item in _items on seller.Id equals item.SellerId                        
                        select _registrationViewModelProxy.GetRegistrationViewModel(seller, bank, address, item);

            return query.Skip(pageNumer * pageSize).Take(pageSize);
        }


        #region Seed the repo
        static List<Seller> _sellers = Enumerable.Range(0, 10).Select(i => new Seller { Id = i, Name = $"Seller {i}", EstimatedDeliveryLeadTime = 13 }).ToList();
        static List<Address> _addresses = Enumerable.Range(0, 10).Select(i => new Address { Id = i, SellerId = i, Street = $"10 Seller {i} Street", Country = "Somewhere", City = "Overthere" }).ToList();
        static List<BankDetails> _bankDetails = Enumerable.Range(0, 10).Select(i => new BankDetails { Id = i, SellerId = i, IBAN="123456456654654", AccountNumber = "748546534512315668" }).ToList();
        static List<Item> _items = Enumerable.Range(0, 500).Select(i => new Item { Id = i, SellerId = i % 10, Price = 13m, AvailableFrom = DateTime.Now.AddDays(-100), AvailableTo=DateTime.Now.AddDays(100), Name = $"Something Great {i}" }).ToList();
        #endregion
    }
}
