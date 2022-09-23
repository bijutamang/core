using AspNetCoreHero.ToastNotification.Abstractions;
using coresystem.Models;
using coresystem.Services.Interfaces;
using coresystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace coresystem.Controllers
{
    public class ShareReturnController : Controller
    {
        private readonly IShareReturnService _shareReturnService;
        private readonly IMemberService _memberService;
        private readonly INotyfService _notify;

        public ShareReturnController(
            IShareReturnService shareReturnService,
            IMemberService memberService,
            INotyfService notify
            )
        {
            _shareReturnService = shareReturnService;
            _memberService = memberService;
            _notify = notify;
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
            ViewBag.Members = await _memberService.GetAllMembersAsync();
            try
            {
                if (!ModelState.IsValid)
                {
                    _notify.Warning("Model is not valid");
                    return View(shareReturn);
                }
                await _shareReturnService.ShareReturnAsync(shareReturn);
                _notify.Success("Share return for member no " + shareReturn.MemberId + " of share no. " + shareReturn.ShareNo + " is successful");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _notify.Error(ex.Message);
                return View(shareReturn);
            }
        }
    }
}
