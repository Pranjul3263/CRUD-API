using CurdApiApplication.Models;
using CurdApiApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurdApiApplication.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{

		public IProduct productServices;

		ApiResponse response = new ApiResponse();
		public ProductController(IProduct product)
		{ 
			this.productServices = product;
		}

		[Route("getProducts")]
		public IActionResult GetProducts()
		{
			var pro=productServices.GetProducts();
			if (pro.Count > 1)
			{
				response.message = "Product found";
				response.data = pro;
				response.status = 200;
				response.ok = true;
			}
			else
			{

				response.message = "Product not found";
				response.data = null;
				response.status = 404;
				response.ok = false;
			}
			return Ok(response);
		}

		[Route("createProducts")]
	
		public IActionResult CreateProducts(Product product)
		{
			var result = productServices.AddProduct(product);
			if (result == "ok")
			{
				response.message = "Product Created succesfully";
				response.data = product;
				response.status = 200;
				response.ok = true;
			}
			else
			{
				response.message = "Product not created";
				response.data = null;
				response.status =500;
				response.ok = false;
			}
			return Ok(response);
		}


		[Route("DeleteProducts")]
		[HttpDelete]
		public IActionResult DeleteProducts(int id)
		{
			var result = productServices.DeleteProduct(id);
			if (result == "ok")
			{
				response.message = "Product Delete succesfully";
				response.data = null;
				response.status = 200;
				response.ok = true;
			}
			else
			{
				response.message = "Product not deleted";
				response.data = null;
				response.status = 404;
				response.ok = false;
			}
			return Ok(response);
		}

		[Route("GetProductsById")]

		public IActionResult GetProductsById(int id)
		{
			var result = productServices.ProductGetById(id);
			if (result != null)
			{
				response.message = "Product get successfully";
				response.data = result;
				response.status = 200;
				response.ok = true;
			}
			else
			{
				response.message = "Product not found";
				response.data = null;
				response.status = 404;
				response.ok = false;
			}
			return Ok(response);
		}

		[Route("UpdateProduct")]

		public IActionResult UpdateProduct(Product product)
		{
			var result = productServices.UpdateProduct(product);
			if (result == "ok")
			{
				response.message = "Product update successfully";
				response.data = result;
				response.status = 200;
				response.ok = true;
			}
			else
			{
				response.message = "Product not update";
				response.data = null;
				response.status = 404;
				response.ok = false;
			}
			return Ok(response);
		}
	}
}
