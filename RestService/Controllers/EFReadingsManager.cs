using RestService.Contexts;
using RestService.Managers;
using RestService.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestService.Controllers
{
    internal class EFReadingsManager : IManager<Reading> 
    {
        private ReadingContext _context;
        private int _currentId;

        public EFReadingsManager(ReadingContext ctx)
        {
            _context = ctx;
            if (_context.Readings.Count() == 0)
            {
                _currentId = 0;
            } else
            {
                _currentId = _context.Readings.OrderByDescending((r) => r.ReadingId).First().ReadingId;
            }
        }

        public Reading Delete(int id)
        {
            Reading reading = GetById(id);
            _context.Readings.Remove(reading);
            _context.SaveChanges();
            return reading;
        }

        public ICollection<Reading> GetAll()
        {
            return _context.Readings.ToList();
        }

        public Reading GetById(int id)
        {
            return _context.Readings.Find(id);
        }
        public Reading Post(Reading value)
        {
            value.ReadingId = ++_currentId;
            _context.Readings.Add(value);
            _context.SaveChanges();
            return value;
        }

        public Reading Update(int id, Reading value)
        {
            throw new System.NotImplementedException();
        }
    }
}