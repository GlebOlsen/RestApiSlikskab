using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestService.Managers;
using RestService.Model;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RestServiceTest
{
    [TestClass]
    public class ReadingsManagerTest
    {
        private static ReadingsManager _manager;

        [ClassInitialize]
        public static void Init(TestContext ctx)
        {
            _manager = new ReadingsManager(ReadingsManager.TestData);
        }

        [TestMethod]
        public void Get_Should_ReturnDataList()
        {
            List<Reading> expected = _manager.Data;
            CollectionAssert.AreEquivalent(expected, (ICollection)_manager.GetAll());
        }

        [TestMethod]
        public void GetById_ShouldReturnReadingsForThatSensor()
        {
            Reading expected = _manager.Data[0];
            Assert.AreEqual(expected, _manager.GetById(2));
        }
    }
}
