
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Mvc.Features.Models;

namespace Mvc.Features.ViewComponents;


public class CartSummaryViewComponent  : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(bool showDetails)
    {
        var cart = await FetchCartDataAsync();

        ViewData["ShowDetails"] = showDetails;
        return View(cart);
    }

    private Task<CartSummaryModel> FetchCartDataAsync()
    {
        var mockCart = new CartSummaryModel
        {
            TotalItems = 3,
            TotalPrice = 49.99m
        };
        return Task.FromResult(mockCart);
    }
}
