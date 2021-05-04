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

        [TestInitialize]
        public void MethodInit()
        {
            _manager = new ReadingsManager(ReadingsManager.TestData);
        }

        [TestMethod]
        public void Get_Should_ReturnDataList()
        {
            List<Reading> expected = ReadingsManager.TestData;
            CollectionAssert.AreEquivalent(expected, (ICollection)_manager.GetAll());
        }

        [TestMethod]
        public void GetById_ShouldReturnAppropriateReading()
        {
            Reading expected = ReadingsManager.TestData[0];
            Assert.AreEqual(expected, _manager.GetById(2));

        }

        [TestMethod]
        public void GetById_InvalidId_ShouldReturnNull()
        {
            Reading expected = _manager.GetById(-1);
            Assert.IsNull(expected);
        }

        [TestMethod]
        public void Post_Should_UpdateData()
        {
            Reading newReading = new Reading(3, 4, DateTime.Now, false, new byte[] { });
            int originalLength = _manager.GetAll().Count;
            _manager.Post(newReading);
            Assert.AreNotEqual(originalLength, _manager.GetAll().Count);
        }

        [TestMethod]
        public void Update_ShouldModifyGivenValue()
        {
            Reading original = _manager.GetById(2);
            Reading updated = _manager.Update(2, new Reading(100, 200, DateTime.Now, false, new byte[] { }));
            Assert.AreNotEqual(original, updated);
            Assert.AreEqual(updated.SensorId, 100);
        }

        [TestMethod]
        public void Update_InvalidId_ShouldReturnNull()
        {
            Reading found = _manager.Update(-1, _manager.GetById(2));
            Assert.IsNull(found);
        }

        [TestMethod]
        public void Delete_ShouldRemove_FromData()
        {
            int dataLength = _manager.GetAll().Count;
            _manager.Delete(3);
            Assert.AreNotEqual(dataLength, _manager.GetAll().Count);
        }
    }
}
