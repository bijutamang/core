using coresystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace coresystem.Controllers
{
    public class SharePurchaseController : Controller
    {
        private readonly IMemberService _memberService;
        public SharePurchaseController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public async Task<IActionResult>  Index()
        {
            ViewBag.Member = await _memberService.GetAllMembersAsync();
            return View();
        }

        public IActionResult Purchase()
        {
            //ViewBag.Member = await _memberService.GetAllMembersAsync();
            return View();
        }
    }
}
