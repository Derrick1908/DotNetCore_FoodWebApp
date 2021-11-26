using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        //Note that a View Component is not invoked via an Http Request but is called through some Main Layout i.e. through some Other Page, hence no Get() or Post() Methods
        //Follows the MVC Pattern, where Invoke() acts as the Controller, View acts as the View and Count acts as the Model
        public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetCountofRestaurants();
            return View(count);     //In a View we pass the Model to the View, whereas in a Razor Page we dont pass the Model, rather Model Binding takes place which solves the problem of passing the Data
        }
    }
}
