using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Core.Models
{
    public class MovieForCreation
    {
        public Guid DirectorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
