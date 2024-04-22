using PRN221PE_SP24_TrialTest_NPPT_Repository.Models;


namespace PRN221PE_SP24_TrialTest_NPPT_Repository.Repositories
{
    public interface IAccountRepository
    {
        public StoreAccount GetAccount(string email);
        public List<StoreAccount> GetAccounts();
    }
}
