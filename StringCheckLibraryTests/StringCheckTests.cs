using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCheckLibrary;
namespace StringCheckLibraryTests

{
    [TestClass]
    public class StringCheckTests
    {
        [TestMethod]
        public void CheckName_isEmpty_falseReturned()
        {
            //Arrange
            string stringName = "";
            //Act
            StringCheck obj = new StringCheck();
            bool result = obj.CheckName(stringName);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CheckName_isRusTireSpace_trueReturned()
        {
            //Arrange
            string stringName = "Фамилия-Фамилия  Имя";
            //Act
            StringCheck obj = new StringCheck();
            bool result = obj.CheckName(stringName);
            //Assert
            Assert.IsTrue(result);


        }
        [TestMethod]
        public void CheckName_isLatSpace_falseReturned()
        {
            //Arrange
            string stringName = "Surname Name";
            //Act
            StringCheck obj = new StringCheck();
            bool result = obj.CheckName(stringName);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CheckName_isSpecNumeric_falseReturned()
        {
            //Arrange
            string stringName = "Surname# 1Name";
            //Act
            StringCheck obj = new StringCheck();
            bool result = obj.CheckName(stringName);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CheckName_isOnlySpace_falseReturned()
        {
            //Arrange
            string stringName = "   ";
            //Act
            StringCheck obj = new StringCheck();
            bool result = obj.CheckName(stringName);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CheckName_isOnlyTire_falseReturned()
        {
            //Arrange
            string stringName = "--";
            //Act
            StringCheck obj = new StringCheck();
            bool result = obj.CheckName(stringName);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CheckName_isLenthNonCorrent_falseReturned()
        {
            //Arrange
            string stringName = "ввввв ввввввввввввв ввввввввввввввввввввввввввв ввввввввввввввввввввввввввввввввввввввв";
            //Act
            StringCheck obj = new StringCheck();
            bool result = obj.CheckName(stringName);
            //Assert
            Assert.IsFalse(result);
        }
        

    }
}
