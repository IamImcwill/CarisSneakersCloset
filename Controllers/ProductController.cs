﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarisSneakerCloset.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarisSneakerCloset.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repo;

        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var products = repo.GetAllProducts();
            return View(products);
        }

        public IActionResult ViewProduct(int id)
        {
            var product = repo.GetProduct(id);
            return View(product);
        }

        public IActionResult UpdateProduct(int id)
        {
            Product product = repo.GetProduct(id);
            if (product == null)
            {
                return View("ProductNotFound");
            }
            return View(product);
        }
        public IActionResult UpdateProductToDatabase(Product product)
        {
            repo.UpdateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product.SneakersID });
        }
        public IActionResult InsertProduct()
        {
            var product = repo.GetAllProducts();
            return View(product);
        }
        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
            repo.InsertProduct(productToInsert);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(Product product)
        {
            repo.DeleteProduct(product);
            return RedirectToAction("Index");
        }
    }
}
