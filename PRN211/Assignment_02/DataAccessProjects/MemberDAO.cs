using BusinessObjects;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects;

public class MemberDAO
{
    private FUStoreDBContext _db;

    public MemberDAO()
    {
        _db = new FUStoreDBContext();
    }
    private static MemberDAO instance = null;
    private static object instanceLook = new object();

    public static MemberDAO Instance
    {
        get
        {
            lock (instanceLook)
            {
                if (instance == null)
                {
                    instance = new MemberDAO();
                }
                return instance;
            }
        }
    }

    public List<Member> GetMembersList() => _db.Members.ToList();
    public Member GetMemberByID(int memberId)
    {
        try
        {
            return _db.Members.SingleOrDefault(mem => mem.MemberId == memberId);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public void Add(Member member)
    {
        try
        {
            _db.Add(member);
            _db.SaveChanges();
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public void Update(Member member)
    {
        try
        {
            _db.Update(member);   
            _db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public void Delete(int memberId)
    {
        try
        {
            Member mem = GetMemberByID(memberId);
            _db.Members.Remove(mem);
            _db.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
