﻿using System.Collections.Generic;
using Basket.Management.Basket.Domain.Messaging;

namespace Basket.Management.Basket.Domain.SeedWork
{
    public abstract class DomainEntity : Microsoft.Xrm.Sdk.Entity
    {
        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}
