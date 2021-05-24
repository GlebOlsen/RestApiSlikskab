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
        private static Reading _testReading;

        [TestInitialize]
        public void MethodInit()
        {
            _manager = new ReadingsManager(ReadingsManager.TestData);
            _testReading = new Reading(3, 100, (int)DateTimeOffset.Now.ToUnixTimeSeconds(), false, null);
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
            int originalLength = _manager.GetAll().Count;
            _manager.Post(_testReading);
            Assert.AreNotEqual(originalLength, _manager.GetAll().Count);
        }

        [TestMethod]
        public void Post_ShouldOverideIdToLargestInData()
        {
            int originalId = _testReading.ReadingId;
            Reading posted = _manager.Post(_testReading);
            Assert.AreNotEqual(originalId, posted.ReadingId);
        }

        [TestMethod]
        public void Update_ShouldModifyGivenValue()
        {
            Reading original = _manager.GetById(2);
            int originalId = _testReading.ReadingId;
            Reading updated = _manager.Update(2, _testReading);
            Assert.AreNotEqual(original, updated);
            Assert.IsTrue(updated.ReadingId < originalId);
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
