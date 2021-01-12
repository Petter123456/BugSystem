using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugSystem.Models
{
    public class BugModel
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }
    }
}
