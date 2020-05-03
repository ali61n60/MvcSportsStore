using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Moq;
using SportsStore.Controllers;
using Models;
using Models.IRepositories;
using SportsStore.ViewModels;

namespace SportsStore.Tests
{
    class ProductControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Can_Paginate()
        {
            // Arrange

            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"}
            });

            ProductController controller = new ProductController(mock.Object) { PageSize = 3 };

            // Act
            ProductsListViewModel result =
            controller.List(2).ViewData.Model as ProductsListViewModel;
            // Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.AreEqual("P4", prodArray[0].Name);
            Assert.AreEqual("P5", prodArray[1].Name);
        }

        [Test]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"}
});
            // Arrange
            ProductController controller =  new ProductController(mock.Object) { PageSize = 3 };
            // Act
            ProductsListViewModel result = controller.List(2).ViewData.Model as ProductsListViewModel;
            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(2, pageInfo.CurrentPage);
            Assert.AreEqual(3, pageInfo.ItemsPerPage);
            Assert.AreEqual(5, pageInfo.TotalItems);
            Assert.AreEqual(2, pageInfo.TotalPages);
        }

    }
}
