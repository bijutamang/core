using coresystem.Models;
using coresystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace coresystem.Controllers
{
    public class SharePurchaseController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly ISharePurchaseService _sharePurchaseService;
        public SharePurchaseController(IMemberService memberService, ISharePurchaseService sharePurchaseService)
        {
            _memberService = memberService;
            _sharePurchaseService = sharePurchaseService;
        }

        public async Task<IActionResult>  Index()
        {
            var sharePurchase = await _sharePurchaseService.GetAllSharePurchaseAsync();
            return View(sharePurchase);
        }

        public async Task<IActionResult> PurchaseAsync()
        {

            ViewBag.Member = await _memberService.GetAllMembersAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Purchase(SharePurchase sharePurchase)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _sharePurchaseService.PurchaseShareAsync(sharePurchase);
                }
            }
            catch (Exception)
            {

                throw;
            }
             return RedirectToAction("Index");
        }
    }
}
