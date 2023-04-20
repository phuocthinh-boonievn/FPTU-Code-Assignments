using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;

public interface IMemberRepository
{
    List<Member> GetMembersList();
    public Member GetMemberByID(int memberId);
    public void Add(Member member);
    public void Update(Member member);
    public void Delete(int memberId);
}
