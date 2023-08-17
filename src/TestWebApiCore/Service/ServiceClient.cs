using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApiCore.Interfaces;
using TestWebApiData;
using TestWebApiData.DataAccess;
using TestWebApiData.Models;

namespace TestWebApiCore.Service
{
    public class ServiceClient : IServiceClient
    {
        private readonly DBTestContext _dbContext;

        public ServiceClient(DBTestContext dBTestContext)
        {
            _dbContext = dBTestContext;
        }
        public async Task<IEnumerable<Client>> GetAll()
        {
            List<Client> clients = await _dbContext.client.ToListAsync();
            return clients;
        }

        public async Task<Client?> Get(int id)
        {
            Client? client = (Client?) await _dbContext.client.FirstOrDefaultAsync(x => x.id == id);
            return client;
        }

        public async Task<Client?> Search(string nombre)
        {
            Client? client = await _dbContext.client.FirstOrDefaultAsync(x => x.Nombre.ToUpper() == nombre.ToUpper());
            return client;
        }

        public async Task<int> Delete(int id)
        {
            Client cllientDelet = await _dbContext.client.FirstAsync(x => x.id == id);
            _dbContext.client.Remove(cllientDelet);
            int result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> Insert(Client client)
        {
                var r = _dbContext.client.AddAsync(client);
                var result = await _dbContext.SaveChangesAsync();
                return result;
        }

        public async Task<int> Update(Client client)
        {
          

            var r = _dbContext.client.Update(client);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }




    }
}
