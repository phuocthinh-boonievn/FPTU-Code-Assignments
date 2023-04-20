using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;

public class OrderRepository : IOrderDetailRepository
{
    private FUStoreDBContext _db;

    public OrderRepository()
    {
        _db = new FUStoreDBContext();
    }

    public List<Member> GetMembersList() => _db.Members.ToList();
}
