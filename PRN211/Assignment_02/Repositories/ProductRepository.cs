using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repositories;

public class ProductRepository : IProductRepository
{
    
    public List<Product> GetProductsList()
    {
        return ProductDAO.Instance.GetProductsList();
    }
    public Product GetProductByID(int ProductId)
    {
        return ProductDAO.Instance.GetProductByID(ProductId);
    }

    public void Add(Product product) => ProductDAO.Instance.Add(product);
    public void Update(Product product) => ProductDAO.Instance.Update(product);
    public void Delete(int productId) => ProductDAO.Instance.Delete(productId);
    public IEnumerable<Product> SearchProductByID(int id)
    {
        return ProductDAO.Instance.SearchProductByID(id);
    }
    public IEnumerable<Product> SearchProductByName(string name)
    {
        return ProductDAO.Instance.SearchProductByName(name);
    }

    public IEnumerable<Product> SearchProductByPrice(decimal price)
    {
        return ProductDAO.Instance.SearchProductPrice(price);
    }
    public IEnumerable<Product> SearcProductInStock(int inStock)
    {
        return ProductDAO.Instance.SearcProductInStock(inStock);
    }
}
