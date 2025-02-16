using BookShopp.Models;
using BookShopp.Services;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace BookShopp.ViewComponents
{
    public class CartSummaryViewComponent(ICartSessionService sessionService) : ViewComponent
    {
        private readonly ICartSessionService _sessionService = sessionService;

        public ViewViewComponentResult Invoke()
        {
            var model = new CartSummaryViewModel()
            {
                Cart = _sessionService.GetCart()
            };
            return View(model);
        }
    }
}
