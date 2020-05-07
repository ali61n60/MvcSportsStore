using Microsoft.AspNetCore.Mvc;
using Models.IRepositories;
using SportsStore.ViewModels;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;


        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel productsListViewModel = new ProductsListViewModel();
            productsListViewModel.Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize);
            productsListViewModel.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = repository.Products
                .Where(p => category == null || p.Category == category)
                .Count()
            };
            productsListViewModel.CurrentCategory = category;

            return View(productsListViewModel);
        }
    }
}
