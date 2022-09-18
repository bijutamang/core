using coresystem.Models;
using coresystem.Repositorys.Interfaces;
using coresystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace coresystem.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<IActionResult> Index()
        {
            var members = await _memberService.GetAllMembersAsync();
            return View(members);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Member member)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _memberService.AddMemberAsync(member);
                    return RedirectToAction("Index");
                }
                return View(member);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            var member = await _memberService.GetSingleMemberAsync(id);
            if(member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Member member)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _memberService.UpdateMemberAsync(member);
                    return RedirectToAction("Index");
                }
                return View(member);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var member = await _memberService.GetSingleMemberAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, Member member)
        {
            try
            {
                await _memberService.DeleteMemberAsync(id);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
