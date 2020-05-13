using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private SellerService _service;

        public SellersController(SellerService service)
        {
            this._service = service;
        }

        public IActionResult Index()
        {
            var list = _service.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller s)
        {
            _service.Insert(s);
            return RedirectToAction(nameof(Index));
        }
    }
}