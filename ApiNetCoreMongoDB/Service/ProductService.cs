using ApiNetCoreMongoDB.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiNetCoreMongoDB.Service
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _product;

        public ProductService(IMongoClient client) {

            var database = client.GetDatabase("db_MongoDB");
            var collection = database.GetCollection<Product>(nameof(Product));

            _product = collection;
        }

        public async Task<ObjectId> Create(Product product) {

            await _product.InsertOneAsync(product);

            return product.Id;
        }

        public Task<Product> Get(ObjectId objectId)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, objectId);
            var product = _product.Find(filter).FirstOrDefaultAsync();

            return product;
        }

        public async Task<IEnumerable<Product>> Get()
        {
            var products = await _product.Find(_ => true).ToListAsync();

            return products;
        }

        public async Task<bool> Update(ObjectId objectId, Product product)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, objectId);

            var update = Builders<Product>.Update
                .Set(p => p.Name, product.Name)
                .Set(p => p.Price, product.Price)
                .Set(p => p.DateRegister, product.DateRegister);

            var result = await _product.UpdateOneAsync(filter, update);

            return result.ModifiedCount == 1;
        }

        public async Task<bool> Delete(ObjectId objectId)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, objectId);
            var result = await _product.DeleteOneAsync(filter);

            return result.DeletedCount == 1;
        }
    }
}
