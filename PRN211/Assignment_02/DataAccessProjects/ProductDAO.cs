using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects;

public class ProductDAO
{
    private FUStoreDBContext _db;

    public ProductDAO()
    {
        _db = new FUStoreDBContext();
    }
    private static ProductDAO instance = null;
    private static object instanceLook = new object();

    public static ProductDAO Instance
    {
        get
        {
            lock (instanceLook)
            {
                if (instance == null)
                {
                    instance = new ProductDAO();
                }
                return instance;
            }
        }
    }

    public List<Product> GetProductsList() => _db.Products.ToList();
    public Product GetProductByID(int ProductId)
    {
        try
        {
            return _db.Products.SingleOrDefault(pro => pro.ProductId == ProductId);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public void Add(Product Product)
    {
        try
        {
            _db.Add(Product);
            _db.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public void Update(Product Product)
    {
        try
        {
            _db.Update(Product);
            _db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public void Delete(int ProductId)
    {
        try
        {
            Product pro = GetProductByID(ProductId);
            _db.Products.Remove(pro);
            _db.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public IEnumerable<Product> SearchProductByID(int id)
    {
        var ProductSearch = from Product in _db.Products.ToList()
                            where Product.ProductId == id
                            select Product;
        return ProductSearch;
    }
    public IEnumerable<Product> SearchProductByName(string name)
    {
        var ProductSearch = from Product in _db.Products.ToList()
                            where Product.ProductName.Contains(name)
                            select Product;
        return ProductSearch;
    }
     public IEnumerable<Product> SearchProductPrice(decimal price) 
    {
        var ProductSearch = from Product in _db.Products.ToList()
                            where Product.UnitPrice <= price
                           select Product;
        return ProductSearch;
    }
    public IEnumerable<Product> SearcProductInStock(int inStock) 
    {
        var ProductSearch = from Product in _db.Products.ToList()
                            where Product.UnitsInStock >= inStock
                           select Product;
        return ProductSearch;
    }
}
