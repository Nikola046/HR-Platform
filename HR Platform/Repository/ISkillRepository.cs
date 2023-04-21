using HR_Platform.Models;

namespace HR_Platform.Repository
{
    public interface ISkillRepository
    {
        List<Skill> GetAllSkills();
        List<Skill>GetSkillsWithFilter(string filter);
        Skill? GetSingle(int SkillID);
        void Delete(int SkillID);
        int Save(Skill skill);
           
    }
}
