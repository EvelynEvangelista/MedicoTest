using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MedicoTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicoTest.Controllers
{
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        private readonly PatientContext _context;

        public PatientController(PatientContext context)
        {
            _context = context;

            if (_context.Patients.Count() == 0)
            {
                _context.Patients.Add(new Patient { FirstName = "John", LastName = "Smith", Age = 21 });
                _context.Patients.Add(new Patient { FirstName = "Mary", LastName = "Jane", Age = 28 });
                _context.Patients.Add(new Patient { FirstName = "Elizabeth", LastName = "Stone", Age = 22 });
                _context.Patients.Add(new Patient { FirstName = "Jimmy", LastName = "Brown", Age = 27 });
                _context.Patients.Add(new Patient { FirstName = "Rose", LastName = "Hamilton", Age = 23 });
                _context.Patients.Add(new Patient { FirstName = "Lewis", LastName = "Martin", Age = 26 });
                _context.Patients.Add(new Patient { FirstName = "Ian", LastName = "Wayne", Age = 24 });
                _context.Patients.Add(new Patient { FirstName = "Samantha", LastName = "Picoult", Age = 25 });
                _context.SaveChanges();
            }
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return _context.Patients.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}", Name ="GetPatient")]
        public IActionResult GetById(long id)
        {
            var item = _context.Patients.FirstOrDefault(p => p.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Patient item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Patients.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetPatient", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Patient item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var patient = _context.Patients.FirstOrDefault(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            patient.FirstName = item.FirstName;
            patient.LastName = item.LastName;
            patient.Age = item.Age;

            _context.Patients.Update(patient);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var blogPosts = (from p in _context.Patients
                             where p.Id == id
                             select p);

            if (!blogPosts.Any())
            {
                return NotFound();
            }

            var patient = _context.Patients.First(p => p.Id == id);
            _context.Patients.Remove(patient);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
