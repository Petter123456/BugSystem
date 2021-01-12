using BugSystem.Data;
using BugSystem.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BugSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BugsController : Controller
    {
        private readonly BugsContext _context;

        public BugsController(BugsContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<BugModel>), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            return Ok(_context.Bugs.ToList());

        }

        [HttpPost]
        [ProducesResponseType(typeof(BugModel), (int)HttpStatusCode.OK)]
        public IActionResult Create(BugModel bugModel)
        {
            _context.Bugs.Add(bugModel);
            _context.SaveChanges();
            return Ok(_context.Bugs.Find(bugModel.Id));
        }

        [HttpPut]
        [ProducesResponseType(typeof(BugModel), (int)HttpStatusCode.OK)]
        public IActionResult Update(BugModel bugModel)
        {
            try
            {
                var bug = _context.Bugs.SingleOrDefault(bug => bug.Id == bugModel.Id);

                if (!String.IsNullOrWhiteSpace(bugModel.Description))
                {
                    bug.Description = bugModel.Description;
                }

                if (bugModel.Status != null)
                {
                    bug.Status = bugModel.Status;

                }

                _context.SaveChanges();

                return Ok(bug);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status204NoContent, e.Message);
            }

        }

        [HttpDelete]
        [ProducesResponseType(typeof(List<BugModel>), (int)HttpStatusCode.OK)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var bug = _context.Bugs.SingleOrDefault(bug => bug.Id == id);
                _context.Bugs.Remove(bug);
                _context.SaveChanges();

                return Ok(bug);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status204NoContent, e.Message);
            }
        }
    }
}
