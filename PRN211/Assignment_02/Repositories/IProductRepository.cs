using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;

public interface IProductRepository
{
    List<Product> GetProductsList();
    Product GetProductByID(int ProductId);
    void Add(Product product);
    void Update(Product product);
    void Delete(int productId);
    IEnumerable<Product> SearchProductByID(int id);
    IEnumerable<Product> SearchProductByName(string name);
    IEnumerable<Product> SearchProductByPrice(decimal price);
    IEnumerable<Product> SearcProductInStock(int inStock);
}
