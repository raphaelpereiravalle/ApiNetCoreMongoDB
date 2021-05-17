using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApiNetCoreMongoDB.Models
{
    public class Product
    {
        //[BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public string Name { get; set; }
       
        public bool Status { get; set; }
        
        public double Price { get; set; }
        
        public DateTime DateRegister { get; set; }
    }
}
