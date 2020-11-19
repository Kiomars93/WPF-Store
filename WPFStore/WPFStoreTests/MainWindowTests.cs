using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPFStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPFStore.Tests
{
    [TestClass()]
    public class MainWindowTests
    {

        [TestMethod()]
        public void CreateProduct()
        {
            //Testar Product kontruktor
            var product = new Product("Mineral vatten", "Gott med äkta mineral vatten", 6, "Bonaqua.png");

            Assert.AreEqual("Mineral vatten", product.Title);
            Assert.AreEqual("Gott med äkta mineral vatten", product.Description);
            Assert.AreEqual(6, product.Price);
            Assert.AreEqual("Bonaqua.png", product.Image);
        }

        [TestMethod()]
        public void CreateDiscount()
        {
            //Testar discount konstruktor
            var discount = new Discount("Deals", 250);

            Assert.AreEqual("Deals", discount.Code);
            Assert.AreEqual(250, discount.CodePercentage);
        }

        [TestMethod()]
        public void ReadCSVProductFileTest()
        {
            var result = MainWindow.ReadStaticCSVDisplayFile();

            Assert.AreEqual(4, result.Count);
        }

        [TestMethod()]
        public void ReadCSVDiscountFileTest()
        {
            var result = MainWindow.ReadStaticCSVDiscountFile();

            Assert.AreEqual(3, result.Count);
        }

        [TestMethod()]
        public void CheckingSavedCart()
        {
            //Kollar om det finns någon produkt i den sparade varukorgen
            //act
            var result = MainWindow.SaveToCsvCart("Scooter, My old scooter I had when I was 6, 10, Scooter.jpg");

            //Om den är tom så får vi false
            var result2 = MainWindow.SaveToCsvCart(string.Empty);

            Assert.AreEqual(true, result);
            Assert.AreEqual(false, result2);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MaxPriceTest()
        {
            var product = new Product();
            product.PriceCap(300);
        }

    }
}