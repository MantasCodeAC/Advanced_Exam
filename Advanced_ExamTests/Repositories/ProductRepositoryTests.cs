using Microsoft.VisualStudio.TestTools.UnitTesting;
using Advanced_Exam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Exam.Repositories.Tests
{
    [TestClass()]
    public class ProductRepositoryTests
    {
        [TestMethod()]
        public void RetrieveFoodTest()
        {
            //Arrange
            ProductRepository repository = new ProductRepository();

            //Act
            var actualAnswer = repository.RetrieveFood(10);

            //Assert
            Assert.AreEqual("Kiaulienos šašlykas", actualAnswer.Name);
        }
    }
}