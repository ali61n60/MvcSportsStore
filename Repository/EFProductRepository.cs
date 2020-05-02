using Models;
using Models.IRepositories;
using Repository.Context;
using System.Collections.Generic;

namespace Repository
{
    public class EFProductRepository:IProductRepository
    {
        private ApplicationDbContext context;
        public EFProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Product> Products => context.Products;
    }
}

