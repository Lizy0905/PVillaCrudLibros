using System;
using System.Collections.Generic;

namespace DL.Models
{
    public partial class Libro
    {
        public int IdLibro { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public string? Isbn { get; set; }
        public DateTime? AñoPublicacion { get; set; }
    }
}
