﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using GIB.ProductsAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIB.ProductsAPI.Controllers.Tests
{
    [TestClass()]
    public class ProductsControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            ProductsController target = new ProductsController();
            var result = target.Get();

        }
    }
}