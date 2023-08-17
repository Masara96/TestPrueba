using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApiData.Models;

namespace TestWebApiCore.Interfaces
{
    public interface IServiceClient 
    {
        public Task<IEnumerable<Client>> GetAll();
        public Task<Client?> Get(int id);
        public Task<Client?> Search(string nombre);
        public Task<int> Insert(Client client);
        public Task<int> Update(Client client);
        public Task<int> Delete(int id);
    }
}
