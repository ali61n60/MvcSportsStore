﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Moq;
using SportsStore.Controllers;
using Models;
using Models.IRepositories;

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

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            // Act
            IEnumerable<Product> result =
            controller.List(2).ViewData.Model as IEnumerable<Product>;
            // Assert
            Product[] prodArray = result.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.AreEqual("P4", prodArray[0].Name);
            Assert.AreEqual("P5", prodArray[1].Name);
        }

    }
}
