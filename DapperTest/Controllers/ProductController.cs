﻿using DapperTest.Dtos.EstateDtos;
using DapperTest.Dtos.ProductDtos;
using DapperTest.Services.Abstracts.Estate;
using DapperTest.Services.Abstracts.Product;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IEstateService _estateService;

        public ProductController(IProductService productService, IEstateService estateService)
        {
            _productService = productService;
            _estateService = estateService;
        }

        public async Task<IActionResult> ProductList()
        {
            //await _estateService.Search(new SearchEstateDto { CategoryId = 1, ForSale = true });

            var values = await _productService.GetAllProductWithCategoryAsync();
            ViewBag.productCount = await _productService.GetProductCount();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            await _productService.CreateProductAsync(dto);
            return RedirectToAction("ProductList");
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var values = await _productService.GetProductAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
        {
            await _productService.UpdateProductAsync(dto);
            return RedirectToAction("ProductList");
        }
        public IActionResult deneme()
        {
            return View();
        }
    }
}
