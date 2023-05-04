﻿using Maletkunst.MVC.DAL.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Maletkunst.MVC.DAL.Model;

namespace Maletkunst.MVC.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly IPaintingMvcDataAccess _client;

        public ShoppingCartController(IPaintingMvcDataAccess client)
        {
            _client = client;
        }

        public IActionResult Index()
        {
            return View(GetCartFromCookie(HttpContext));
        }



        public IActionResult Add(int id)
        {
            ShoppingCart cart = GetCartFromCookie(HttpContext);

            var painting = _client.GetPaintingById(id);

            if (painting != null)
            {
                var shoppingCartItem = new ShoppingCartItem
                {
                    Id = painting.Id,
                    Name = painting.Title,
                    Price = painting.Price ?? 0,
                    Quantity = 1
                };
                cart.Items.Add(shoppingCartItem);
            }

            SaveCartToCookie(cart);
            return RedirectToAction("Index", "Paintings");
        }


        private void SaveCartToCookie(ShoppingCart cart)
        {
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(7);
            cookieOptions.Path = "/";
            Response.Cookies.Append("ShoppingCart", JsonSerializer.Serialize(cart), cookieOptions);
        }

        public ShoppingCart GetCartFromCookie(HttpContext httpContext)
        {
            httpContext.Request.Cookies.TryGetValue("ShoppingCart", out string? cookie);
            if (cookie == null) { return new ShoppingCart(); }
            return JsonSerializer.Deserialize<ShoppingCart>(cookie) ?? new ShoppingCart();
        }

        public IActionResult Delete(int id)
        {
            ShoppingCart cart = GetCartFromCookie(HttpContext);
            ShoppingCartItem item = cart.Items.Find(i => i.Id == id);

            if (item != null)
            {
                cart.Items.Remove(item);
            }

            SaveCartToCookie(cart);
            return RedirectToAction("ShoppingCart");
        }

        public IActionResult EmptyCart()
        {
            ShoppingCart cart = new ShoppingCart();
            SaveCartToCookie(cart);
            return RedirectToAction("ShoppingCart");
        }

        public IActionResult ShoppingCart()
        {
            return View("~/Views/ShoppingCart/Index.cshtml", GetCartFromCookie(HttpContext));
        }
    }
}