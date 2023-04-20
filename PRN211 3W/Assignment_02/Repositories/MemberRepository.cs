using BusinessObjects;
using DataAccessObjects;


namespace Repositories;

public class MemberRepository : IMemberRepository
{
    public List<Member> GetMembersList()
    {
        return MemberDAO.Instance.GetMembersList();
    }
    public Member GetMemberByID(int memberId)
    {
        return MemberDAO.Instance.GetMemberByID(memberId);
    }
    public void Add(Member member) => MemberDAO.Instance.Add(member);
    public void Update(Member member) =>MemberDAO.Instance.Update(member);
    public void Delete(int memberId) =>MemberDAO.Instance.Delete(memberId);


}
