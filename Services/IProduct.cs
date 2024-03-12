using CurdApiApplication.Models;

namespace CurdApiApplication.Services
{
	public interface IProduct
	{

		List<Product> GetProducts();

		string AddProduct(Product product);
		string DeleteProduct(int id);

		string UpdateProduct(Product product);

		Product ProductGetById(int id);
	}
}
