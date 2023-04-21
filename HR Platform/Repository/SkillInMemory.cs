using HR_Platform.Models;

namespace HR_Platform.Repository
{
    public class SkillInMemory:ISkillRepository
    {
        private readonly List<Skill> _skills = new();

        public SkillInMemory()
        {
            _skills.Add(new Skill{ SkillID=1, SkillName="C#", Code="01"});
            _skills.Add(new Skill { SkillID = 2, SkillName = "C#, Python", Code = "02" });
            _skills.Add(new Skill { SkillID = 3, SkillName = "SQL, Java", Code = "03" });
            _skills.Add(new Skill { SkillID = 4, SkillName = "Angular",  Code = "04" });

        }

        public List<Skill> GetAllSkills()
        {
            return _skills;
        }

        public List<Skill>GetSkillsWithFilter(string filter)
        {
            filter = filter.ToLower();
            return _skills.Where(s => s.SkillName.ToLower().Contains(filter) || s.Code.ToLower().Contains(filter)).ToList();
        }

        public Skill? GetSingle(int skillId)
        {
            return _skills.FirstOrDefault(s => s.SkillID == skillId);
        }

        public void Delete(int skillId)
        {
            _skills.RemoveAll(s => s.SkillID == skillId);
        }

        public int Save(Skill skill)
        {
            
            if (skill.SkillID == 0)
            {
                var MaxID = _skills.Max(s => s.SkillID);
                skill.SkillID = MaxID+1;
                _skills.Add(skill);
            }
            else
            {
                var s=_skills.FirstOrDefault(s=>s.SkillID==skill.SkillID);
                if (s != null)
                    _skills.Remove(s);
                _skills.Add(skill);

            }
            return skill.SkillID;
        }
    }
}
