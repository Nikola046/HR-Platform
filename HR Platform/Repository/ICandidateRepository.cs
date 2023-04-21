using HR_Platform.Models;

namespace HR_Platform.Repository
{
    public interface ICandidateRepository
    {
        IEnumerable<Candidate> getAll();
        IEnumerable<Candidate> getWithFilter(string filter, int[] skill);
        Candidate? getSingle(int CandidateID);
        int Save(Candidate candidate);
        void Delete(int  CandidateID);
    }
}
