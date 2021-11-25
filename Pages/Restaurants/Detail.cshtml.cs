using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        [TempData]                      //This Binds the TempData with the same Key Name to the Value it holds assuming the Types Match.
        public string Message { get; set; }
        public Restaurant Restaurant { get; set; }
        public IActionResult OnGet(int restaurantId)        //Replaced void with IActionResult, this is because whenever there is Void, since nothing is being returned, the View i.e. cshtml is first rendered
        {
            Restaurant = restaurantData.GetById(restaurantId);
            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
