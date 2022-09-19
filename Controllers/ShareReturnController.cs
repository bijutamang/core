using coresystem.Models;
using coresystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace coresystem.Controllers
{
    public class ShareReturnController : Controller
    {
        private readonly IShareReturnService _shareReturnService;
        private readonly IMemberService _memberService;
        public ShareReturnController(IShareReturnService shareReturnService, IMemberService memberService)
        {
            _shareReturnService = shareReturnService;
            _memberService = memberService;
        }
        public async Task<IActionResult> Index()
        {
            var allReturnShare = await _shareReturnService.GetAllShareReturnAsync();
            return View(allReturnShare);
        }

        public async Task<IActionResult> ReturnAsync()
        {
            ViewBag.Members = await _memberService.GetAllMembersAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ReturnAsync(ShareReturn shareReturn)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _shareReturnService.ShareReturnAsync(shareReturn);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception)
            {
                throw;
            }
            return View(shareReturn);
        }
    }
}
