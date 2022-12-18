using Microsoft.VisualStudio.TestTools.UnitTesting;
using Advanced_Exam.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Exam.Repositories;
using Advanced_Exam.Models;

namespace Advanced_Exam.Service.Tests
{
    [TestClass()]
    public class HTMLCreatorTests
    {
        [TestMethod()]
        public void CreateHTMLForClientTest()
        {
            //Arrange
            HTMLCreator hTMLCreator = new HTMLCreator();
            List<Product> products = new List<Product>();
            Order order = new Order();
            order._ID = 1;
            order._DateTime = DateTime.Now;
            order._Products = products;

            //Act
            var actualAnswer = hTMLCreator.CreateHTMLForClient(order);

            //Assert
            Assert.IsTrue(actualAnswer);
        }
    }
}