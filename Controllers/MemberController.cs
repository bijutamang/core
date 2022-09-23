using AspNetCoreHero.ToastNotification.Abstractions;
using coresystem.Models;
using coresystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace coresystem.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly INotyfService _notify;

        public MemberController(IMemberService memberService,
            INotyfService notify)
        {
            _memberService = memberService;
            _notify = notify;
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
                    _notify.Success("Member name. " + member.FullName + " is successfully added.");
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

                    _notify.Success("Member updated Successfully");
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

                _notify.Success("Member deleted Successfully");
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
