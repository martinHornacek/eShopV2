﻿using Basket.Management.Basket.Domain.SeedWork;

namespace Basket.Management.Basket.Domain.AggregatesModel.ItemAggregate
{
    public class Item : DomainEntity, IAggregateRoot
    {
        private readonly string _name;
        private readonly decimal _price;
        private readonly string _itemId;

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public decimal Price
        {
            get
            {
                return _price;
            }
        }

        public string ItemId
        {
            get
            {
                return _itemId;
            }
        }

        public Item(string id, string name, decimal price)
        {
            _itemId = id;
            _name = name;
            _price = price;
        }
    }
}
