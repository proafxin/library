using Library.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> books;

        public BookService(IConfiguration configuration)
        {
            MongoClient client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            IMongoDatabase database = client.GetDatabase("library");
            books = database.GetCollection<Book>("Books");
        }

        public List<Book> Get()
        {
            return books.Find(book => true).ToList();
        }

        public Book Get(String id)
        {
            return books.Find(book => book.Id == id).FirstOrDefault();
        }

        public Book Create(Book bookNew)
        {
            books.InsertOne(bookNew);
            return bookNew;
        }

        public void Update(String id, Book bookNew)
        {
            books.ReplaceOne(book => book.Id == id, bookNew);
        }

        public void Remove(String id)
        {
            books.DeleteOne(book => book.Id == id);
        }
    }
}
