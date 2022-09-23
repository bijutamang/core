using AspNetCoreHero.ToastNotification.Abstractions;
using coresystem.Models;
using coresystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace coresystem.Controllers
{
    public class SharePurchaseController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly ISharePurchaseService _sharePurchaseService;
        private readonly INotyfService _notify;

        public SharePurchaseController(IMemberService memberService,
            ISharePurchaseService sharePurchaseService,
            INotyfService notify)
        {
            _memberService = memberService;
            _sharePurchaseService = sharePurchaseService;
            _notify = notify;
        }

        public async Task<IActionResult>  Index()
        {
            var sharePurchase = await _sharePurchaseService.GetAllSharePurchaseAsync();
            return View(sharePurchase);
        }

        public async Task<IActionResult> Purchase()
        {

            ViewBag.Member = await _memberService.GetAllMembersAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Purchase(SharePurchase sharePurchase)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _notify.Error("Something wrong");
                    return RedirectToAction("Purchase");
                    
                }
                await _sharePurchaseService.PurchaseShareAsync(sharePurchase);
                _notify.Success("Share purchase for member no " + sharePurchase.MemberId + " of share no. " + sharePurchase.ShareNo + " is successful.");
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
