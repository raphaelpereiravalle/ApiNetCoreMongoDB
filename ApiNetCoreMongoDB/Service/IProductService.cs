using ApiNetCoreMongoDB.Models;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiNetCoreMongoDB.Service
{
    public interface IProductService
    {
        // Create
        Task<ObjectId> Create(Product product);

        // Read
        Task<Product> Get(ObjectId objectId);
        Task<IEnumerable<Product>> Get();
        // Task<IEnumerable<Car>> GetByMake(string make);

        // Update
        Task<bool> Update(ObjectId objectId, Product product);

        // Delete
        Task<bool> Delete(ObjectId objectId);
    }
}
