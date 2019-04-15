using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Core.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Director { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
