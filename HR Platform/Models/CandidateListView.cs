namespace HR_Platform.Models
{
    public class CandidateListView
    {
        public string Filter { get; set; }
        public IEnumerable<SkillFilter> SkillFilter { get; set; }
        public IEnumerable<Candidate> Candidates { get; set; }
    }

    public class SkillFilter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
    }
}
