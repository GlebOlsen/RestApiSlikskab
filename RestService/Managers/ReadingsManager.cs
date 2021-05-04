﻿using RestService.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RestService.Managers
{
    public class ReadingsManager
    {
        private static List<Reading> Data { get; set; }
        public static List<Reading> TestData { get; set; } = new List<Reading>()
        {
            new Reading(1, 2, DateTime.Today, false, new byte[]{ }),
            new Reading(2, 3, DateTime.Today, true, new byte[]{ })
        };

        public ReadingsManager(List<Reading> data)
        {
            Data = data.Where((r) => true).ToList();
        }

        public ICollection<Reading> GetAll()
        {
            return Data;
        }

        public Reading GetById(int id)
        {
            return Data.Find((r) => r.ReadingId == id);
        }

        public void Post(Reading newReading)
        {
            Data.Add(newReading);
        }

        public Reading Update(int id, Reading reading)
        {
            int index = Data.FindIndex((e) => e.ReadingId == id);
            if (index != -1)
            {
                Data[index] = reading;
                return Data[index];
            }
            else
            {
                return null;
            }
        }

        public Reading Delete(int id)
        {
            Reading reading = GetById(id);
            if(reading != null)
            {
                Data.Remove(reading);
            }

            return reading;
        }
    }
}