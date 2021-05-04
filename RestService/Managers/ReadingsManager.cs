using RestService.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RestService.Managers
{
    public class ReadingsManager
    {
        private static List<Reading> Data { get; set; }
        private int _currentId;
        public static List<Reading> TestData { get; set; } = new List<Reading>()
        {
            new Reading(1, 2, DateTime.Today, false, new byte[]{ }),
            new Reading(2, 3, DateTime.Today, true, new byte[]{ })
        };

        public ReadingsManager(List<Reading> data)
        {
            Data = data.Where((r) => true).ToList(); // Lav en kopi af data listen 
            _currentId = FindLargestId(data);
        }

        public ICollection<Reading> GetAll()
        {
            return Data;
        }

        public Reading GetById(int id)
        {
            return Data.Find((r) => r.ReadingId == id);
        }

        public Reading Post(Reading reading)
        {
            reading.ReadingId = ++_currentId;
            Data.Add(reading);
            return reading;
        }

        public Reading Update(int id, Reading reading)
        {
            Reading fetchedReading = GetById(id);
            if (fetchedReading != null)
            {
                Data.Remove(fetchedReading);
                return Post(reading);
            }
            else
            {
                return null;
            }
        }

        public Reading Delete(int id)
        {
            Reading reading = GetById(id);
            if (reading != null)
            {
                Data.Remove(reading);
            }

            return reading;
        }
        private int FindLargestId(List<Reading> data)
        {
            return data.OrderByDescending((r) => r.ReadingId).First().ReadingId;
        }
    }
}
