using RestService.Model;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RestService.Managers
{
    public class ReadingsManager
    {
        public List<Reading> Data { get; }
        public static List<Reading> TestData = new List<Reading>()
        {
            new Reading(1, 2, DateTime.Today, false, new byte[]{ }),
            new Reading(2, 3, DateTime.Today, true, new byte[]{ })
        };

        public ReadingsManager(List<Reading> data)
        {
            Data = data;
        }

        public ICollection<Reading> GetAll()
        {
            return Data;
        }

        public Reading GetById(int id)
        {
            return Data.Find((r) => r.ReadingId == id);
        }
    }
}
