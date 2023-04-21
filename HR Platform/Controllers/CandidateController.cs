using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using HR_Platform.Models;
using HR_Platform.Repository;

namespace HR_Platform.Controllers
{
    public class CandidateController : Controller
    {
        readonly ICandidateRepository _candidateRepository;
        readonly ISkillRepository _skillRepository;

        public CandidateController(ICandidateRepository candidateRepository, ISkillRepository skillRepository)
        {
            _candidateRepository = candidateRepository;
            _skillRepository = skillRepository;
        }

        
        public IActionResult Index([FromQuery] string filter, [FromQuery] int[] skills)
        {
            //ako je filter null, setovati da bude prazan string
            if (filter == null)
                filter = "";
            var skill=_skillRepository.GetAllSkills();
            var can = new List<Candidate>();

            //ako su filter i filter skillova prazni, onda uzmi sve kandidate, u suprotnom odradi filter
            if(string.IsNullOrEmpty(filter) && !skills.Any())
            {
                can=_candidateRepository.getAll().ToList();
            }
            else
            {
                can = _candidateRepository.getWithFilter(filter, skills).ToList();
            }

            //kreiraj spisak skillova za filter i podesi sta je selektovano, a sta nije
            var skillFilter = skill.Select(sk => new SkillFilter
            {
                Id = sk.SkillID,
                Name = sk.SkillName,
                Selected=skills.Contains(sk.SkillID)
            });

            //kreiranje view modela
            var viewModel = new CandidateListView
            {
                SkillFilter = skillFilter,
                Candidates = can,
                Filter = filter
            };

            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var candidate = _candidateRepository.getSingle(id);
            if (candidate == null)
            {
                return RedirectToAction("index");
            }
            candidate.Skills = _skillRepository.GetSingle(candidate.Skills?.SkillID ?? 0);

            return View(candidate);
        }

        public IActionResult Create()
        {
            var skills=_skillRepository.GetAllSkills();

            ViewData["skills"] = new SelectList(skills, "SkillID", "SkillName");

            return View("Edit", new Candidate());
        }

        public IActionResult Edit(int id)
        {
            var skills = _skillRepository.GetAllSkills();
            ViewData["skills"] = new SelectList(skills, "SkillID", "SkillName");

            return View(_candidateRepository.getSingle(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Candidate candidate)
        {
            try
            {
                ModelState.Remove("Skill.SkillID");
                ModelState.Remove("Skill.SkillName");

                if (!ModelState.IsValid)
                {
                    var skills= _skillRepository.GetAllSkills();
                    ViewData["skills"] = new SelectList(skills, "SkillID", "SkillName");

                    return View(candidate);
                }

                var result=_candidateRepository.Save(candidate);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var skills = _skillRepository.GetAllSkills();
                ViewData["skills"]=new SelectList(skills, "SkillID", "SkillName");

                return View(candidate);

            }
        }

        public IActionResult Delete(int id)
        {
            var candidate = _candidateRepository.getSingle(id);
            if (candidate == null)
            {
                return RedirectToAction("Index");
            }

            _candidateRepository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
