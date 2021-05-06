using System;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace RestService.Model
{
    public class Reading
    {
        public int SensorId { get; set; }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ReadingId { get; set; }
        public int Time { get; set; }
        public bool IsOpen { get; set; }
        public string Image { get; set; }

        public Reading() { }
        public Reading(int sensorId, int readingId, int time, bool isOpen, string imageData)
        {
            SensorId = sensorId;
            ReadingId = readingId;
            Time = time;
            IsOpen = isOpen;
            Image = imageData;
        }
    }
}
