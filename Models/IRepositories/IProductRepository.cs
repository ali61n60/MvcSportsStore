using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.IRepositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
