using HR_Platform.Models;

namespace HR_Platform.Repository
{
    public class CandidateInMemoryRepository:ICandidateRepository
    {
        private readonly List<Candidate> _candidates=new();

        public CandidateInMemoryRepository()
        {
            _candidates.Add(new Candidate{ CandidateID = 1, FullName = "Marko Markovic", DateOfBirth="10.04.1997", Contact="0631234567", Email="markomarkovic11@gmail.com", Skills=new Skill{ SkillID=1}});
            _candidates.Add(new Candidate { CandidateID = 2, FullName = "Petar Petrovic", DateOfBirth = "03.11.1995", Contact = "0627894561", Email = "petarpetrovic22@gmail.com", Skills = new Skill { SkillID = 2 } });
            _candidates.Add(new Candidate { CandidateID = 3, FullName = "Nevena Miljkovic", DateOfBirth = "25.02.1998", Contact = "0614569872", Email = "nevenamiljkovic33@gmail.com", Skills = new Skill { SkillID = 3 } });
            _candidates.Add(new Candidate { CandidateID = 4, FullName = "Jelena Nikolic", DateOfBirth = "05.12.1997", Contact = "0637531597", Email = "jelenanikolic44@gmail.com", Skills = new Skill { SkillID = 1 } });
            _candidates.Add(new Candidate { CandidateID = 5, FullName = "Aleksa Stevanovic", DateOfBirth = "21.01.1996", Contact = "0643573006", Email = "aleksastevanovic55@gmail.com", Skills = new Skill { SkillID = 3 } });
        }

        public IEnumerable<Candidate> getAll()
        {
            return _candidates;
        }

        public IEnumerable<Candidate> getWithFilter(string filter, int[] skill)
        {
            filter = filter.ToLower();
            return _candidates.Where(c => c.FullName.ToLower().Contains(filter))
                .Where(c => !skill.Any() || (c.Skills != null && skill.Contains(c.Skills.SkillID)));
        }

        public Candidate? getSingle(int candidateID)
        {
            return _candidates.FirstOrDefault(c => c.CandidateID == candidateID);
        }

        public void Delete(int candidateID)
        {
            _candidates.RemoveAll(c => c.CandidateID == candidateID);
        }

        public int Save (Candidate candidate)
        {

            if(_candidates.Any(c=>c.CandidateID != candidate.CandidateID))
            {
                return -10;
            }
            
            if (candidate.CandidateID == 0)
            {
                var MaxId=_candidates.Max(c => c.CandidateID);
                candidate.CandidateID = MaxId+1;
                _candidates.Add(candidate);
            }
            else
            {
                var c=_candidates.FirstOrDefault(c => c.CandidateID == candidate.CandidateID);
                _candidates.Remove(c);
                _candidates.Add(candidate);
            }
            return candidate.CandidateID;
        }
    }
}
