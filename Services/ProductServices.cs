using CurdApiApplication.Data;
using CurdApiApplication.Models;

namespace CurdApiApplication.Services
{
	public class ProductServices : IProduct
	{

		public ApplicationDbContext DbContext { get; }

		public ProductServices(ApplicationDbContext dbContext)
		{
			DbContext = dbContext;
		}


		public string AddProduct(Product product)
		{
			DbContext.products.Add(product);
			DbContext.SaveChanges();
			return "ok";
		}

		public string DeleteProduct(int id)
		{
			var pro=DbContext.products.SingleOrDefault( p => p.Id ==id);
			DbContext.products.Remove(pro);
			DbContext.SaveChanges() ;
			return "ok";
		}

		public List<Product> GetProducts()
		{
			return DbContext.products.ToList();
		}

		public Product ProductGetById(int id)
		{
			var pro = DbContext.products.SingleOrDefault(p => p.Id == id);
			return pro;
		}

		public string UpdateProduct(Product product)
		{
			DbContext.products.Update(product);
			DbContext.SaveChanges ();
			return "ok";
		}
	}
}
