﻿using System;
using static System.Net.Mime.MediaTypeNames;

namespace RestService.Model
{
    public class Reading
    {
        public int SensorId { get; set; }
        public int ReadingId { get; set; }
        public DateTime Time { get; set; }
        public bool IsOpen { get; set; }
        public byte[] ImageData { get; set; }

        public Reading(int sensorId, int readingId, DateTime time, bool isOpen, byte[] imageData)
        {
            SensorId = sensorId;
            ReadingId = readingId;
            Time = time;
            IsOpen = isOpen;
            ImageData = imageData;
        }
    }
}