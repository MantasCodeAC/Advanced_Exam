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
    public class TableRepositoryTests
    {
        [TestMethod()]
        public void RetrieveTest()
        {
            //Arrange
            TableRepository tableRepository = new TableRepository();

            //Act
            var actualAnswer = tableRepository.Retrieve(5);

            //Assert
            Assert.AreEqual(5, actualAnswer.Seats);
        }
    }
}