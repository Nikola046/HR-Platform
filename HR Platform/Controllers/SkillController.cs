using Microsoft.AspNetCore.Mvc;
using HR_Platform.Models;
using HR_Platform.Repository;

namespace HR_Platform.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillRepository _skillRepository;

        public SkillController(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public IActionResult Index([FromQuery] string filter)
        {
            ViewData["filter"] = filter;
            if (string.IsNullOrEmpty(filter))
            {
                return View(_skillRepository.GetAllSkills());
            }
            else
            {
                return View(_skillRepository.GetSkillsWithFilter(filter));
            }
               
        }

        public IActionResult Create()
        {
            return View("Edit", new Skill());
        }

        public IActionResult Edit(int id)
        {
            var sk=_skillRepository.GetSingle(id);
            if(sk==null)
                return RedirectToAction("Index");
            return View(sk);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Skill skills)
        {
            try
            {
                if(!ModelState.IsValid)
                    return View(skills);

                _skillRepository.Save(skills);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(skills);
            }
        }

        public IActionResult Delete(int id)
        {
            _skillRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
