using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;

public class OrderDetailRepository : IOrderDetailRepository
{
    private FUStoreDBContext _db;

    public OrderDetailRepository()
    {
        _db = new FUStoreDBContext();
    }

    public List<Member> GetMembersList() => _db.Members.ToList();
}
