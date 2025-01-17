﻿using IdentityServer4.Models;
using IdentityServer4.Stores;
using OpenActive.FakeDatabase.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class AcmePersistedGrantStore : IPersistedGrantStore
    {
        public Task<IEnumerable<PersistedGrant>> GetAllAsync(string subjectId)
        {
            var grants = FakeBookingSystem.Database.GetAllGrants(subjectId);

            List<PersistedGrant> persistedGrants = new List<PersistedGrant>();
            foreach(var grant in grants)
            {
                persistedGrants.Add(new PersistedGrant()
                {
                    Key = grant.Key,
                    Type = grant.Type,
                    SubjectId = grant.SubjectId,
                    ClientId = grant.ClientId,
                    CreationTime = grant.CreationTime,
                    Expiration = grant.Expiration,
                    Data = grant.Data
                });
            }
            return Task.FromResult<IEnumerable<PersistedGrant>>(persistedGrants);
        }

        public Task<PersistedGrant> GetAsync(string key)
        {
            var grant = FakeBookingSystem.Database.GetGrant(key);

            return Task.FromResult(grant != null ? new PersistedGrant()
            {
                Key = grant.Key,
                Type = grant.Type,
                SubjectId = grant.SubjectId,
                ClientId = grant.ClientId,
                CreationTime = grant.CreationTime,
                Expiration = grant.Expiration,
                Data = grant.Data
            } : null);
        }

        public async Task RemoveAllAsync(string subjectId, string clientId)
        {
            FakeBookingSystem.Database.RemoveGrant(subjectId, clientId);
        }

        public async Task RemoveAllAsync(string subjectId, string clientId, string type)
        {
            FakeBookingSystem.Database.RemoveGrant(subjectId, clientId, type);
        }

        public async Task RemoveAsync(string key)
        {
            FakeBookingSystem.Database.RemoveGrant(key);
        }

        public async Task StoreAsync(PersistedGrant grant)
        {
            FakeBookingSystem.Database.AddGrant(grant.Key, grant.Type, grant.SubjectId, grant.ClientId, grant.CreationTime, grant.Expiration, grant.Data);
        }
    }
}
